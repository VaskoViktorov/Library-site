namespace Library.Services.LibraryBlog
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models.Galleries;

    public interface IGalleryService
    {
        Task CreateAsync(string title, List<string> gallery);

        Task EditAsync(int id, string title);

        Task DeleteAsync(int id);

        Task<GalleryServiceModel> ByIdAsync(int id);

        Task<GalleryServiceModel> Details(int id);

        Task<IEnumerable<GalleryServiceModel>> AllGalleriesAsync(int page = 1);

        Task<int> TotalAsync();
    }
}
