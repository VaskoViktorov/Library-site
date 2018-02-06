namespace Library.Web.Areas.LibraryBlog.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Services.Html;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models.Articles;
    using Services.LibraryBlog;
    using System.Threading.Tasks;
    using Infrastructure.Extensions;
    using Infrastructure.Filters;

    public class ArticlesController : BaseController
    {
        private const string ModelName = "Статията";

        private readonly IArticleService articles;
        private readonly IHtmlService html;

        public ArticlesController(IArticleService articles, IHtmlService html)
        {
            this.articles = articles;
            this.html = html;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Articles(int page = 1)
            => this.View(new ArticleListingViewModel
            {
                Articles = await this.articles.AllArticlesAsync(page),
                TotalArticles = await this.articles.TotalAsync(),
                CurrentPage = page
            });

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
            => this.View(new ArticleViewModel
            {
                Article = await this.articles.Details(id)
            });


        public IActionResult Create()
            => this.View();

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Create(ArticleFormModel model)
        {
            model.Description = this.html.Sanitize(model.Description);

            var userName = User.Identity.Name;

            if (model.Files == null || model.Files.Count == 0)
                return Content("files not selected");

            var gallery = new List<string>();
            foreach (var file in model.Files)
            {

                var path = Path.Combine("images", "GalleryImages", Guid.NewGuid() + file.GetFileType());
                var pathForUpload = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", path);
              
                using (var stream = new FileStream(pathForUpload, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                gallery.Add($"\\{path}");
            }

            await this.articles.CreateAsync(
                model.Title,
                model.Description,
                model.ReleaseDate,
                model.Type,
                userName,
                gallery,
                model.Language
              );

            this.TempData.AddSuccessMessage(string.Format(WebConstants.TempDataCreateCommentText, ModelName, "a"));

            return this.RedirectToAction(nameof(this.Articles));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var article = await this.articles.ByIdAsync(id);

            if (article == null)
            {
                return this.NotFound();
            }

            return this.View(new ArticleFormModel
            {
                Title = article.Title,
                Description = article.Description,
                ReleaseDate = article.ReleaseDate,
                Type = article.Type,
                Language = article.Language
            });
        }

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Edit(int id, ArticleFormModel model)
        {
            model.Description = this.html.Sanitize(model.Description);

            var userName = User.Identity.Name;

            await this.articles.EditAsync(
                id,
                model.Title,
                model.Description,
                model.ReleaseDate,
                model.Type,
                userName,
                model.Language
                );

            this.TempData.AddSuccessMessage(string.Format(WebConstants.TempDataEditCommentText, ModelName, "a"));

            return this.RedirectToAction(nameof(this.Articles));
        }

        public IActionResult Delete(int id)
            => this.View(id);

        public async Task<IActionResult> Destroy(int id)
        {
            await this.articles.DeleteAsync(id);

            this.TempData.AddSuccessMessage(string.Format(WebConstants.TempDataDeleteCommentText, ModelName, "a"));

            return this.RedirectToAction(nameof(this.Articles));
        }
    }
}
