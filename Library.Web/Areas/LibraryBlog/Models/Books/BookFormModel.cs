namespace Library.Web.Areas.LibraryBlog.Models.Books
{

    using System.ComponentModel.DataAnnotations;
    using Data.Models;

    using static Data.DataConstants;

    public class BookFormModel
    {
        [Required]
        [MinLength(BookAuthorNameMinLength)]
        [MaxLength(BookAuthorNameMaxLength)]
        [Display(Name = "Автор")]
        public string AuthorName { get; set; }

        [Required]
        [MinLength(BookTitleMinLength)]
        [MaxLength(BookTitleMaxLength)]
        [Display(Name = "Заглавие")]
        public string BookTitle { get; set; }

        [MinLength(BookDescriptionMinLength)]
        [MaxLength(BookDescriptionMaxLength)]
        [Display(Name = "Кратко описание")]
        public string BookDescription { get; set; }

        [MinLength(BookCityMinLength)]
        [MaxLength(BookCityMaxLength)]
        [Display(Name = "Град")]
        public string CityIssued { get; set; }

        [MinLength(BookPressMinLength)]
        [MaxLength(BookPressMaxLength)]
        [Display(Name = "Издател")]
        public string Press { get; set; }

        [Required]
        [Display(Name = "Отдел")]
        public DepartmentType Department { get; set; }

        [RegularExpression(@"^18\d{2}|19\d{2}|20\d{2}|0$", ErrorMessage = "Некоректен формат за дата. Приемат се стойности от 1800 до 2099")]
        [Display(Name = "Година на издаване")]
        public int PublishDate { get; set; } 


        [Range(0, int.MaxValue)]
        [Display(Name = "Страници")]
        public int Pages { get; set; }

        [Range(0, int.MaxValue)]
        [Display(Name = "Размер")]
        public int Size { get; set; }

        [Required]
        [MinLength(BookGenreMinLength)]
        [MaxLength(BookGenreMaxLength)]
        [Display(Name = "Жанр")]
        public string Genre { get; set; }

        [MinLength(BookImageUrlMinLength)]
        [MaxLength(BookImageUrlMaxLength)]        
        [RegularExpression(@"^(http:\/\/www\.|https:\/\/www\.|http:\/\/|https:\/\/)?[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?(.jpg|.gif|.png|.JPG|.PNG|.GIF)$", ErrorMessage = "Грешен линк. Линка трябва да завършва с .jpg, .png или .gif .")]
        [Display(Name = "Линк")]
        public string ImageUrl { get; set; }

        [Required]
        [Display(Name = "Език")]
        public Language Language { get; set; }
    }
}
