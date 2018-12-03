namespace Library.Services.ViewComponents.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Common.Infrastructure;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Models.LatestBooks;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using static ServicesConstants;

    public class LatestBooksService : ILatestBooksService
    {
        private readonly LibraryDbContext db;

        public LatestBooksService(LibraryDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<LatestBookServiceModel>> LatestBooks(string language)
            => await this.db
                .Books
                .OrderByDescending(b => b.Id)
                .Where(b => b.ImageUrl != DefaultBookCoverImagePathBg && b.Language == (Language)language.ParseLang())
                .Take(LatestBooksAmount)
                .ProjectTo<LatestBookServiceModel>()
                .ToListAsync();

        public async Task<IEnumerable<LatestBookServiceModel>> LatestBooksEn()
            => await this.db
                .Books
                .OrderByDescending(b => b.Id)
                .Where(b => b.ImageUrl != DefaultBookCoverEn && b.Language == Language.En)
                .Take(LatestBooksAmount)
                .ProjectTo<LatestBookServiceModel>()
                .ToListAsync();
    }
}