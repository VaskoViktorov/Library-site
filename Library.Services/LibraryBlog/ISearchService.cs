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
        Task<IEnumerable<BookListingServiceModel>> FindBooksAsync(string modelSearchText, bool modelSearchInBooks);

        Task<IEnumerable<ArticleListingServiceModel>> FindArticlesAsync(string modelSearchText, bool modelSearchInArticles);

        Task<IEnumerable<GalleryServiceModel>> FindGalleriesAsync(string modelSearchText, bool modelSearchInGalleries);

        Task<IEnumerable<SubscriptionListingServiceModel>> FindSubscriptionsAsync(string modelSearchText, bool modelSearchInSubscriptions);
    }
}
