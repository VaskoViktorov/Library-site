﻿namespace Library.Services.LibraryBlog
{
    using System.Collections.Generic;
    using Models.Books;
    using System;
    using System.Threading.Tasks;
    using Data.Models;

    public interface IBookService
    {
        Task CreateAsync(
            string authorName,
            string bookTitle,
            string bookDescription,
            string cityIssued,
            string press,
            DepartmentType department,
            int publishDate,
            DateTime date,
            int pages,
            int size,
            string genre,
            string imageUrl);

        Task<bool> UniqueCheckAsync(string bookTitle, string authorName);

        Task EditAsync(
            int id,
            string authorName,
            string bookTitle,
            string bookDescription,
            string cityIssued,
            string press,
            DepartmentType department,
            int publishDate,
            int pages,
            int size,
            string genre,
            string imageUrl);

        Task<BookServiceModel> ByIdAsync(int id);

        Task DeleteAsync(int id);

        Task<IEnumerable<BookListingServiceModel>> AllBooksAsync(int page = 1);

        Task<int> TotalAsync();

        Task<int> TotalForKidsAsync();

        Task<int> TotalForLandAsync();

        Task<IEnumerable<BookListingServiceModel>> AllBooksForChildrenAsync(int page = 1);

        Task<IEnumerable<BookListingServiceModel>> AllBooksForLandLandAsync(int page = 1);
    }
}