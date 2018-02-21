namespace Library.Services.ViewComponents
{
    using Models.LatestBooks;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ILatestBooksService
    {
        Task<IEnumerable<LatestBookServiceModel>> LatestBooks(string language);

        Task<IEnumerable<LatestBookServiceModel>> LatestBooksEn();
    }
}