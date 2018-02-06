namespace Library.Services.ViewComponents
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models.LatestBooks;

    public interface ILatestBooksService
    {
        Task<IEnumerable<LatestBookServiceModel>> LatestBooks();

        Task<IEnumerable<LatestBookServiceModel>> LatestBooksEn();
    }
}
