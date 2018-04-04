namespace Library.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Gallery
    {
        public int Id { get; set; }

        [Required]
        [MinLength(GalleryTitleMinLength)]
        [MaxLength(GalleryTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        public bool Show { get; set; }

        [Required]
        public Language Language { get; set; }

        public List<Image> Images { get; set; } = new List<Image>();

        public int ArticleId { get; set; }

        public Article Article { get; set; }
    }
}