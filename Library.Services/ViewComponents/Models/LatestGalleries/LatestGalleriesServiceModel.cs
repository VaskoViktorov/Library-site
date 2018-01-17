namespace Library.Services.ViewComponents.Models.LatestGalleries
{
    using Common.Mapping;
    using Data.Models;
    using System.Collections.Generic;

    public class LatestGalleriesServiceModel : IMapFrom<Gallery>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public List<Image> Images { get; set; } = new List<Image>();
    }
}
