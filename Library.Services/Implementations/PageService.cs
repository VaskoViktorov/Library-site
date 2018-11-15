namespace Library.Services.Implementations
{
    using LibraryBlog;
    using System;
    using System.Globalization;
    using System.Threading.Tasks;

    using static ServicesConstants;

    class PageService : IPageService
    {
        public int TotalPages(Func<string, Task<int>> input)
        {
            var pageCount = (double)input(CultureInfo.CurrentCulture.Name).Result;
            var booksPerPage = BooksPageSize;
            var result = (int)Math.Ceiling(pageCount / booksPerPage);

            return result;
        }
    }
}
