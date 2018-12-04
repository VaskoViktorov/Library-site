namespace Library.Web.Areas.LibraryBlog.Models.Galleries
{
    using Data.Models;
    using Microsoft.AspNetCore.Http;
    using Resources.Areas.LibraryBlog.Models.Galleries;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class GalleryFormModel
    {
        [Required(ErrorMessageResourceName = "RequiredErrorMsg", ErrorMessageResourceType = typeof(GalleryFormModelResx))]
        [MinLength(GalleryTitleMinLength, ErrorMessageResourceName = "MinLengthErrorMsg", ErrorMessageResourceType = typeof(GalleryFormModelResx))]
        [MaxLength(GalleryTitleMaxLength, ErrorMessageResourceName = "MaxLengthErrorMsg", ErrorMessageResourceType = typeof(GalleryFormModelResx))]
        [Display(Name = "Title", ResourceType = typeof(GalleryFormModelResx))]
        public string Title { get; set; }

        [Required(ErrorMessageResourceName = "RequiredErrorMsg", ErrorMessageResourceType = typeof(GalleryFormModelResx))]
        [Display(Name = "Language", ResourceType = typeof(GalleryFormModelResx))]
        public Language Language { get; set; }

        [Display(Name = "Files", ResourceType = typeof(GalleryFormModelResx))]
        public List<IFormFile> Files { get; set; }
            = new List<IFormFile>();

        [Required(ErrorMessageResourceName = "RequiredErrorMsg", ErrorMessageResourceType = typeof(GalleryFormModelResx))]
        [Display(Name = "Show", ResourceType = typeof(GalleryFormModelResx))]
        public bool Show { get; set; }
    }
}