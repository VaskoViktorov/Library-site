namespace Library.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Models.Home;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class HomeService : IHomeService
    {
        private readonly LibraryDbContext db;

        public HomeService(LibraryDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<ArticleListingHomeServiceModel>> LatestFourArticlesAsync()
        {
            var articles = await this.db
                .Articles
                .Where(a => a.Language == Language.Bg)
                .OrderByDescending(a => a.ReleaseDate)
                .Take(4)
                .ProjectTo<ArticleListingHomeServiceModel>()
                .ToListAsync();

            await this.db
                .Images
                .ToListAsync();

            return articles;
        }

        public async Task<IEnumerable<ArticleListingHomeServiceModel>> LatestFourArticlesEnAsync()
        {
            var articles = await this.db
                .Articles
                .Where(a => a.Language == Language.En)
                .OrderByDescending(a => a.ReleaseDate)
                .Take(4)
                .ProjectTo<ArticleListingHomeServiceModel>()
                .ToListAsync();

            await this.db
                .Images
                .ToListAsync();

            return articles;
        }
    }
}
