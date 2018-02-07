namespace Library.Web.Areas.LibraryBlog.Controllers
{
    using Infrastructure.Extensions;
    using Infrastructure.Filters;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models.Surveys;
    using System.IO;

    public class SurveysController : BaseController
    {
        private const string ModelName = "Анкетата";

        [AllowAnonymous]
        public IActionResult Survey(string id)
        {
            var filePath = string.Format(WebConstants.SurveysJasonDbPath, Directory.GetCurrentDirectory());
            var surveys = ObjToJsonConverterExtensions.FindSurveyInJsonFile(filePath, id);

            return this.View(new SurveyFormModel()
            {
                id = surveys.id,
                url = surveys.url
            });
        }

        public IActionResult Edit(string id)
        {
            var filePath = string.Format(WebConstants.SurveysJasonDbPath, Directory.GetCurrentDirectory());

            var currSurvey = ObjToJsonConverterExtensions.FindSurveyInJsonFile(filePath, id);

            return this.View(new SurveyFormModel()
            {
                id = currSurvey.id,
                url = currSurvey.url
            });
        }

        [HttpPost]
        [ValidateModelState]
        public IActionResult Edit(SurveyFormModel model)
        {
            var filePath = string.Format(WebConstants.SurveysJasonDbPath, Directory.GetCurrentDirectory());

            if (!ObjToJsonConverterExtensions.EditSurveyInJsonFile(filePath, model))
            {
                this.TempData.AddWarningMessage(string.Format(WebConstants.TempDataEditFailText, ModelName, "о"));

                return this.RedirectToAction(nameof(this.Edit));
            }

            this.TempData.AddSuccessMessage(string.Format(WebConstants.TempDataEditCommentText, ModelName, "o"));

            return this.RedirectToAction("Articles", "Articles");
        }
    }
}