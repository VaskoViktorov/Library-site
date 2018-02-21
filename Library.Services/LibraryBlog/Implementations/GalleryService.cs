using Library.Common.Infrastructure;

namespace Library.Services.LibraryBlog.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Common.Infrastructure.Extensions;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Models.Galleries;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using static ServicesConstants;

    public class GalleryService : IGalleryService
    {
        private readonly LibraryDbContext db;

        public GalleryService(LibraryDbContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(string title, List<string> gallery, Language language)
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
                    ImagePath = path
                };

                this.db.Add(image);
                galleryy.Images.Add(image);
            }

            this.db.Galleries.Add(galleryy);
            await this.db.SaveChangesAsync();
        }

        public async Task EditAsync(int id, string title, Language language)
        {
            var gallery = await this.db.Galleries.FindAsync(id);

            if (gallery == null)
            {
                return;
            }

            gallery.Title = title;
            gallery.Language = language;

            await this.db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var gallery = await this.db.Galleries.FindAsync(id);

            if (gallery == null)
            {
                return;
            }

            this.db.Galleries.Remove(gallery);
            await this.db.SaveChangesAsync();

            foreach (var img in gallery.Images)
            {
                FileExtensions.DeleteImage(img.ImagePath);
            }
        }

        public async Task<GalleryServiceModel> ByIdAsync(int id)
            => await this.db
                .Galleries
                .Where(a => a.Id == id)
                .ProjectTo<GalleryServiceModel>()
                .FirstOrDefaultAsync();

        public async Task<GalleryServiceModel> Details(int id)
        {
            var gallery = await this.db
                .Galleries
                .Where(a => a.Id == id)
                .ProjectTo<GalleryServiceModel>()
                .FirstOrDefaultAsync();

            await LoadImages(gallery.Id);

            return gallery;
        }

        public async Task<IEnumerable<GalleryServiceModel>> AllGalleriesAsync(string language, int page = 1)
        {
            var gallery = await this.db
                .Galleries
                .Where(g => g.Images.Count > 1 && g.Language == (Language)language.ParseLang())
                .OrderByDescending(b => b.Id)
                .Skip((page - 1) * GalleriesPageSize)
                .Take(GalleriesPageSize)
                .ProjectTo<GalleryServiceModel>()
                .ToListAsync();

            await this.db
                .Images
                .ToListAsync();

            return gallery;
        }

        public async Task<int> TotalAsync(string language)
            => await this.db
                .Galleries
                .Where(g => g.Images.Count > 1 && g.Language == (Language)language.ParseLang())
                .CountAsync();

        public async Task<IEnumerable<GalleryServiceModel>> AllGalleriesEnAsync(int page = 1)
        {
            var gallery = await this.db
                .Galleries
                .Where(g => g.Images.Count > 1 && g.Language == Language.En)
                .OrderByDescending(b => b.Id)
                .Skip((page - 1) * GalleriesPageSize)
                .Take(GalleriesPageSize)
                .ProjectTo<GalleryServiceModel>()
                .ToListAsync();

            await this.db
                .Images
                .ToListAsync();

            return gallery;
        }

        public async Task<int> TotalEnAsync()
            => await this.db
                .Galleries
                .Where(g => g.Images.Count > 1 && g.Language == Language.En)
                .CountAsync();


        private async Task LoadImages(int id)
            => await this.db
                .Images
                .Where(i => i.GalleryId == id)
                .ToListAsync();
    }
}