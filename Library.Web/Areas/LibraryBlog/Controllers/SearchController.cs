namespace Library.Web.Areas.LibraryBlog.Controllers
{
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models.Search;
    using Services.LibraryBlog;
    using System.Globalization;
    using System.Threading.Tasks;

    using static WebConstants;

    public class SearchController : BaseController
    {
        private readonly ISearchService searches;

        public SearchController(ISearchService searches)
        {
            this.searches = searches;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Search(string searchText, bool searchInBooks,
            bool searchInArticles, bool searchInGalleries, bool searchInSubscriptions)
        {
            if (StringExtensions.IsNullOrWhiteSpace(searchText))
            {
                this.TempData.AddWarningMessage(TempDataSearchEmtyTextMessage);

                return this.RedirectToAction("Index", "Home", new { area = "" });
            }

            if (!searchInBooks && !searchInArticles && !searchInGalleries & !searchInSubscriptions)
            {
                this.TempData.AddWarningMessage(TempDataSearchNoSelectMessage);

                return this.RedirectToAction("Index", "Home", new { area = "" });
            }

            var viewModel = new SearchViewModel
            {
                SearchedText = searchText,
                SearchInBook = await this.searches.FindBooksAsync(
                    CurrentCulture(),
                   searchText,
                    searchInBooks),
                SearchInArticle = await this.searches.FindArticlesAsync(
                    CurrentCulture(),
                    searchText,
                    searchInArticles),
                SearchInGallery = await this.searches.FindGalleriesAsync(
                    CurrentCulture(),
                    searchText,
                    searchInGalleries),
                SearchInSubscription = await this.searches.FindSubscriptionsAsync(
                    CurrentCulture(),
                    searchText,
                    searchInSubscriptions)
            };

            return this.View(viewModel);
        }


        private string CurrentCulture()
            => CultureInfo.CurrentCulture.Name;
    }
}