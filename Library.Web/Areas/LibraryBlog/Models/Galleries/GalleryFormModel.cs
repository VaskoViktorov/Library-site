namespace Library.Web.Areas.LibraryBlog.Models.Galleries
{
    using Data.Models;
    using Microsoft.AspNetCore.Http;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Search;

    using static Data.DataConstants;

    public class GalleryFormModel : SearchFormModel
    {
        [Required]
        [MinLength(GalleryTitleMinLength)]
        [MaxLength(GalleryTitleMaxLength)]
        [Display(Name = "Заглавие")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Език")]
        public Language Language { get; set; }

        public List<IFormFile> Files { get; set; }
            = new List<IFormFile>();
    }
}