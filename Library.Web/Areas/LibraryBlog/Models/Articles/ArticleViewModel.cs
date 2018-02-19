namespace Library.Web.Areas.LibraryBlog.Models.Articles
{
    using Services.LibraryBlog.Models.Articles;
    using Search;

    public class ArticleViewModel : SearchFormModel
    {
        public ArticleServiceModel Article { get; set; }
    }
}