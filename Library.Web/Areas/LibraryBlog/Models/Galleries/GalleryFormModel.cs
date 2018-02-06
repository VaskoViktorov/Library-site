using Library.Data.Models;

namespace Library.Web.Areas.LibraryBlog.Models.Galleries
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Http;

    using static Data.DataConstants;

    public class GalleryFormModel
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
