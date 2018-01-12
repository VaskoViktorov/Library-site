using System.Collections.Generic;
using System.IO;
using Library.Common.Infrastructure.Extensions;

namespace Library.Services.LibraryBlog.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Data.Models;
    using LibraryBlog;
    using Microsoft.EntityFrameworkCore;
    using Models.Books;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using static ServicesConstants;

    class BookService : IBookService
    {
        private readonly LibraryDbContext db;

        public BookService(LibraryDbContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(string authorFirstName, string authorLastName, string bookTitle, string bookDescription, string cityIssued,
            string press, DepartmentType department, DateTime publishDate, DateTime date, int pages, int size, string genre, string imageUrl)
        {
            var book = new Book
            {
                AuthorFirstName = authorFirstName,
                AuthorLastName = authorLastName,
                BookTitle = bookTitle,
                BookDescription = bookDescription,
                CityIssued = cityIssued,
                Press = press,
                Department = department,
                PublishDate = publishDate,
                Date = date,
                Pages = pages,
                Size = size,
                Genre = genre,
                ImageUrl = imageUrl
            };

            this.db.Add(book);
            await this.db.SaveChangesAsync();
        }

        public async Task<bool> UniqueCheckAsync(string bookTitle, string authorLastName)
        {
            if (await this.db.Books.AnyAsync(b => b.BookTitle == bookTitle && b.AuthorLastName == authorLastName))
            {
                return true;
            }

            return false;
        }

        public async Task EditAsync(int id, string authorFirstName, string authorLastName, string bookTitle, string bookDescription, string cityIssued,
            string press, DepartmentType department, DateTime publishDate, int pages, int size, string genre, string imageUrl)
        {
            var book = await this.db.Books.FindAsync(id);

            if (book == null)
            {
                return;
            }

            book.AuthorFirstName = authorFirstName;
            book.AuthorLastName = authorLastName;
            book.BookTitle = bookTitle;
            book.BookDescription = bookDescription;
            book.CityIssued = cityIssued;
            book.Press = press;
            book.Department = department;
            book.PublishDate = publishDate;
            book.Pages = pages;
            book.Size = size;
            book.Genre = genre;
            if (imageUrl != null)
            {
                FileExtensions.DeleteImage(book.ImageUrl);
                book.ImageUrl = imageUrl;
            }

            await this.db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var book = await this.db.Books.FindAsync(id);

            if (book == null)
            {
                return;
            }
            this.db.Books.Remove(book);

            await this.db.SaveChangesAsync();

            FileExtensions.DeleteImage(book.ImageUrl);
        }

        public async Task<BookServiceModel> ByIdAsync(int id)
            => await this.db
                .Books
                .Where(a => a.Id == id)
                .ProjectTo<BookServiceModel>()
                .FirstOrDefaultAsync();

        public async Task<IEnumerable<BookListingServiceModel>> AllBooksAsync(int page = 1)
            => await this.db
                .Books
                .OrderBy(b => b.Date)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ProjectTo<BookListingServiceModel>()
                .ToListAsync();

        public async Task<IEnumerable<BookListingServiceModel>> AllBooksForChildrenAsync(int page = 1)
            => await this.db
                .Books
                .OrderBy(b => b.Date)
                .Where(b => b.Department == DepartmentType.Kids)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ProjectTo<BookListingServiceModel>()
                .ToListAsync();

        public async Task<IEnumerable<BookListingServiceModel>> AllBooksForLandLandAsync(int page = 1)
            => await this.db
                .Books
                .OrderBy(b => b.Date)
                .Where(b => b.Department == DepartmentType.Land)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ProjectTo<BookListingServiceModel>()
                .ToListAsync();

        public async Task<int> TotalAsync()
        => await this.db
                    .Books
                    .CountAsync();

        public async Task<int> TotalForKidsAsync()
            => await this.db
                .Books
                .Where(b => b.Department == DepartmentType.Kids)
                .CountAsync();

        public async Task<int> TotalForLandAsync()
           => await this.db
               .Books
               .Where(b => b.Department == DepartmentType.Land)
               .CountAsync();
    }
}
