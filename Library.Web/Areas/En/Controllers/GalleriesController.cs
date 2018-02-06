namespace Library.Web.Areas.En.Controllers
{
    using Services.LibraryBlog;
    using LibraryBlog.Models.Galleries;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    using static WebConstants;

    [Area(EnglishAreaName)]
    public class GalleriesController : Controller
    {
        private readonly IGalleryService galleries;

        public GalleriesController(IGalleryService galleries)
        {
            this.galleries = galleries;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Galleries(int page = 1)
            => this.View(new GalleryListingViewModel
            {
                Galleries = await this.galleries.AllGalleriesEnAsync(page),
                TotalGalleries = await this.galleries.TotalEnAsync(),
                CurrentPage = page
            });

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
            => this.View(new GalleryViewModel
            {
                Gallery = await this.galleries.Details(id)
            });
    }
}
