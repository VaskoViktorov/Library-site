using AutoMapper.QueryableExtensions;
namespace Library.Services.ViewComponents.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Models.LatestGalleries;
    using static ServicesConstants;

    public class LatestGalleriesService : ILatestGalleriesService
    {
        private readonly LibraryDbContext db;

        public LatestGalleriesService(LibraryDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<LatestGalleriesServiceModel>> LatestGalleries()
            => await this.db
                .Galleries
                .OrderByDescending(b => b.Id)
                .Where(g => g.Images.Count > 1)
                .Take(LatestGalleriesAmount)
                .ProjectTo<LatestGalleriesServiceModel>()
                .ToListAsync();
    }
}
