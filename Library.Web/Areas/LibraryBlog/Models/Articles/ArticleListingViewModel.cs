

namespace Library.Web.Areas.LibraryBlog.Models.Articles
{
    using System;
    using System.Collections.Generic;
    using Services.LibraryBlog.Models.Articles;
    using static Services.ServicesConstants;

    public class ArticleListingViewModel
    {
        public IEnumerable<ArticleListingServiceModel> Articles { get; set; }

        public int TotalArticles { get; set; }

        public int TotalPages
            => (int)Math.Ceiling((double)this.TotalArticles / PageSize);

        public int CurrentPage { get; set; }

        public int PreviousPage
            => this.CurrentPage == 1 ? 1 : this.CurrentPage - 1;

        public int NextPage
            => this.CurrentPage == this.TotalPages ? this.TotalPages : this.CurrentPage + 1;
    }
}
