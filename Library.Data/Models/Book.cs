namespace Library.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Book
    {
        public int Id { get; set; }

        [Required]
        [MinLength(BookAuthorNameMinLength)]
        [MaxLength(BookAuthorNameMaxLength)]
        public string AuthorName { get; set; }

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

        [Required]
        public DepartmentType Department { get; set; }

        [RegularExpression(@"^18\d{2}|19\d{2}|20\d{2}$|0")]
        public int PublishDate { get; set; }

        public DateTime Date { get; set; }

        [Range(0,int.MaxValue)]
        public int Pages { get; set; }

        [Range(0,int.MaxValue)]
        public int Size { get; set; }

        [Required]
        [MinLength(BookGenreMinLength)]
        [MaxLength(BookGenreMaxLength)]
        public string Genre { get; set; }

        [MinLength(BookImageUrlMinLength)]
        [MaxLength(BookImageUrlMaxLength)]
        public string ImageUrl { get; set; }
    }
}
