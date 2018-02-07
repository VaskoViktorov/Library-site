namespace Library.Web.Areas.En.ViewComponents
{
    using Infrastructure.Extensions;
    using LibraryBlog.Models.Surveys;
    using Microsoft.AspNetCore.Mvc;
    using System.IO;

    public class RightMenuEnViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var filePath = string.Format(WebConstants.SurveysEnJasonDbPath, Directory.GetCurrentDirectory());
            var surveys = ObjToJsonConverterExtensions.ListofSurveysInJsonFile(filePath);

            return this.View(new SurveyListingViewModel
            {
                Surveys = surveys
            });
        }
    }
}