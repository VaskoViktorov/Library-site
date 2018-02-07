namespace Library.Web.Areas.En.Controllers
{
    using Infrastructure.Extensions;
    using LibraryBlog.Models.Surveys;
    using Microsoft.AspNetCore.Mvc;
    using System.IO;

    using static WebConstants;

    [Area(EnglishAreaName)]
    public class SurveysController : Controller
    {
        public IActionResult Survey(string id)
        {
            var filePath = string.Format(WebConstants.SurveysEnJasonDbPath, Directory.GetCurrentDirectory());
            var surveys = ObjToJsonConverterExtensions.FindSurveyInJsonFile(filePath, id);

            return this.View(new SurveyFormModel()
            {
                id = surveys.id,
                url = surveys.url
            });
        }
    }
}