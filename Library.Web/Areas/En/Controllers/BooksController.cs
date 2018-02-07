namespace Library.Web.Areas.En.Controllers
{
    using LibraryBlog.Models.Books;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.LibraryBlog;
    using System.Threading.Tasks;

    using static WebConstants;

    [Area(EnglishAreaName)]
    public class BooksController : Controller
    {
        private readonly IBookService books;

        public BooksController(IBookService books)
        {
            this.books = books;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Books(int page = 1)
        => this.View(new BookListingViewModel
        {
            Books = await this.books.AllBooksEnAsync(page),
            TotalBooks = await this.books.TotalEnAsync(),
            CurrentPage = page
        });

        [AllowAnonymous]
        public async Task<IActionResult> BooksForKids(int page = 1)
            => this.View(new BookListingViewModel
            {
                Books = await this.books.AllBooksForChildrenEnAsync(page),
                TotalBooks = await this.books.TotalForKidsEnAsync(),
                CurrentPage = page
            });

        [AllowAnonymous]
        public async Task<IActionResult> BooksForLand(int page = 1)
            => this.View(new BookListingViewModel
            {
                Books = await this.books.AllBooksForLandEnAsync(page),
                TotalBooks = await this.books.TotalForLandEnAsync(),
                CurrentPage = page
            });

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
            => this.View(new BookViewModel
            {
                Book = await this.books.ByIdAsync(id)
            });
    }
}