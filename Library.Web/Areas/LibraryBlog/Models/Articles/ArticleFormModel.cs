namespace Library.Web.Areas.LibraryBlog.Models.Articles
{
    using Data.Models;
    using Microsoft.AspNetCore.Http;
    using Resources.Areas.LibraryBlog.Models.Articles;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Infrastructure.Filters;

    using static Data.DataConstants;

    public class ArticleFormModel
    {
        [Required(ErrorMessageResourceName = "RequiredErrorMsg", ErrorMessageResourceType = typeof(ArticleFormModelResx))]
        [MinLength(ArticleTitleMinLength, ErrorMessageResourceName = "MinLengthErrorMsg", ErrorMessageResourceType = typeof(ArticleFormModelResx))]
        [MaxLength(ArticleTitleMaxLength, ErrorMessageResourceName = "MaxLengthErrorMsg", ErrorMessageResourceType = typeof(ArticleFormModelResx))]
        [Display(Name = "Title", ResourceType = typeof(ArticleFormModelResx))]
        public string Title { get; set; }

        [Required(ErrorMessageResourceName = "RequiredErrorMsg", ErrorMessageResourceType = typeof(ArticleFormModelResx))]
        [MinLength(ArticleDescriptionMinLength, ErrorMessageResourceName = "MinLengthErrorMsg", ErrorMessageResourceType = typeof(ArticleFormModelResx))]
        [MaxLength(ArticleDescriptionMaxLength, ErrorMessageResourceName = "MaxLengthErrorMsg", ErrorMessageResourceType = typeof(ArticleFormModelResx))]
        [Display(Name = "Description", ResourceType = typeof(ArticleFormModelResx))]
        public string Description { get; set; }

        [MinLength(ArticleAuthorNameMinLength, ErrorMessageResourceName = "MinLengthErrorMsg", ErrorMessageResourceType = typeof(ArticleFormModelResx))]
        [MaxLength(ArticleAuthorNameMaxLength, ErrorMessageResourceName = "MaxLengthErrorMsg", ErrorMessageResourceType = typeof(ArticleFormModelResx))]
        [Display(Name = "Author", ResourceType = typeof(ArticleFormModelResx))]
        public string Author { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Release", ResourceType = typeof(ArticleFormModelResx))]
        [ValidateArticleReleaseDate(ErrorMessageResourceName = "ValidateArticleReleaseDate", ErrorMessageResourceType = typeof(ArticleFormModelResx))]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessageResourceName = "RequiredErrorMsg", ErrorMessageResourceType = typeof(ArticleFormModelResx))]
        [Display(Name = "Language", ResourceType = typeof(ArticleFormModelResx))]
        public Language Language { get; set; }

        [Required(ErrorMessageResourceName = "RequiredErrorMsg", ErrorMessageResourceType = typeof(ArticleFormModelResx))]
        [Display(Name = "ShowAtFrontPage", ResourceType = typeof(ArticleFormModelResx))]
        public bool ShowAtFrontPage { get; set; }

        [Required(ErrorMessageResourceName = "RequiredErrorMsg", ErrorMessageResourceType = typeof(ArticleFormModelResx))]
        [Display(Name = "Gallery", ResourceType = typeof(ArticleFormModelResx))]
        public bool AddGallery { get; set; }

        public List<IFormFile> Files { get; set; } = new List<IFormFile>();
    }
}