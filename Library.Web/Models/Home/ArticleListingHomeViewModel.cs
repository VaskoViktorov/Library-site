namespace Library.Web.Models.Home
{
    using Services.Models.Home;
    using System.Collections.Generic;

    public class ArticleListingHomeViewModel
    {
        public IEnumerable<ArticleListingHomeServiceModel> Articles { get; set; }
    }
}
