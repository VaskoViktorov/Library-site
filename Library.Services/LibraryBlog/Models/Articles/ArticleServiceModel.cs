namespace Library.Services.LibraryBlog.Models.Articles
{
    using Data.Models;

    public class ArticleServiceModel : ArticleListingServiceModel
    {
        public DepartmentType Type { get; set; }

        public string AuthorName { get; set; }
    }
}