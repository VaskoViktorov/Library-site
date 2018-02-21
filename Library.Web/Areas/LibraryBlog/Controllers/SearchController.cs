using System.Globalization;

namespace Library.Web.Areas.LibraryBlog.Controllers
{
    using System.Threading.Tasks;
    using Services.LibraryBlog;
    using Models.Search;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static WebConstants;

    public class SearchController : BaseController
    {
        private readonly ISearchService searches;

        public SearchController(ISearchService searches)
        {
            this.searches = searches;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Search(SearchFormModel model)
        {
            if (StringExtensions.IsNullOrWhiteSpace(model.SearchText))
            {
                this.TempData.AddWarningMessage(TempDataSearchEmtyTextMessage);

                return this.RedirectToAction("Index", "Home", new { area = "" });
            }

            if (!model.SearchInBooks && !model.SearchInArticles && !model.SearchInGalleries & !model.SearchInSubscriptions)
            {
                this.TempData.AddWarningMessage(TempDataSearchNoSelectMessage);

                return this.RedirectToAction("Index", "Home", new { area = "" });
            }

            var viewModel = new SearchViewModel
            {
                SearchedText = model.SearchText,
                SearchInBook = await this.searches.FindBooksAsync(
                    CurrentCulture(),
                    model.SearchText,
                    model.SearchInBooks),
                SearchInArticle = await this.searches.FindArticlesAsync(
                    CurrentCulture(),
                    model.SearchText,
                    model.SearchInArticles),
                SearchInGallery = await this.searches.FindGalleriesAsync(
                    CurrentCulture(),
                    model.SearchText,
                    model.SearchInGalleries),
                SearchInSubscription = await this.searches.FindSubscriptionsAsync(
                    CurrentCulture(),
                    model.SearchText,
                    model.SearchInSubscriptions)
            };

            return this.View(viewModel);
        }


        private string CurrentCulture()
            => CultureInfo.CurrentCulture.Name;
    }
}
