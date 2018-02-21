namespace Library.Services.LibraryBlog
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models.Articles;
    using Models.Books;
    using Models.Galleries;
    using Models.Subscriptions;

    public interface ISearchService
    {
        Task<IEnumerable<BookListingServiceModel>> FindBooksAsync(string language, string modelSearchText, bool modelSearchInBooks);

        Task<IEnumerable<ArticleListingServiceModel>> FindArticlesAsync(string language, string modelSearchText, bool modelSearchInArticles);

        Task<IEnumerable<GalleryServiceModel>> FindGalleriesAsync(string language, string modelSearchText, bool modelSearchInGalleries);

        Task<IEnumerable<SubscriptionListingServiceModel>> FindSubscriptionsAsync(string language, string modelSearchText, bool modelSearchInSubscriptions);
    }
}
