namespace Library.Web.Areas.LibraryBlog.Controllers
{
    using Services;
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
        {
            var totalPages = (int) Math.Ceiling((double) galleries.TotalAsync(CurrentCulture()).Result /
                                                ServicesConstants.GalleriesPageSize);               

            if (page > totalPages || page <= 0)
            {
                return this.RedirectToAction(nameof(this.Galleries));
            }

            if (User.IsInRole(AdministratorRole))
            {
                return this.View(new GalleryListingViewModel
                {
                    Galleries = await this.galleries.AllGalleriesAdminAsync(CurrentCulture(), page),
                    TotalPages = totalPages,
                    CurrentPage = page
                });
            }

            return this.View(new GalleryListingViewModel
            {
                Galleries = await this.galleries.AllGalleriesAsync(CurrentCulture(), page),
                TotalPages = totalPages,
                CurrentPage = page
            });
        }
        
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var gallery = await this.galleries.Details(id);

            if (gallery == null)
            {
                return RedirectToAction(nameof(this.Galleries));
            }

            var user = User.IsInRole(LibrarianAuthorRole);
            
            if (gallery.Show || user)
            {
                return this.View(new GalleryViewModel
                {
                    Gallery = gallery
                });

            }

            return RedirectToAction(nameof(this.Galleries));
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