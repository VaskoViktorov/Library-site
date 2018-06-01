namespace Library.Web.Areas.LibraryBlog.Models.Articles
{
    using Data.Models;
    using Microsoft.AspNetCore.Http;
    using Resources.Areas.LibraryBlog.Models.Articles;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class ArticleFormModel
    {
        [Required]
        [MinLength(ArticleTitleMinLength)]
        [MaxLength(ArticleTitleMaxLength)]
        [Display(Name = "Title", ResourceType = typeof(ArticleFormModelResx))]
        public string Title { get; set; }

        [Required]
        [MinLength(ArticleDescriptionMinLength)]
        [MaxLength(ArticleDescriptionMaxLength)]
        [Display(Name = "Description", ResourceType = typeof(ArticleFormModelResx))]
        public string Description { get; set; }

        [MinLength(ArticleAuthorNameMinLength)]
        [MaxLength(ArticleAuthorNameMaxLength)]
        [Display(Name = "Author", ResourceType = typeof(ArticleFormModelResx))]
        public string Author { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Release", ResourceType = typeof(ArticleFormModelResx))]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Language", ResourceType = typeof(ArticleFormModelResx))]
        public Language Language { get; set; }

        [Required]
        [Display(Name = "ShowAtFrontPage", ResourceType = typeof(ArticleFormModelResx))]
        public bool ShowAtFrontPage { get; set; }

        [Required]
        [Display(Name = "Gallery", ResourceType = typeof(ArticleFormModelResx))]
        public bool AddGallery { get; set; }

        public List<IFormFile> Files { get; set; } = new List<IFormFile>();
    }
}