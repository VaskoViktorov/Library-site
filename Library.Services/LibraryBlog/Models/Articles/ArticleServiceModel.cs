using Library.Data.Models;

namespace Library.Services.LibraryBlog.Models.Articles
{
    public class ArticleServiceModel: ArticleListingServiceModel
    {
        public DepartmentType Type { get; set; }
    }
}
