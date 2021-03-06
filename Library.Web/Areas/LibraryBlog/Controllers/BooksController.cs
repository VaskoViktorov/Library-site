﻿namespace Library.Web.Areas.LibraryBlog.Controllers
{
    using Infrastructure.Extensions;
    using Infrastructure.Filters;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models.Books;
    using Services.Html;
    using Services.LibraryBlog;
    using Services.LibraryBlog.Models.Books;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Threading.Tasks;

    using static WebConstants;

    public class BooksController : BaseController
    {
        private const string ModelName = BookBgModelName;

        private readonly IBookService books;
        private readonly IHtmlService html;
        private readonly IPageService pages;

        public BooksController(IBookService books, IHtmlService html, IPageService pages)
        {
            this.books = books;
            this.html = html;
            this.pages = pages;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Books(int page = 1, string filter = BooksFilter)
        {
            int totalPages;
            IEnumerable<BookListingServiceModel> filterType;

            switch (filter)
            {
                case BooksForKidsFilter:
                    totalPages = this.pages.TotalPages(this.books.TotalForKidsAsync);
                    if (page > totalPages || page <= 0)
                    {
                        return this.RedirectToAction(nameof(this.Books));
                    }
                    filterType = await this.books.AllBooksForChildrenAsync(CurrentCulture(), page);
                    break;
                case BooksForLandFilter:
                    totalPages = this.pages.TotalPages(this.books.TotalForLandAsync);
                    if (page > totalPages || page <= 0)
                    {
                        return this.RedirectToAction(nameof(this.Books));
                    }
                    filterType = await this.books.AllBooksForLandLandAsync(CurrentCulture(), page);
                    break;
                default:
                    totalPages = this.pages.TotalPages(this.books.TotalAsync);
                    if (page > totalPages || page <= 0)
                    {
                        return this.RedirectToAction(nameof(this.Books));
                    }
                    filterType = await this.books.AllBooksAsync(CurrentCulture(), page);
                    break;
            }

            return this.View(new BookListingViewModel
            {
                Books = filterType,
                TotalPages = totalPages,
                CurrentPage = page,
                Filter = filter
            });
        }
        
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var book = await this.books.ByIdAsync(id);

            if (book != null)
            {
                return this.View(new BookViewModel
                {
                    Book = book
                });
            }

            return this.RedirectToAction(nameof(this.Books));

        }

        public IActionResult Create()
            => this.View();

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Create(BookFormModel model)
        {
            if (await this.books.UniqueCheckAsync(model.BookTitle, model.AuthorName))
            {
                this.TempData.AddWarningMessage(string.Format(TempDataAlreadyExistsText, ModelName, model.BookTitle));

                return this.RedirectToAction(nameof(this.Create));
            }

            model.BookDescription = this.html.Sanitize(model.BookDescription);

            string savePath;

            if (model.ImageUrl != null)
            {
                var path = Path.Combine(ImageFolderName, BooksImageFolderName, $"{Guid.NewGuid()}.jpg");

                if (!ImageDownloaderExtensions.Download(model.ImageUrl, path))
                {
                    this.TempData.AddWarningMessage(string.Format(TempDataWrongUrlText, ModelName));
                    return this.RedirectToAction(nameof(this.Create));
                }
                path = path.Replace("\\", "/");

                savePath = string.Format(SavePath,path);
            }
            else
            {
                savePath = DefaultImagePath;
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
                model.Genre,
                savePath,
                model.Language);

            this.TempData.AddSuccessMessage(string.Format(TempDataCreateCommentText, ModelName, EndingLetterA));

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
                var path = Path.Combine(ImageFolderName, BooksImageFolderName, $"{Guid.NewGuid()}.jpg");

                if (!ImageDownloaderExtensions.Download(model.ImageUrl, path))
                {
                    this.TempData.AddWarningMessage(string.Format(TempDataWrongUrlText, ModelName));

                    return this.RedirectToAction(nameof(this.Create));
                }

                path = path.Replace("\\", "/");

                savePath = $"/{path}";
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
                model.Genre,
                savePath,
                model.Language);

            this.TempData.AddSuccessMessage(string.Format(TempDataEditCommentText, ModelName, EndingLetterA));

            return this.RedirectToAction(nameof(this.Books));
        }

        public IActionResult Delete(BookDeleteViewModel model)
            => this.View(model);

        public async Task<IActionResult> Destroy(int id)
        {
            await this.books.DeleteAsync(id);

            this.TempData.AddSuccessMessage(string.Format(TempDataDeleteCommentText, ModelName, EndingLetterA));

            return this.RedirectToAction(nameof(this.Books));
        }

        private string CurrentCulture()
            => CultureInfo.CurrentCulture.Name;
    }
}