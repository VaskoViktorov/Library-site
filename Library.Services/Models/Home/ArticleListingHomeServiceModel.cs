namespace Library.Services.Models.Home
{
    using Common.Mapping;
    using Data.Models;

    public class ArticleListingHomeServiceModel : IMapFrom<Article>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Gallery Gallery { get; set; }

        public Language Language { get; set; }
    }
}