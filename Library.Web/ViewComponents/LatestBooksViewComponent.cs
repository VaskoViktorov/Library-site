using System.Linq;
namespace Library.Web.ViewComponents
{
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;


    public class LatestBooksViewComponent : ViewComponent
    {
        private readonly LibraryDbContext db;

        public LatestBooksViewComponent(LibraryDbContext db)
        {
            this.db = db;
        }
        public async Task<IViewComponentResult> InvokeAsync(int howMany = 3)
        {
            var books = await db.Books
                .OrderByDescending(b => b.Date)
                .Take(howMany)
                .ToListAsync();
            return View(books);
        }
    }

}
