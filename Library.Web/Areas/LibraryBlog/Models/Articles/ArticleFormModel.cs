using System;
using System.ComponentModel.DataAnnotations;
using Library.Data.Models;

namespace Library.Web.Areas.LibraryBlog.Models.Articles
{
    using static Data.DataConstants;

    public class ArticleFormModel
    {
        [Required]
        [MinLength(ArticleTitleMinLength)]
        [MaxLength(ArticleTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(ArticleDescriptionMinLength)]
        [MaxLength(ArticleDescriptionMaxLength)]
        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        [Required]
        public DepartmentType Type { get; set; }

        public Gallery Gallery { get; set; }
    }
}
