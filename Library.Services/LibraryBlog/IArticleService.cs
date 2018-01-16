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
            DepartmentType type, string authorName, List<string> gallery);

        Task EditAsync(int id, string title, string description, DateTime releaseDate,
            DepartmentType type, string authorName);

        Task DeleteAsync(int id);

        Task<ArticleServiceModel> ByIdAsync(int id);

        Task<IEnumerable<ArticleListingServiceModel>> AllArticlesAsync(int page = 1);

        Task<int> TotalAsync();

        Task<ArticleServiceModel> Details(int id);
    }
}
