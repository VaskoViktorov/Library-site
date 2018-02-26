namespace Library.Web.Areas.LibraryBlog.Models.Galleries
{
    using Data.Models;
    using Microsoft.AspNetCore.Http;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Search;
    using Resources.Areas.LibraryBlog.Models.Galleries;

    using static Data.DataConstants;

    public class GalleryFormModel : SearchFormModel
    {
        [Required]
        [MinLength(GalleryTitleMinLength)]
        [MaxLength(GalleryTitleMaxLength)]
        [Display(Name = "Title", ResourceType = typeof(GalleryFormModelResx))]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Language", ResourceType = typeof(GalleryFormModelResx))]
        public Language Language { get; set; }

        [Display(Name = "Files", ResourceType = typeof(GalleryFormModelResx))]
        public List<IFormFile> Files { get; set; }
            = new List<IFormFile>();
    }
}