namespace Library.Web.Areas.En.Controllers
{
    using LibraryBlog.Models.Articles;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.LibraryBlog;
    using System.Threading.Tasks;

    [Area(WebConstants.EnglishAreaName)]
    public class ArticlesController : Controller
    {
        private readonly IArticleService articles;

        public ArticlesController(IArticleService articles)
        {
            this.articles = articles;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Articles(int page = 1)
            => this.View(new ArticleListingViewModel
            {
                Articles = await this.articles.AllArticlesEnAsync(page),
                TotalArticles = await this.articles.TotalEnAsync(),
                CurrentPage = page
            });

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
            => this.View(new ArticleViewModel
            {
                Article = await this.articles.Details(id)
            });
    }
}