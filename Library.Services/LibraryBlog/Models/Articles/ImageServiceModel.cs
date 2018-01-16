using Library.Common.Mapping;
using Library.Data.Models;

namespace Library.Services.LibraryBlog.Models.Articles
{
   public class ImageServiceModel : IMapFrom<Image>
    {
        public int Id { get; set; }

        public string ImagePath { get; set; }

        public int GalleryId { get; set; }
    }
}
