using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Library.Data.Models;
using Microsoft.AspNetCore.Http;

namespace Library.Web.Areas.LibraryBlog.Models.Articles
{
    using static Data.DataConstants;

    public class ArticleFormModel
    {
        [Required]
        [MinLength(ArticleTitleMinLength)]
        [MaxLength(ArticleTitleMaxLength)]
        [Display(Name = "Заглавие")]
        public string Title { get; set; }

        [Required]
        [MinLength(ArticleDescriptionMinLength)]
        [MaxLength(ArticleDescriptionMaxLength)]
        [Display(Name = "Съдържание")]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Дата на публикуване")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Отдел")]
        public DepartmentType Type { get; set; }

        [Required]
        [Display(Name = "Език")]
        public Language Language { get; set; }

        public List<IFormFile> Files { get; set; }
            = new List<IFormFile>();
    }
}
