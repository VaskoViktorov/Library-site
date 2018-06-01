namespace Library.Services.LibraryBlog
{
    using Data.Models;
    using Models.Articles;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IArticleService
    {
        Task CreateAsync(
            string title,
            string description,
            DateTime releaseDate,
            string authorName,
            bool addGallery,
            List<string> gallery,
            Language language,
            bool showAtFrontPage);

        Task EditAsync(
            int id,
            string title,
            string description,
            DateTime releaseDate,
            string authorName,
            Language language,
            bool showAtFrontPage);

        Task DeleteAsync(int id);

        Task<ArticleServiceModel> ByIdAsync(int id);

        Task<IEnumerable<ArticleListingServiceModel>> AllArticlesAsync(string language, int page = 1);

        Task<int> TotalAsync(string language);

        Task<ArticleServiceModel> Details(int id);
    }
}