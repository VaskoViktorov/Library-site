namespace Library.Web.Areas.LibraryBlog.Models.Galleries
{
    using Services.LibraryBlog.Models.Galleries;
    using System;
    using System.Collections.Generic;
    using Search;

    using static Services.ServicesConstants;

    public class GalleryListingViewModel : SearchFormModel
    {
        public IEnumerable<GalleryServiceModel> Galleries { get; set; }

        public int TotalGalleries { get; set; }

        public int TotalPages
            => (int)Math.Ceiling((double)this.TotalGalleries / GalleriesPageSize);

        public int CurrentPage { get; set; }

        public int PreviousPage
            => this.CurrentPage == 1 ? 1 : this.CurrentPage - 1;

        public int NextPage
            => this.CurrentPage == this.TotalPages ? this.TotalPages : this.CurrentPage + 1;
    }
}