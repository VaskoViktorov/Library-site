using Library.Web.Areas.LibraryBlog.Models.Search;

namespace Library.Web.Models.Home
{
    using Services.Models.Home;
    using System.Collections.Generic;

    public class ArticleListingHomeViewModel : SearchFormModel
    {
        public IEnumerable<ArticleListingHomeServiceModel> Articles { get; set; }
    }
}