namespace Library.Web.Areas.LibraryBlog.Models.Books
{
    using Data.Models;
    using Resources.Areas.LibraryBlog.Models.Books;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class BookFormModel
    {
        [Required(ErrorMessageResourceName = "RequiredErrorMsg", ErrorMessageResourceType = typeof(BookFormModelResx))]
        [MinLength(BookAuthorNameMinLength, ErrorMessageResourceName = "MinLengthErrorMsg", ErrorMessageResourceType = typeof(BookFormModelResx))]
        [MaxLength(BookAuthorNameMaxLength, ErrorMessageResourceName = "MaxLengthErrorMsg", ErrorMessageResourceType = typeof(BookFormModelResx))]
        [Display(Name = "Author", ResourceType = typeof(BookFormModelResx))]
        public string AuthorName { get; set; }

        [Required(ErrorMessageResourceName = "RequiredErrorMsg", ErrorMessageResourceType = typeof(BookFormModelResx))]
        [MinLength(BookTitleMinLength, ErrorMessageResourceName = "MinLengthErrorMsg", ErrorMessageResourceType = typeof(BookFormModelResx))]
        [MaxLength(BookTitleMaxLength, ErrorMessageResourceName = "MaxLengthErrorMsg", ErrorMessageResourceType = typeof(BookFormModelResx))]
        [Display(Name = "Title", ResourceType = typeof(BookFormModelResx))]
        public string BookTitle { get; set; }

        [MinLength(BookDescriptionMinLength, ErrorMessageResourceName = "MinLengthErrorMsg", ErrorMessageResourceType = typeof(BookFormModelResx))]
        [MaxLength(BookDescriptionMaxLength, ErrorMessageResourceName = "MaxLengthErrorMsg", ErrorMessageResourceType = typeof(BookFormModelResx))]
        [Display(Name = "Description", ResourceType = typeof(BookFormModelResx))]
        public string BookDescription { get; set; }

        [MinLength(BookCityMinLength, ErrorMessageResourceName = "MinLengthErrorMsg", ErrorMessageResourceType = typeof(BookFormModelResx))]
        [MaxLength(BookCityMaxLength, ErrorMessageResourceName = "MaxLengthErrorMsg", ErrorMessageResourceType = typeof(BookFormModelResx))]
        [Display(Name = "City", ResourceType = typeof(BookFormModelResx))]
        public string CityIssued { get; set; }

        [MinLength(BookPressMinLength, ErrorMessageResourceName = "MinLengthErrorMsg", ErrorMessageResourceType = typeof(BookFormModelResx))]
        [MaxLength(BookPressMaxLength, ErrorMessageResourceName = "MaxLengthErrorMsg", ErrorMessageResourceType = typeof(BookFormModelResx))]
        [Display(Name = "Publisher", ResourceType = typeof(BookFormModelResx))]
        public string Press { get; set; }

        [Required(ErrorMessageResourceName = "RequiredErrorMsg", ErrorMessageResourceType = typeof(BookFormModelResx))]
        [Display(Name = "Department", ResourceType = typeof(BookFormModelResx))]
        public DepartmentType Department { get; set; }

        [Required(ErrorMessageResourceName = "RequiredErrorMsg", ErrorMessageResourceType = typeof(BookFormModelResx))]
        [RegularExpression(@"^18\d{2}|19\d{2}|20\d{2}|0$", ErrorMessageResourceName = "DateError", ErrorMessageResourceType = typeof(BookFormModelResx))]
        [Display(Name = "Date", ResourceType = typeof(BookFormModelResx))]
        public int PublishDate { get; set; }

        [Required(ErrorMessageResourceName = "RequiredErrorMsg", ErrorMessageResourceType = typeof(BookFormModelResx))]
        [Range(1, 10000, ErrorMessageResourceName = "RangeErrorMsg", ErrorMessageResourceType = typeof(BookFormModelResx))]
        [Display(Name = "Pages", ResourceType = typeof(BookFormModelResx))]
        public int Pages { get; set; }

        [Required(ErrorMessageResourceName = "RequiredErrorMsg", ErrorMessageResourceType = typeof(BookFormModelResx))]
        [MinLength(BookGenreMinLength, ErrorMessageResourceName = "MinLengthErrorMsg", ErrorMessageResourceType = typeof(BookFormModelResx))]
        [MaxLength(BookGenreMaxLength, ErrorMessageResourceName = "MaxLengthErrorMsg", ErrorMessageResourceType = typeof(BookFormModelResx))]
        [Display(Name = "Genre", ResourceType = typeof(BookFormModelResx))]
        public string Genre { get; set; }

        [MinLength(BookImageUrlMinLength, ErrorMessageResourceName = "MinLengthErrorMsg", ErrorMessageResourceType = typeof(BookFormModelResx))]
        [MaxLength(BookImageUrlMaxLength, ErrorMessageResourceName = "MaxLengthErrorMsg", ErrorMessageResourceType = typeof(BookFormModelResx))]
        [RegularExpression(@"^(http:\/\/www\.|https:\/\/www\.|http:\/\/|https:\/\/)?[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?(.jpg|.gif|.png|.JPG|.PNG|.GIF)$", ErrorMessageResourceName = "UrlError", ErrorMessageResourceType = typeof(BookFormModelResx))]
        [Display(Name = "Url", ResourceType = typeof(BookFormModelResx))]
        public string ImageUrl { get; set; }

        [Required(ErrorMessageResourceName = "RequiredErrorMsg", ErrorMessageResourceType = typeof(BookFormModelResx))]
        [Display(Name = "Language", ResourceType = typeof(BookFormModelResx))]
        public Language Language { get; set; }
    }
}