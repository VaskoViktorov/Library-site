namespace Library.Web.Areas.LibraryBlog.Models.Articles
{
    using Data.Models;
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Search;
    using Resources.Areas.LibraryBlog.Models.Articles;

    using static Data.DataConstants;

    public class ArticleFormModel : SearchFormModel
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

        [DataType(DataType.Date)]
        [Display(Name = "Release", ResourceType = typeof(ArticleFormModelResx))]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Department", ResourceType = typeof(ArticleFormModelResx))]
        public DepartmentType Type { get; set; }

        [Required]
        [Display(Name = "Language", ResourceType = typeof(ArticleFormModelResx))]
        public Language Language { get; set; }

        public List<IFormFile> Files { get; set; } = new List<IFormFile>();
    }
}