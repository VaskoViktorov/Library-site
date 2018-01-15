namespace Library.Services.LibraryBlog.Implementations
{
    using Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using Data.Models;
    using Models.Articles;
    using Microsoft.EntityFrameworkCore;

    using static ServicesConstants;

    public class ArticleService : IArticleService
    {
        private readonly LibraryDbContext db;

        public ArticleService(LibraryDbContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(string title, string description, DateTime releaseDate,
             DepartmentType type, string authorName)
        {
            var article = new Article
            {               
                Title = title,
                Description = description,               
                ReleaseDate = releaseDate,
                CreateDate = DateTime.UtcNow,
                Type = type,
                AuthorName = authorName,
                
            };

            this.db.Add(article);
            await this.db.SaveChangesAsync();
        }

        public async Task EditAsync(int id, string title, string description, DateTime releaseDate,
            DepartmentType type, string authorName)
        {
            var article = await this.db.Articles.FindAsync(id);

            if (article == null)
            {
                return;
            }

            article.Title = title;
            article.Description = description;
            article.ReleaseDate = releaseDate;
            article.Type = type;
            article.AuthorName = authorName;
            
            await this.db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var article = await this.db.Articles.FindAsync(id);

            if (article == null)
            {
                return;
            }
            this.db.Articles.Remove(article);

            await this.db.SaveChangesAsync();
        }

        public async Task<ArticleServiceModel> ByIdAsync(int id)
            => await this.db
                .Articles
                .Where(a => a.Id == id)
                .ProjectTo<ArticleServiceModel>()
                .FirstOrDefaultAsync();

        public async Task<IEnumerable<ArticleListingServiceModel>> AllArticlesAsync(int page = 1)
            => await this.db
                .Articles
                .OrderBy(b => b.ReleaseDate)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ProjectTo<ArticleListingServiceModel>()
                .ToListAsync();

        public async Task<int> TotalAsync()
            => await this.db
                .Articles
                .CountAsync();
    }
}
