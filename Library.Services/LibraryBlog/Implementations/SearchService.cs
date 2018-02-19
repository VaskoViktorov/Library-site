namespace Library.Services.LibraryBlog.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using Models.Articles;
    using Models.Books;
    using Models.Galleries;
    using Models.Subscriptions;
    using Microsoft.EntityFrameworkCore;
    using Data;

    public class SearchService : ISearchService
    {
        private readonly LibraryDbContext db;

        public SearchService(LibraryDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<BookListingServiceModel>> FindBooksAsync(string searchText, bool searchInBooks)
        {
            if (!searchInBooks)
            {
                return null;
            }

            return await this.db
                  .Books
                  .Where(b => b.BookTitle.ToLower().Contains(searchText))
                  .ProjectTo<BookListingServiceModel>()
                  .ToListAsync();
        }

        public async Task<IEnumerable<ArticleListingServiceModel>> FindArticlesAsync(string searchText, bool searchInArticles)
        {
            if (!searchInArticles)
            {
                return null;
            }

            return await this.db
                .Articles
                .Where(a => a.Title.ToLower().Contains(searchText) || a.AuthorName.ToLower().Contains(searchText))
                .ProjectTo<ArticleListingServiceModel>()
                .ToListAsync();
        }

        public async Task<IEnumerable<GalleryServiceModel>> FindGalleriesAsync(string searchText, bool searchInGalleries)
        {
            if (!searchInGalleries)
            {
                return null;
            }

            return await this.db
                .Galleries
                .Where(g => g.Title.ToLower().Contains(searchText) && g.Images.Count >1)
                .ProjectTo<GalleryServiceModel>()
                .ToListAsync();
        }

        public async Task<IEnumerable<SubscriptionListingServiceModel>> FindSubscriptionsAsync(string searchText, bool searchInSubscriptions)
        {
            if (!searchInSubscriptions)
            {
                return null;
            }

            return await this.db
                .Subscriptions
                .Where(a => a.Name.ToLower().Contains(searchText))
                .ProjectTo<SubscriptionListingServiceModel>()
                .ToListAsync();
        }
    }
}
