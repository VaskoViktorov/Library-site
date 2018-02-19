using Library.Web.Areas.LibraryBlog.Models.Search;

namespace Library.Web.Areas.LibraryBlog.Models.Books
{
    using Services.LibraryBlog.Models.Books;
    using System;
    using System.Collections.Generic;

    using static Services.ServicesConstants;

    public class BookListingViewModel : SearchFormModel
    {
        public IEnumerable<BookListingServiceModel> Books { get; set; }

        public int TotalBooks { get; set; }

        public int TotalPages
            => (int)Math.Ceiling((double)this.TotalBooks / BooksPageSize);

        public int CurrentPage { get; set; }

        public int PreviousPage
            => this.CurrentPage == 1 ? 1 : this.CurrentPage - 1;

        public int NextPage
            => this.CurrentPage == this.TotalPages ? this.TotalPages : this.CurrentPage + 1;
    }
}