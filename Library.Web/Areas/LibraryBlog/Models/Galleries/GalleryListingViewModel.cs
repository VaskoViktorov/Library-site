namespace Library.Web.Areas.LibraryBlog.Models.Galleries
{
    using Services.LibraryBlog.Models.Galleries;
    using System.Collections.Generic;

    public class GalleryListingViewModel
    {
        public IEnumerable<GalleryServiceModel> Galleries { get; set; }

        public int TotalPages { get; set; }

        public int CurrentPage { get; set; }

        public int PreviousPage
            => this.CurrentPage == 1 ? 1 : this.CurrentPage - 1;

        public int NextPage
            => this.CurrentPage == this.TotalPages ? this.TotalPages : this.CurrentPage + 1;
    }
}