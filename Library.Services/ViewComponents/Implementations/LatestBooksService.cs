using Library.Data.Models;

namespace Library.Services.ViewComponents.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Models.LatestBooks;
    using Microsoft.EntityFrameworkCore;

    using static ServicesConstants;

    public class LatestBooksService : ILatestBooksService
   {
       private readonly LibraryDbContext db;

       public LatestBooksService(LibraryDbContext db)
       {
           this.db = db;
       }

       public async Task<IEnumerable<LatestBookServiceModel>> LatestBooks()
           => await this.db
               .Books
               .OrderByDescending(b => b.Id)
               .Where(b => b.ImageUrl != "\\images\\BookCovers\\default.jpg" && b.Language == Language.Bg)
               .Take(LatestBooksAmount)
               .ProjectTo<LatestBookServiceModel>()
               .ToListAsync();

       public async Task<IEnumerable<LatestBookServiceModel>> LatestBooksEn()
           => await this.db
               .Books
               .OrderByDescending(b => b.Id)
               .Where(b => b.ImageUrl != "\\images\\BookCovers\\default-en.jpg" && b.Language == Language.En)
               .Take(LatestBooksAmount)
               .ProjectTo<LatestBookServiceModel>()
               .ToListAsync();
    }
}
