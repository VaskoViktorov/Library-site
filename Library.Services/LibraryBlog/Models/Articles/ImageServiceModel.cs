namespace Library.Services.LibraryBlog.Models.Articles
{
    using Common.Mapping;
    using Data.Models;

    public class ImageServiceModel : IMapFrom<Image>
    {
        public int Id { get; set; }

        public string ImagePath { get; set; }

        public int GalleryId { get; set; }
    }
}