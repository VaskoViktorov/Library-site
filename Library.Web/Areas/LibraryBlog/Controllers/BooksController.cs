namespace Library.Web.Areas.LibraryBlog.Controllers
{
    using Infrastructure.Extensions;
    using Infrastructure.Filters;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models.Books;
    using Services.Html;
    using Services.LibraryBlog;
    using System;
    using System.IO;
    using System.Threading.Tasks;

    public class BooksController : BaseController
    {
        private const string ModelName = "Книгата";

        private readonly IBookService books;
        private readonly IHtmlService html;

        public BooksController(IBookService books, IHtmlService html)
        {
            this.books = books;
            this.html = html;
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
            if (await this.books.UniqueCheckAsync(model.BookTitle, model.AuthorName))
            {
                this.TempData.AddWarningMessage(string.Format(WebConstants.TempDataAlreadyExistsText, ModelName, model.BookTitle));

                return this.RedirectToAction(nameof(this.Create));
            }

            model.BookDescription = this.html.Sanitize(model.BookDescription);

            string savePath = null;

            if (model.ImageUrl != null)
            {
                var guid = Guid.NewGuid();
                var filePath = $"{Directory.GetCurrentDirectory()}\\wwwroot\\images\\BookCovers\\{guid}.jpg";

                if (!ImageDownloaderExtensions.Download(model.ImageUrl, filePath))
                {
                    this.TempData.AddWarningMessage(string.Format(WebConstants.TempDataWrongUrlText, ModelName));
                    return this.RedirectToAction(nameof(this.Create));
                }

                savePath = $"\\images\\BookCovers\\{guid}.jpg";
            }
            else
            {
                savePath = $"\\images\\BookCovers\\default.jpg";
            }

            await this.books.CreateAsync(
                model.AuthorName,
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
                savePath,
                model.Language);

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
                AuthorName = book.AuthorName,
                BookTitle = book.BookTitle,
                BookDescription = book.BookDescription,
                CityIssued = book.CityIssued,
                Press = book.Press,
                Department = book.Department,
                PublishDate = book.PublishDate,
                Pages = book.Pages,
                Size = book.Size,
                Genre = book.Genre,
                Language = book.Language
            });
        }

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Edit(int id, BookFormModel model)
        {
            string savePath = null;

            if (model.ImageUrl != null)
            {
                var guid = Guid.NewGuid();
                var filePath = $"{Directory.GetCurrentDirectory()}\\wwwroot\\images\\BookCovers\\{guid}.jpg";

                if (!ImageDownloaderExtensions.Download(model.ImageUrl, filePath))
                {
                    this.TempData.AddWarningMessage(string.Format(WebConstants.TempDataWrongUrlText, ModelName));

                    return this.RedirectToAction(nameof(this.Create));
                }

                savePath = $"/images/BookCovers/{guid}.jpg";
            }

            model.BookDescription = this.html.Sanitize(model.BookDescription);

            await this.books.EditAsync(
                id,
                model.AuthorName,
                model.BookTitle,
                model.BookDescription,
                model.CityIssued,
                model.Press,
                model.Department,
                model.PublishDate,
                model.Pages,
                model.Size,
                model.Genre,
                savePath,
                model.Language);

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