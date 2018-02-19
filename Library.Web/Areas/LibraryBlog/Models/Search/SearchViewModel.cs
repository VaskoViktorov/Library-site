namespace Library.Web.Areas.LibraryBlog.Models.Search
{
    using Services.LibraryBlog.Models.Articles;
    using Services.LibraryBlog.Models.Books;
    using Services.LibraryBlog.Models.Galleries;
    using Services.LibraryBlog.Models.Subscriptions;
    using System.Collections.Generic;

    public class SearchViewModel : SearchFormModel
    {
        public string SearchedText { get; set; }

        public IEnumerable<BookListingServiceModel> SearchInBook { get; set; }

        public IEnumerable<ArticleListingServiceModel> SearchInArticle { get; set; }

        public IEnumerable<GalleryServiceModel> SearchInGallery { get; set; }

        public IEnumerable<SubscriptionListingServiceModel> SearchInSubscription { get; set; }
    }
}
