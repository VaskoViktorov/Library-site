using System;

namespace Library.Data.Models
{
   public class Book
    {
        public int Id { get; set; }

        public string AuthorFirstName { get; set; }

        public string AuthorLastName { get; set; }

        public string BookTitle { get; set; }

        public string BookDescription { get; set; }

        public string CityIssued { get; set; }

        public string Press { get; set; }

        public DateTime PublishDate { get; set; }

        public DateTime Date { get; set; }

        public int Pages { get; set; }

        public double Size { get; set; }

        public string ImageUrl { get; set; }
    }
}
