namespace Library.Web.Areas.LibraryBlog.Models.Books
{
    using Services.LibraryBlog.Models.Books;
    using Search;

    public class BookViewModel : SearchFormModel
    {
        public BookServiceModel Book { get; set; }
    }
}