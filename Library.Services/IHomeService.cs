namespace Library.Services
{
    using Models.Home;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IHomeService
    {
        Task<IEnumerable<ArticleListingHomeServiceModel>> LatestFourArticlesAsync();

        Task<IEnumerable<ArticleListingHomeServiceModel>> LatestFourArticlesEnAsync();
    }
}