namespace Library.Services.LibraryBlog.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Common.Infrastructure;
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
            string authorName,bool addGallery, List<string> gallery, Language language, bool showAtFrontPage)
        {
            var galleryy = new Gallery()
            {
                Title = title,
                Language = language,
                Show = addGallery
            };

            foreach (var path in gallery)
            {
                var image = new Image()
                {
                    ImagePath = path
                };

                this.db.Add(image);

                galleryy.Images.Add(image);
            }
            
            var article = new Article
            {
                Title = title,
                Description = description,
                ReleaseDate = releaseDate,
                CreateDate = DateTime.UtcNow,
                AuthorName = authorName,
                Gallery = galleryy,
                Language = language,
                ShowAtFrontPage = showAtFrontPage
            };

            this.db.Add(article);

            await this.db.SaveChangesAsync();
        }

        public async Task EditAsync(int id, string title, string description, DateTime releaseDate,
            string authorName, Language language, bool showAtFrontPage)
        {
            var article = await this.db.Articles.FindAsync(id);

            if (article == null)
            {
                return;
            }

            article.Title = title;
            article.Description = description;
            article.ReleaseDate = releaseDate;
            article.AuthorName = authorName;
            article.Language = language;
            article.ShowAtFrontPage = showAtFrontPage;

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

            var gallery = await this.db.Galleries.FindAsync(article.Gallery.Id);
                  
            this.db.Articles.Remove(article);    
            this.db.Galleries.Remove(gallery);

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

            if (article == null)
            {
                return null;
            }

            await LoadImages(article.Gallery.Id);

            return article;
        }

        public async Task<IEnumerable<ArticleListingServiceModel>> AllArticlesAsync(string language, int page = 1)
        {
            var articles = await this.db
                .Articles
                .Where(a => a.Language == (Language)language.ParseLang())
                .OrderByDescending(a => a.ReleaseDate)
                .ThenByDescending(a => a.CreateDate)
                .Skip((page - 1) * ArticlesPageSize)
                .Take(ArticlesPageSize)
                .ProjectTo<ArticleListingServiceModel>()
                .ToListAsync();

            await this.db
                .Images
                .ToListAsync();

            return articles;
        }

        public async Task<int> TotalAsync(string language)
            => await this.db
                .Articles
                .Where(a => a.Language == (Language)language.ParseLang())
                .CountAsync();

        private async Task LoadImages(int id)
            => await this.db
                .Images
                .Where(i => i.GalleryId == id)
                .ToListAsync();
    }
}