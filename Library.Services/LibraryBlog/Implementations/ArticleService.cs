namespace Library.Services.LibraryBlog.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Common.Infrastructure.Extensions;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Models.Articles;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using static ServicesConstants;

    public class ArticleService : IArticleService
    {
        private readonly LibraryDbContext db;

        public ArticleService(LibraryDbContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(string title, string description, DateTime releaseDate,
             DepartmentType type, string authorName, List<string> gallery, Language language)
        {
            var galleryy = new Gallery()
            {
                Title = title,
                Language = language
            };

            foreach (var path in gallery)
            {
                var image = new Image()
                {
                    ImagePath = path,
                };

                this.db.Add(image);

                galleryy.Images.Add(image);
            }

            this.db.Add(galleryy);

            var article = new Article
            {
                Title = title,
                Description = description,
                ReleaseDate = releaseDate,
                CreateDate = DateTime.UtcNow,
                Type = type,
                AuthorName = authorName,
                Gallery = galleryy,
                Language = language
            };

            this.db.Add(article);

            await this.db.SaveChangesAsync();
        }

        public async Task EditAsync(int id, string title, string description, DateTime releaseDate,
            DepartmentType type, string authorName, Language language)
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
            article.Language = language;

            await this.db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var article = await this.db.Articles.FindAsync(id);

            if (article == null)
            {
                return;
            }

            await this.db.Galleries.ToListAsync();

            await LoadImages(article.Gallery.Id);

            this.db.Articles.Remove(article);

            await this.db.SaveChangesAsync();

            foreach (var img in article.Gallery.Images)
            {
                FileExtensions.DeleteImage(img.ImagePath);
            }
        }

        public async Task<ArticleServiceModel> ByIdAsync(int id)
            => await this.db
                .Articles
                .Where(a => a.Id == id)
                .ProjectTo<ArticleServiceModel>()
                .FirstOrDefaultAsync();

        public async Task<ArticleServiceModel> Details(int id)
        {
            var article = await this.db
                .Articles
                .Where(a => a.Id == id)
                .ProjectTo<ArticleServiceModel>()
                .FirstOrDefaultAsync();

            await LoadImages(article.Gallery.Id);

            return article;
        }

        public async Task<IEnumerable<ArticleListingServiceModel>> AllArticlesAsync(int page = 1)
        {
            var articles = await this.db
                .Articles
                .Where(a => a.Language == Language.Bg)
                .OrderByDescending(b => b.ReleaseDate)
                .Skip((page - 1) * ArticlesPageSize)
                .Take(ArticlesPageSize)
                .ProjectTo<ArticleListingServiceModel>()
                .ToListAsync();

            await this.db
                .Images
                .ToListAsync();

            return articles;
        }

        public async Task<int> TotalAsync()
            => await this.db
                .Articles
                .Where(a => a.Language == Language.Bg)
                .CountAsync();

        public async Task<IEnumerable<ArticleListingServiceModel>> AllArticlesEnAsync(int page = 1)
        {
            var articles = await this.db
                .Articles
                .Where(a => a.Language == Language.En)
                .OrderByDescending(b => b.ReleaseDate)
                .Skip((page - 1) * ArticlesPageSize)
                .Take(ArticlesPageSize)
                .ProjectTo<ArticleListingServiceModel>()
                .ToListAsync();

            await this.db
                .Images
                .ToListAsync();

            return articles;
        }

        public async Task<int> TotalEnAsync()
            => await this.db
                .Articles
                .Where(a => a.Language == Language.En)
                .CountAsync();

        private async Task LoadImages(int id)
            => await this.db
                .Images
                .Where(i => i.GalleryId == id)
                .ToListAsync();
    }
}