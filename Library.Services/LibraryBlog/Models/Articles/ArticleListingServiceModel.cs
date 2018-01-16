using System.ComponentModel.DataAnnotations;

namespace Library.Services.LibraryBlog.Models.Articles
{
    using Common.Mapping;
    using Data.Models;
    using System;

    public class ArticleListingServiceModel : IMapFrom<Article>
    {
        public int Id { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Gallery Gallery { get; set; }
    }
}
