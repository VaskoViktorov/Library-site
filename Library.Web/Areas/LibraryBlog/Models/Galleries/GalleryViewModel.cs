namespace Library.Web.Areas.LibraryBlog.Models.Galleries
{
    using Services.LibraryBlog.Models.Galleries;
    using Search;

    public class GalleryViewModel : SearchFormModel

    {
    public GalleryServiceModel Gallery { get; set; }
    }
}