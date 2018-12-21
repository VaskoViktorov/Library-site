namespace Library.Web.Areas.LibraryBlog.Controllers
{
    using Infrastructure.Extensions;
    using Infrastructure.Filters;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models.Surveys;
    using System.Globalization;
    using System.IO;

    using static WebConstants;

    public class SurveysController : BaseController
    {
        private const string ModelName = SurveyBgModelName;

        [AllowAnonymous]
        public IActionResult Survey(string id)
        {
            var filePath = string.Format(GetSurveysJsonPath(), Directory.GetCurrentDirectory());
            var surveys = ObjToJsonConverterExtensions.FindSurveyInJsonFile(filePath, id);

            return this.View(new SurveyFormModel()
            {
                id = surveys.id,
                url = surveys.url
            });
        }

        public IActionResult Edit(string id)
        {
            var filePath = string.Format(GetSurveysJsonPath(), Directory.GetCurrentDirectory());
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
            var filePath = string.Format(GetSurveysJsonPath(), Directory.GetCurrentDirectory());

            if (!ObjToJsonConverterExtensions.EditSurveyInJsonFile(filePath, model))
            {
                this.TempData.AddWarningMessage(string.Format(TempDataEditFailText, ModelName, EndingLetterO));

                return this.RedirectToAction(nameof(this.Edit));
            }

            this.TempData.AddSuccessMessage(string.Format(TempDataEditCommentText, ModelName, EndingLetterO));

            return this.RedirectToAction("Articles", nameof(ArticlesController.Articles));
        }

        private string GetSurveysJsonPath()
        {
            var currCulture = CultureInfo.CurrentCulture.Name;

            if (currCulture == BulgarianCulture)
            {
                return SurveysJasonDbPath;
            }

            return SurveysEnJasonDbPath;
        }
    }
}