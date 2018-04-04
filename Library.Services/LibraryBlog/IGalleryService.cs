namespace Library.Services.LibraryBlog
{
    using Data.Models;
    using Models.Galleries;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IGalleryService
    {
        Task CreateAsync(string title, List<string> gallery, Language language);

        Task EditAsync(int id, string title, Language language, bool show);

        Task DeleteAsync(int id);

        Task<GalleryServiceModel> ByIdAsync(int id);

        Task<GalleryServiceModel> Details(int id);

        Task<IEnumerable<GalleryServiceModel>> AllGalleriesAsync(string language, int page = 1);

        Task<int> TotalAsync(string language);
    }
}