namespace Library.Web.Areas.LibraryBlog.Controllers
{
    using Infrastructure.Extensions;
    using Infrastructure.Filters;
    using Services;
    using Microsoft.AspNetCore.Mvc;
    using Models.Events;
    using Services.Html;
    using System;
    using System.IO;
    using System.Linq;

    using static WebConstants;

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
            model.date = NewFormatDate(model.date);

            var filePath = string.Format(CallendarJasonDbPath, Directory.GetCurrentDirectory());

            if (!ObjToJsonConverterExtensions.CreateEventInJsonFile(model, filePath))
            {
                this.TempData.AddWarningMessage(string.Format(TempDataCreateFailText, ModelName, EndingLetterO));

                return this.RedirectToAction(nameof(this.Create));
            }

            this.TempData.AddSuccessMessage(string.Format(TempDataCreateCommentText, ModelName, EndingLetterO));

            return this.RedirectToAction(nameof(this.Events));
        }

        public IActionResult Events(int page = 1)
        {
            var filePath = string.Format(CallendarJasonDbPath, Directory.GetCurrentDirectory());
            var events = ObjToJsonConverterExtensions.ListofEventsInJsonFile(filePath).OrderByDescending(e => e.date);
            var totalEvents = events.Count();
            var eventsPerPage = (int)Math.Ceiling((double)totalEvents / ServicesConstants.EventsPageSize);

            if (page > eventsPerPage || page <= 0)
            {
                return this.RedirectToAction(nameof(this.Events));
            }

            return this.View(new EventListingViewModel
            {
                Events = events,
                TotalPages = eventsPerPage,
                CurrentPage = page
            });
        }

        public IActionResult Edit(string id)
        {
            var filePath = string.Format(CallendarJasonDbPath, Directory.GetCurrentDirectory());
            var currEvent = ObjToJsonConverterExtensions.FindEventInJsonFile(filePath, id);

            return this.View(new EventFormModel()
            {
                id = currEvent.id,
                date = currEvent.date,
                title = currEvent.title,
                description = currEvent.description,
                url = currEvent.url
            });
        }

        [HttpPost]
        [ValidateModelState]
        public IActionResult Edit(EventFormModel model)
        {
            var filePath = string.Format(CallendarJasonDbPath, Directory.GetCurrentDirectory());

            model.date = NewFormatDate(model.date);

            if (!ObjToJsonConverterExtensions.EditEventInJsonFile(filePath, model))
            {
                this.TempData.AddWarningMessage(string.Format(TempDataEditFailText, ModelName, EndingLetterO));

                return this.RedirectToAction(nameof(this.Edit));
            }

            this.TempData.AddSuccessMessage(string.Format(TempDataEditCommentText, ModelName, EndingLetterO));

            return this.RedirectToAction(nameof(this.Events));
        }

        public IActionResult Delete(EventDeleteViewModel model)
        => this.View(model);

        public IActionResult Destroy(string id)
        {
            var filePath = string.Format(CallendarJasonDbPath, Directory.GetCurrentDirectory());

            if (!ObjToJsonConverterExtensions.DeleteEventInJsonFile(filePath, id))
            {
                this.TempData.AddWarningMessage(string.Format(TempDataDeleteFailText, ModelName, EndingLetterO));

                return this.RedirectToAction(nameof(this.Edit));
            }

            this.TempData.AddSuccessMessage(string.Format(TempDataDeleteCommentText, ModelName, EndingLetterO));

            return this.RedirectToAction(nameof(this.Events));
        }

        private string NewFormatDate(string date)
        => date.Replace("T", " ") + ":00";
    }
}