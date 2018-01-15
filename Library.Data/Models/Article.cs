namespace Library.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Article
    {
        public int Id { get; set; }

        [Required]
        [MinLength(ArticleTitleMinLength)]
        [MaxLength(ArticleTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(ArticleDescriptionMinLength)]
        [MaxLength(ArticleDescriptionMaxLength)]
        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public DateTime CreateDate { get; set; }

        public string AuthorName { get; set; }

        [Required]
        public DepartmentType Type { get; set; }

        public Gallery Gallery { get; set; }
    }
}
