﻿namespace Library.Web.Areas.LibraryBlog.Models.Books
{
    using Services.LibraryBlog.Models.Books;
    using System.Collections.Generic;

    public class BookListingViewModel
    {
        public IEnumerable<BookListingServiceModel> Books { get; set; }

        public int TotalPages { get; set; }

        public int CurrentPage { get; set; }

        public int PreviousPage
            => this.CurrentPage == 1 ? 1 : this.CurrentPage - 1;

        public int NextPage
            => this.CurrentPage == this.TotalPages ? this.TotalPages : this.CurrentPage + 1;

        public string Filter { get; set; }
    }
}