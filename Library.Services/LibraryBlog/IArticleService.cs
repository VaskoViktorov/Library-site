namespace Library.Services.LibraryBlog
{
    using System.Collections.Generic;
    using Models.Articles;
    using Data.Models;
    using System;
    using System.Threading.Tasks;

    public interface IArticleService
    {
        Task CreateAsync(string title, string description, DateTime releaseDate,
            DepartmentType type, string authorName, List<string> gallery, Language language);

        Task EditAsync(int id, string title, string description, DateTime releaseDate,
            DepartmentType type, string authorName, Language language);

        Task DeleteAsync(int id);

        Task<ArticleServiceModel> ByIdAsync(int id);

        Task<IEnumerable<ArticleListingServiceModel>> AllArticlesAsync(int page = 1);

        Task<int> TotalAsync();

        Task<IEnumerable<ArticleListingServiceModel>> AllArticlesEnAsync(int page = 1);

        Task<int> TotalEnAsync();

        Task<ArticleServiceModel> Details(int id);
    }
}
