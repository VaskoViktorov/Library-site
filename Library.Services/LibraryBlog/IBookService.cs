namespace Library.Services.LibraryBlog
{
    using Data.Models;
    using Models.Books;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

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
            string imageUrl,
            Language language);

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
            string imageUrl,
            Language language);

        Task<BookServiceModel> ByIdAsync(int id);

        Task DeleteAsync(int id);

        Task<IEnumerable<BookListingServiceModel>> AllBooksAsync(int page = 1);

        Task<int> TotalAsync();

        Task<int> TotalForKidsAsync();

        Task<int> TotalForLandAsync();

        //English

        Task<IEnumerable<BookListingServiceModel>> AllBooksForChildrenAsync(int page = 1);

        Task<IEnumerable<BookListingServiceModel>> AllBooksForLandLandAsync(int page = 1);

        Task<IEnumerable<BookListingServiceModel>> AllBooksEnAsync(int page = 1);

        Task<int> TotalEnAsync();

        Task<int> TotalForKidsEnAsync();

        Task<int> TotalForLandEnAsync();

        Task<IEnumerable<BookListingServiceModel>> AllBooksForChildrenEnAsync(int page = 1);

        Task<IEnumerable<BookListingServiceModel>> AllBooksForLandEnAsync(int page = 1);
    }
}