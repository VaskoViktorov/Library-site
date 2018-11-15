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
            string genre,
            string imageUrl,
            Language language);

        Task<BookServiceModel> ByIdAsync(int id);

        Task DeleteAsync(int id);

        Task<IEnumerable<BookListingServiceModel>> AllBooksAsync(string language, int page = 1);

        Task<int> TotalAsync(string language);

        Task<int> TotalForKidsAsync(string language);

        Task<int> TotalForLandAsync(string language);

        Task<IEnumerable<BookListingServiceModel>> AllBooksForChildrenAsync(string language, int page = 1);

        Task<IEnumerable<BookListingServiceModel>> AllBooksForLandLandAsync(string language, int page = 1);
    }
}