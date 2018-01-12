using System;
using System.IO;
using System.Linq;


namespace Library.Web.Areas.LibraryBlog.Controllers
{
    using Services.LibraryBlog;
    using System.Threading.Tasks;
    using Models.Books;
    using Infrastructure.Extensions;
    using Infrastructure.Filters;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;


    public class BooksController : BaseController
    {
        private const string ModelName = "Книгата";

        private readonly IBookService books;

        public BooksController(IBookService books)
        {
            this.books = books;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Books(int page = 1)
        => this.View(new BookListingViewModel
        {
            Books = await this.books.AllBooksAsync(page),
            TotalBooks = await this.books.TotalAsync(),
            CurrentPage = page
        });

        [AllowAnonymous]
        public async Task<IActionResult> BooksForKids(int page = 1)
            => this.View(new BookListingViewModel
            {
                Books = await this.books.AllBooksForChildrenAsync(page),
                TotalBooks = await this.books.TotalForKidsAsync(),
                CurrentPage = page
            });

        [AllowAnonymous]
        public async Task<IActionResult> BooksForLand(int page = 1)
            => this.View(new BookListingViewModel
            {
                Books = await this.books.AllBooksForLandLandAsync(page),
                TotalBooks = await this.books.TotalForLandAsync(),
                CurrentPage = page
            });

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
            => this.View(new BookViewModel
            {
                Book = await this.books.ByIdAsync(id)
            });


        public IActionResult Create()
            => this.View();

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Create(BookFormModel model)
        {
            if (await this.books.UniqueCheckAsync(model.BookTitle, model.AuthorLastName))
            {
                this.TempData.AddWarningMessage(string.Format(WebConstants.TempDataAlreadyExistsText, ModelName, model.BookTitle));

                return this.RedirectToAction(nameof(this.Create));
            }

            var startupPath = Path.GetFullPath(".\\");
            var guid = Guid.NewGuid();
            var filePath = $"{startupPath}\\wwwroot\\images\\BookCovers\\{guid}.jpg";

            if (!ImageDownloaderExtensions.Download(model.ImageUrl, filePath))
            {
                this.TempData.AddWarningMessage(string.Format(WebConstants.TempDataWrongUrlText, ModelName));
                return this.RedirectToAction(nameof(this.Create));
            }

            var savePath = $"/images/BookCovers/{guid}.jpg";

            await this.books.CreateAsync(
                model.AuthorFirstName,
                model.AuthorLastName,
                model.BookTitle,
                model.BookDescription,
                model.CityIssued,
                model.Press,
                model.Department,
                model.PublishDate,
                DateTime.UtcNow,
                model.Pages,
                model.Size,
                model.Genre,
                savePath);

            this.TempData.AddSuccessMessage(string.Format(WebConstants.TempDataCreateCommentText, ModelName, "a"));

            return this.RedirectToAction(nameof(this.Books));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var book = await this.books.ByIdAsync(id);

            if (book == null)
            {
                return this.NotFound();
            }

            return this.View(new BookFormModel
            {
                AuthorFirstName = book.AuthorFirstName,
                AuthorLastName = book.AuthorLastName,
                BookTitle = book.BookTitle,
                BookDescription = book.BookDescription,
                CityIssued = book.CityIssued,
                Press = book.Press,
                Department = book.Department,
                PublishDate = book.PublishDate,
                Pages = book.Pages,
                Size = book.Size,
                Genre = book.Genre,
            });
        }

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Edit(int id, BookFormModel model)
        {
            string savePath = null;

            if (model.ImageUrl != null)
            {
                var startupPath = Path.GetFullPath(".\\");
                var guid = Guid.NewGuid();
                var filePath = $"{startupPath}\\wwwroot\\images\\BookCovers\\{guid}.jpg";
                if (!ImageDownloaderExtensions.Download(model.ImageUrl, filePath))
                {
                    this.TempData.AddWarningMessage(string.Format(WebConstants.TempDataWrongUrlText, ModelName));

                    return this.RedirectToAction(nameof(this.Create));
                }

                savePath = $"/images/BookCovers/{guid}.jpg";
            }

            await this.books.EditAsync(
                id,
                model.AuthorFirstName,
                model.AuthorLastName,
                model.BookTitle,
                model.BookDescription,
                model.CityIssued,
                model.Press,
                model.Department,
                model.PublishDate,
                model.Pages,
                model.Size,
                model.Genre,
                savePath);

            this.TempData.AddSuccessMessage(string.Format(WebConstants.TempDataEditCommentText, ModelName, "a"));

            return this.RedirectToAction(nameof(this.Books));
        }

        public IActionResult Delete(int id)
            => this.View(id);

        public async Task<IActionResult> Destroy(int id)
        {
            await this.books.DeleteAsync(id);

            this.TempData.AddSuccessMessage(string.Format(WebConstants.TempDataDeleteCommentText, ModelName, "a"));

            return this.RedirectToAction(nameof(this.Books));
        }
    }
}
