namespace Library.Web.Areas.LibraryBlog.Controllers
{
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

        public ArticlesController(IArticleService articles)
        {
            this.articles = articles;
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
                Article = await this.articles.ByIdAsync(id)
            });


        public IActionResult Create()
            => this.View();

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Create(ArticleFormModel model)
        {
            var userName = User.Identity.Name;

            await this.articles.CreateAsync(
                model.Title,
                model.Description,
                model.ReleaseDate,
                model.Type,
                userName
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
                Type = article.Type
            });
        }

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Edit(int id, ArticleFormModel model)
        {

            var userName = User.Identity.Name;

            await this.articles.EditAsync(
                id,
                model.Title,
                model.Description,
                model.ReleaseDate,
                model.Type,
                userName
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
