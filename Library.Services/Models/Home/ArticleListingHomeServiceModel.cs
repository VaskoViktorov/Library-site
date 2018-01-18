using Library.Common.Mapping;
using Library.Data.Models;

namespace Library.Services.Models.Home
{
   public class ArticleListingHomeServiceModel : IMapFrom<Article>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Gallery Gallery { get; set; }
    }
}
