namespace Library.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models.Home;

    public interface IHomeService
    {
        Task<IEnumerable<ArticleListingHomeServiceModel>> LatestFourArticlesAsync();

        Task<IEnumerable<ArticleListingHomeServiceModel>> LatestFourArticlesEnAsync();
    }
}
