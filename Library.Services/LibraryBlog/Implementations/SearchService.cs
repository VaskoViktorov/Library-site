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
    using Common.Infrastructure;
    using Data.Models;

    public class SearchService : ISearchService
    {
        private readonly LibraryDbContext db;

        public SearchService(LibraryDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<BookListingServiceModel>> FindBooksAsync(string language, string searchText, bool searchInBooks)
        {
            if (!searchInBooks)
            {
                return null;
            }

            return await this.db
                  .Books
                  .Where(b => b.BookTitle.ToLower().Contains(searchText) && b.Language == (Language)language.ParseLang())
                  .ProjectTo<BookListingServiceModel>()
                  .ToListAsync();
        }

        public async Task<IEnumerable<ArticleListingServiceModel>> FindArticlesAsync(string language, string searchText, bool searchInArticles)
        {
            if (!searchInArticles)
            {
                return null;
            }

            return await this.db
                .Articles
                .Where(a => a.Language == (Language)language.ParseLang())
                .Where(a => a.Title.ToLower().Contains(searchText) || a.AuthorName.ToLower().Contains(searchText))
                .ProjectTo<ArticleListingServiceModel>()
                .ToListAsync();
        }

        public async Task<IEnumerable<GalleryServiceModel>> FindGalleriesAsync(string language, string searchText, bool searchInGalleries)
        {
            if (!searchInGalleries)
            {
                return null;
            }

            return await this.db
                .Galleries
                .Where(g => g.Title.ToLower().Contains(searchText) && g.Images.Count >1 && g.Language == (Language)language.ParseLang())
                .ProjectTo<GalleryServiceModel>()
                .ToListAsync();
        }

        public async Task<IEnumerable<SubscriptionListingServiceModel>> FindSubscriptionsAsync(string language, string searchText, bool searchInSubscriptions)
        {
            if (!searchInSubscriptions)
            {
                return null;
            }

            return await this.db
                .Subscriptions
                .Where(s => s.Name.ToLower().Contains(searchText) && s.Language == (Language)language.ParseLang())
                .ProjectTo<SubscriptionListingServiceModel>()
                .ToListAsync();
        }
    }
}
