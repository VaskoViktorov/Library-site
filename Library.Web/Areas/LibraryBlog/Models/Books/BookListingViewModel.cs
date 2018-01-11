namespace Library.Web.Areas.LibraryBlog.Models.Books
{
    using Services.LibraryBlog.Models.Books;
    using System.Collections.Generic;

    public class BookListingViewModel
    {
        public IEnumerable<BookListingServiceModel> Books { get; set; }
    }
}
