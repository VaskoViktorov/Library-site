namespace Library.Web.Areas.LibraryBlog.Controllers
{
    using Services.LibraryBlog;
    using Models.Galleries;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Infrastructure.Extensions;
    using Infrastructure.Filters;

    public class GalleriesController : BaseController
    {
        private const string ModelName = "Галерията";

        private readonly IGalleryService galleries;

        public GalleriesController(IGalleryService galleries)
        {
            this.galleries = galleries;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Galleries(int page = 1)
            => this.View(new GalleryListingViewModel
            {
                Galleries = await this.galleries.AllGalleriesAsync(page),
                TotalGalleries = await this.galleries.TotalAsync(),
                CurrentPage = page
            });

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
            => this.View(new GalleryViewModel
            {
                Gallery = await this.galleries.Details(id)
            });

        public IActionResult Create()
            => this.View();

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Create(GalleryFormModel model)
        {
            
            if (model.Files == null || model.Files.Count == 0)
                return Content("files not selected");

            var imgPaths = new List<string>();

            foreach (var file in model.Files)
            {

                var path = Path.Combine("images", "GalleryImages", Guid.NewGuid() + file.GetFileType());
                var pathForUpload = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", path);

                using (var stream = new FileStream(pathForUpload, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                imgPaths.Add($"\\{path}");
            }

            await this.galleries.CreateAsync(
                model.Title,
                imgPaths
            );

            this.TempData.AddSuccessMessage(string.Format(WebConstants.TempDataCreateCommentText, ModelName, "a"));

            return this.RedirectToAction(nameof(this.Galleries));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var gallery = await this.galleries.ByIdAsync(id);

            if (gallery == null)
            {
                return this.NotFound();
            }

            return this.View(new GalleryFormModel
            {
                Title = gallery.Title
            });
        }

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Edit(int id, GalleryFormModel model)
        {
            await this.galleries.EditAsync(
                id,
                model.Title
            );

            this.TempData.AddSuccessMessage(string.Format(WebConstants.TempDataEditCommentText, ModelName, "a"));

            return this.RedirectToAction(nameof(this.Galleries));
        }

        public IActionResult Delete(int id)
            => this.View(id);

        public async Task<IActionResult> Destroy(int id)
        {
            await this.galleries.DeleteAsync(id);

            this.TempData.AddSuccessMessage(string.Format(WebConstants.TempDataDeleteCommentText, ModelName, "a"));

            return this.RedirectToAction(nameof(this.Galleries));
        }
    }
}
