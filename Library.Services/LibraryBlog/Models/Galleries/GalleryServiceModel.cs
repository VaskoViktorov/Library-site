namespace Library.Services.LibraryBlog.Models.Galleries
{
    using Common.Mapping;
    using Data.Models;
    using System.Collections.Generic;

   public class GalleryServiceModel : IMapFrom<Gallery>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public List<Image> Images { get; set; } = new List<Image>();

        public Language Language { get; set; }
    }
}
