namespace Library.Web.Areas.En.ViewComponents
{
    using System.Threading.Tasks;
    using Services.ViewComponents;
    using Microsoft.AspNetCore.Mvc;

    public class LatestGalleriesEnViewComponent : ViewComponent
    {
        private readonly ILatestGalleriesService galleries;

        public LatestGalleriesEnViewComponent(ILatestGalleriesService galleries)
        {
            this.galleries = galleries;
        }
        public async Task<IViewComponentResult> InvokeAsync()
            => View(await galleries.LatestGalleries());
    }
}
