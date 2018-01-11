using Library.Common.Mapping;
using Library.Data.Models;

namespace Library.Services.LibraryBlog.Models.Books
{
   public class BookListingServiceModel : IMapFrom<Book>
    {
        public int Id { get; set; }

        public string AuthorFirstName { get; set; }

        public string AuthorLastName { get; set; }

        public string BookTitle { get; set; }

        public string ImageUrl { get; set; }

        public DepartmentType Department { get; set; }
    }
}
