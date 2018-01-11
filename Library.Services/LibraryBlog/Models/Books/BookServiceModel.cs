namespace Library.Services.LibraryBlog.Models.Books
{
    using System;

    public class BookServiceModel : BookListingServiceModel
    {      
        public string BookDescription { get; set; }

        public string CityIssued { get; set; }

        public string Press { get; set; }

        public DateTime PublishDate { get; set; }

        public DateTime Date { get; set; }

        public int Pages { get; set; }

        public int Size { get; set; }

        public string Genre { get; set; }
    }
}
