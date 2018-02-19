namespace Library.Web.ViewComponents
{
    using Areas.LibraryBlog.Models.Surveys;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using System.IO;

    public class RightMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var filePath = string.Format(WebConstants.SurveysJasonDbPath, Directory.GetCurrentDirectory());
            var surveys = ObjToJsonConverterExtensions.ListofSurveysInJsonFile(filePath);

            return this.View(new SurveyListingViewModel
            {
                Surveys = surveys
            });
        }
    }
}