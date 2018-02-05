using System.Reflection.Metadata;

namespace Library.Web.Areas.LibraryBlog.Controllers
{
    using Infrastructure.Extensions;
    using Infrastructure.Filters;
    using Microsoft.AspNetCore.Mvc;
    using Models.Events;
    using Services.Html;
    using System;
    using System.IO;
    using System.Linq;

    public class EventsController : BaseController
    {
        private const string ModelName = "Събитието";

        private readonly IHtmlService html;

        public EventsController(IHtmlService html)
        {
            this.html = html;
        }

        public IActionResult Create()
            => this.View();

        [HttpPost]
        [ValidateModelState]
        public IActionResult Create(EventFormModel model)
        {
            model.title = this.html.Sanitize(model.title);
            model.description = this.html.Sanitize(model.description);
            model.id = Guid.NewGuid().ToString();
            model.date = model.date.Replace("T", " ") + ":00";

            var filePath = string.Format(WebConstants.CallendarJasonDbPath, Directory.GetCurrentDirectory());

            if (!ObjToJsonConverterExtensions.CreateEventInJsonFile(model, filePath))
            {
                this.TempData.AddWarningMessage(string.Format(WebConstants.TempDataCreateFailText, ModelName, "о"));

                return this.RedirectToAction(nameof(this.Create));
            }

            this.TempData.AddSuccessMessage(string.Format(WebConstants.TempDataCreateCommentText, ModelName, "о"));

            return this.RedirectToAction(nameof(this.Events));
        }

        public IActionResult Events(int page = 1)
        {
            var filePath = string.Format(WebConstants.CallendarJasonDbPath, Directory.GetCurrentDirectory());
            var events = ObjToJsonConverterExtensions.ListofEventsInJsonFile(filePath)
                .OrderByDescending(e => e.date);

            return this.View(new EventListingViewModel
            {
                Events = events
            });
        }

        public IActionResult Edit(string id)
        {
            var filePath = string.Format(WebConstants.CallendarJasonDbPath, Directory.GetCurrentDirectory());

            var currEvent = ObjToJsonConverterExtensions.FindEventInJsonFile(filePath, id);

            return this.View(new EventFormModel()
            {
                id = currEvent.id,
                date = currEvent.date,
                title = currEvent.title,
                description = currEvent.description,
                url=currEvent.url
            });
        }

        [HttpPost]
        [ValidateModelState]
        public IActionResult Edit(EventFormModel model)
        {
            var filePath = string.Format(WebConstants.CallendarJasonDbPath, Directory.GetCurrentDirectory());
            model.date = model.date.Replace("T", " ") + ":00";
            if (!ObjToJsonConverterExtensions.EditEventInJsonFile(filePath, model))
            {
                this.TempData.AddWarningMessage(string.Format(WebConstants.TempDataEditFailText, ModelName, "о"));

                return this.RedirectToAction(nameof(this.Edit));
            }

            this.TempData.AddSuccessMessage(string.Format(WebConstants.TempDataEditCommentText, ModelName, "o"));

            return this.RedirectToAction(nameof(this.Events));
        }

        public IActionResult Delete(string id)
        => this.View(model:id);
                  
        public IActionResult Destroy(string id)
        {
            var filePath = string.Format(WebConstants.CallendarJasonDbPath, Directory.GetCurrentDirectory());

            if (!ObjToJsonConverterExtensions.DeleteEventInJsonFile(filePath, id))
            {
                this.TempData.AddWarningMessage(string.Format(WebConstants.TempDataDeleteFailText, ModelName, "о"));

                return this.RedirectToAction(nameof(this.Edit));
            }

            this.TempData.AddSuccessMessage(string.Format(WebConstants.TempDataDeleteCommentText, ModelName, "o"));

            return this.RedirectToAction(nameof(this.Events));
        }
    }
}
