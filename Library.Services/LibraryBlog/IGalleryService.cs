namespace Library.Services.LibraryBlog
{
    using Data.Models;
    using Models.Galleries;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IGalleryService
    {
        Task CreateAsync(string title, List<string> gallery, Language language);

        Task EditAsync(int id, string title, Language language);

        Task DeleteAsync(int id);

        Task<GalleryServiceModel> ByIdAsync(int id);

        Task<GalleryServiceModel> Details(int id);

        Task<IEnumerable<GalleryServiceModel>> AllGalleriesAsync(int page = 1);

        Task<int> TotalAsync();

        //English

        Task<IEnumerable<GalleryServiceModel>> AllGalleriesEnAsync(int page = 1);

        Task<int> TotalEnAsync();
    }
}