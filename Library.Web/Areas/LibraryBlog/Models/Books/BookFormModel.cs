namespace Library.Web.Areas.LibraryBlog.Models.Books
{
    using Data.Models;
    using System.ComponentModel.DataAnnotations;
    using Search;
    using Resources.Areas.LibraryBlog.Models.Books;

    using static Data.DataConstants;

    public class BookFormModel : SearchFormModel
    {
        [Required]
        [MinLength(BookAuthorNameMinLength)]
        [MaxLength(BookAuthorNameMaxLength)]
        [Display(Name = "Author", ResourceType = typeof(BookFormModelResx))]
        public string AuthorName { get; set; }

        [Required]
        [MinLength(BookTitleMinLength)]
        [MaxLength(BookTitleMaxLength)]
        [Display(Name = "Title", ResourceType = typeof(BookFormModelResx))]
        public string BookTitle { get; set; }

        [MinLength(BookDescriptionMinLength)]
        [MaxLength(BookDescriptionMaxLength)]
        [Display(Name = "Description", ResourceType = typeof(BookFormModelResx))]
        public string BookDescription { get; set; }

        [MinLength(BookCityMinLength)]
        [MaxLength(BookCityMaxLength)]
        [Display(Name = "City", ResourceType = typeof(BookFormModelResx))]
        public string CityIssued { get; set; }

        [MinLength(BookPressMinLength)]
        [MaxLength(BookPressMaxLength)]
        [Display(Name = "Publisher", ResourceType = typeof(BookFormModelResx))]
        public string Press { get; set; }

        [Required]
        [Display(Name = "Department", ResourceType = typeof(BookFormModelResx))]
        public DepartmentType Department { get; set; }

        [RegularExpression(@"^18\d{2}|19\d{2}|20\d{2}|0$", ErrorMessageResourceName= "DateError", ErrorMessageResourceType = typeof(BookFormModelResx))]
        [Display(Name = "Date", ResourceType = typeof(BookFormModelResx))]
        public int PublishDate { get; set; }


        [Range(0, int.MaxValue)]
        [Display(Name = "Pages", ResourceType = typeof(BookFormModelResx))]
        public int Pages { get; set; }

        [Range(0, int.MaxValue)]
        [Display(Name = "Sizes", ResourceType = typeof(BookFormModelResx))]
        public int Size { get; set; }

        [Required]
        [MinLength(BookGenreMinLength)]
        [MaxLength(BookGenreMaxLength)]
        [Display(Name = "Genre", ResourceType = typeof(BookFormModelResx))]
        public string Genre { get; set; }

        [MinLength(BookImageUrlMinLength)]
        [MaxLength(BookImageUrlMaxLength)]
        [RegularExpression(@"^(http:\/\/www\.|https:\/\/www\.|http:\/\/|https:\/\/)?[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?(.jpg|.gif|.png|.JPG|.PNG|.GIF)$",ErrorMessageResourceName = "UrlError", ErrorMessageResourceType = typeof(BookFormModelResx))]
        [Display(Name = "Url", ResourceType = typeof(BookFormModelResx))]
        public string ImageUrl { get; set; }

        [Required]
        [Display(Name = "Language", ResourceType = typeof(BookFormModelResx))]
        public Language Language { get; set; }
    }
}