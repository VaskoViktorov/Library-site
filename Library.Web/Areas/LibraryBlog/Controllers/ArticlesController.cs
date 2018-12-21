namespace Library.Web.Areas.LibraryBlog.Controllers
{
    using Infrastructure.Extensions;
    using Infrastructure.Filters;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models.Articles;
    using Services.Html;
    using Services.LibraryBlog;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Threading.Tasks;

    using static WebConstants;

    public class ArticlesController : BaseController
    {
        private const string ModelName = ArticleBgModelName;

        private readonly IArticleService articles;
        private readonly IHtmlService html;
        private readonly IPageService pages;

        public ArticlesController(IArticleService articles, IHtmlService html, IPageService pages)
        {
            this.articles = articles;
            this.html = html;
            this.pages = pages;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Articles(int page = 1)
        {
            var totalPages = this.pages.TotalPages(articles.TotalAsync);

            if (page > totalPages || page <= 0)
            {
                return this.RedirectToAction(nameof(this.Articles));
            }

            return this.View(new ArticleListingViewModel
            {
                Articles = await this.articles.AllArticlesAsync(CurrentCulture(), page),
                TotalPages = totalPages,
                CurrentPage = page
            });
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {            
            var article = await this.articles.Details(id);
            
            if (article != null)
            {
                return this.View(new ArticleViewModel
                {
                    Article = article
                });
            }

            return this.RedirectToAction(nameof(this.Articles));
        }

        public IActionResult Create()
            => this.View();

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Create(ArticleFormModel model)
        {
            model.Description = this.html.Sanitize(model.Description);

            if (model.Files == null || model.Files.Count == 0)
            {
                return Content(NoSelectedFiles);
            }

            var gallery = new List<string>();

            foreach (var file in model.Files)
            {
                var path = Path.Combine(ImageFolderName, GalleriesImageFolderName, Guid.NewGuid() + file.GetFileType());
                var pathForUpload = Path.Combine(Directory.GetCurrentDirectory(), RootFolderName, path);

                using (var stream = new FileStream(pathForUpload, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                path = path.Replace("\\", "/");
                gallery.Add(String.Format(SavePath,path));
            }

            await this.articles.CreateAsync(
                model.Title,
                model.Description,
                model.ReleaseDate,
                model.Author,
                model.AddGallery,
                gallery,
                model.Language,
                model.ShowAtFrontPage
              );

            this.TempData.AddSuccessMessage(string.Format(TempDataCreateCommentText, ModelName, EndingLetterA));

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
                Language = article.Language,
                ShowAtFrontPage = article.ShowAtFrontPage
            });
        }

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Edit(int id, ArticleFormModel model)
        {
            model.Description = this.html.Sanitize(model.Description);

            await this.articles.EditAsync(
                id,
                model.Title,
                model.Description,
                model.ReleaseDate,
                model.Author,
                model.Language,
                model.ShowAtFrontPage
                );

            this.TempData.AddSuccessMessage(string.Format(TempDataEditCommentText, ModelName, EndingLetterA));

            return this.RedirectToAction(nameof(this.Articles));
        }

        public IActionResult Delete(ArticleDeleteViewModel model)
            => this.View(model);

        public async Task<IActionResult> Destroy(int id)
        {
            await this.articles.DeleteAsync(id);

            this.TempData.AddSuccessMessage(string.Format(TempDataDeleteCommentText, ModelName, EndingLetterA));

            return this.RedirectToAction(nameof(this.Articles));
        }

        private string CurrentCulture()
            => CultureInfo.CurrentCulture.Name;
    }
}