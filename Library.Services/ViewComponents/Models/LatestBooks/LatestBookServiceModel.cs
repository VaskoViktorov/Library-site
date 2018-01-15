namespace Library.Services.ViewComponents.Models.LatestBooks
{
    using Common.Mapping;
    using Data.Models;

    public class LatestBookServiceModel : IMapFrom<Book>
    {
        public int Id { get; set; }

        public string BookTitle { get; set; }

        public string ImageUrl { get; set; }
    }
}
