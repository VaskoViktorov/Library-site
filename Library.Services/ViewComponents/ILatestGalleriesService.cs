namespace Library.Services.ViewComponents
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models.LatestGalleries;

    public interface ILatestGalleriesService
    {
        Task<IEnumerable<LatestGalleriesServiceModel>> LatestGalleries();
    }
}
