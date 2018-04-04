namespace Library.Web.Areas.LibraryBlog.Controllers
{
    using Infrastructure.Extensions;
    using Infrastructure.Filters;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models.Galleries;
    using Services.LibraryBlog;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Threading.Tasks;

    using static WebConstants;

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
                Galleries = await this.galleries.AllGalleriesAsync(CurrentCulture(), page),
                TotalGalleries = await this.galleries.TotalAsync(CurrentCulture()),
                CurrentPage = page
            });

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var gallery = await this.galleries.Details(id);

            var user = User.IsInRole(WebConstants.LibrarianAuthorRole);

            if (gallery.Show || user)
            {
                return this.View(new GalleryViewModel
                {
                    Gallery = gallery
                });

            }

            return RedirectToAction("Galleries", "Galleries");
        }


        public IActionResult Create()
            => this.View();

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Create(GalleryFormModel model)
        {
            if (model.Files == null || model.Files.Count == 0)
            {
                return Content("files not selected");
            }

            var imgPaths = new List<string>();

            foreach (var file in model.Files)
            {
                var path = Path.Combine(ImageFolderName, GalleriesImageFolderName, Guid.NewGuid() + file.GetFileType());
                var pathForUpload = Path.Combine(Directory.GetCurrentDirectory(), RootFolderName, path);

                using (var stream = new FileStream(pathForUpload, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                path = path.Replace("\\", "/");
                imgPaths.Add($"/{path}");
            }

            await this.galleries.CreateAsync(
                model.Title,
                imgPaths,
                model.Language
            );

            this.TempData.AddSuccessMessage(string.Format(TempDataCreateCommentText, ModelName, EndingLetterA));

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
                model.Title,
                model.Language,
                model.Show
            );

            this.TempData.AddSuccessMessage(string.Format(TempDataEditCommentText, ModelName, EndingLetterA));

            return this.RedirectToAction(nameof(this.Galleries));
        }

        public IActionResult Delete(GalleryDeleteViewModel model)
            => this.View(model);

        public async Task<IActionResult> Destroy(int id)
        {
            await this.galleries.DeleteAsync(id);

            this.TempData.AddSuccessMessage(string.Format(TempDataDeleteCommentText, ModelName, EndingLetterA));

            return this.RedirectToAction(nameof(this.Galleries));
        }

        private string CurrentCulture()
            => CultureInfo.CurrentCulture.Name;
    }
}