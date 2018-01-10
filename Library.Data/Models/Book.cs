namespace Library.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Book
    {
        public int Id { get; set; }

        [Required]
        [MinLength(BookAuthorFirstNameMinLength)]
        [MaxLength(BookAuthorFirstNameMaxLength)]
        public string AuthorFirstName { get; set; }

        [Required]
        [MinLength(BookAuthorLastNameMinLength)]
        [MaxLength(BookAuthorLastNameMaxLength)]
        public string AuthorLastName { get; set; }

        [Required]
        [MinLength(BookTitleMinLength)]
        [MaxLength(BookTitleMaxLength)]
        public string BookTitle { get; set; }

        [MinLength(BookDescriptionMinLength)]
        [MaxLength(BookDescriptionMaxLength)]
        public string BookDescription { get; set; }

        [MinLength(BookCityMinLength)]
        [MaxLength(BookCityMaxLength)]
        public string CityIssued { get; set; }

        [MinLength(BookPressMinLength)]
        [MaxLength(BookPressMaxLength)]
        public string Press { get; set; }


        public DateTime PublishDate { get; set; }

        public DateTime Date { get; set; }

        [Range(0,int.MaxValue)]
        public int Pages { get; set; }

        [Range(0,double.MaxValue)]
        public double Size { get; set; }

        [MinLength(BookImageUrlMinLength)]
        [MaxLength(BookImageUrlMaxLength)]
        public string ImageUrl { get; set; }
    }
}
