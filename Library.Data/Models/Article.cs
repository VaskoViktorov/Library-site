namespace Library.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Article
    {
        public int Id { get; set; }   

        public List<Image> Images { get; set; } = new List<Image>();

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public DateTime CreateDate { get; set; }

        public string AuthorName { get; set; }

        public ArticleType Type { get; set; }
    }
}
