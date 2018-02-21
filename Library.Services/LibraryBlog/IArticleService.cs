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
            DepartmentType type, 
            string authorName, 
            List<string> gallery, 
            Language language);

        Task EditAsync(
            int id,
            string title,
            string description,
            DateTime releaseDate,
            DepartmentType type,
            string authorName,
            Language language);

        Task DeleteAsync(int id);

        Task<ArticleServiceModel> ByIdAsync(int id);

        Task<IEnumerable<ArticleListingServiceModel>> AllArticlesAsync(string language, int page = 1);

        Task<int> TotalAsync(string language);

        Task<ArticleServiceModel> Details(int id);

        //English

        Task<IEnumerable<ArticleListingServiceModel>> AllArticlesEnAsync(int page = 1);

        Task<int> TotalEnAsync();
    }
}