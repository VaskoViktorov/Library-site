using System.Text.RegularExpressions;
using Microsoft.Azure.KeyVault.Models;

namespace Library.Web.Areas.LibraryBlog.Models.Books
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Data.Models;

    using static Data.DataConstants;

    public class BookFormModel
    {
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

        [Required]
        public DepartmentType Department { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }

        [Range(0, int.MaxValue)]
        public int Pages { get; set; }

        [Range(0, int.MaxValue)]
        public int Size { get; set; }

        [Required]
        [MinLength(BookGenreMinLength)]
        [MaxLength(BookGenreMaxLength)]
        public string Genre { get; set; }

        [MinLength(BookImageUrlMinLength)]
        [MaxLength(BookImageUrlMaxLength)]
        
        [RegularExpression(@"^(http:\/\/www\.|https:\/\/www\.|http:\/\/|https:\/\/)?[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?(.jpg|.gif|.png|.JPG|.PNG|.GIF)$", ErrorMessage = "Wrong URL")]
        public string ImageUrl { get; set; }
    }
}
