using System.Threading.Tasks;
using Library.Services.ViewComponents;
using Microsoft.AspNetCore.Mvc;

namespace Library.Web.ViewComponents
{
    public class LatestGalleriesViewComponent : ViewComponent
    {
        private readonly ILatestGalleriesService galleries;

        public LatestGalleriesViewComponent(ILatestGalleriesService galleries)
        {
            this.galleries = galleries;
        }
        public async Task<IViewComponentResult> InvokeAsync()
            => View(await galleries.LatestGalleries());
    }
}
