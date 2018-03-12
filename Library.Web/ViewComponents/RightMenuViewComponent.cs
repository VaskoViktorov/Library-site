namespace Library.Web.ViewComponents
{
    using Areas.LibraryBlog.Models.Surveys;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using System.Globalization;
    using System.IO;

    using static WebConstants;

    public class RightMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var filePath = string.Format(GetSurveysJsonPath(), Directory.GetCurrentDirectory());
            var surveys = ObjToJsonConverterExtensions.ListofSurveysInJsonFile(filePath);

            return this.View(new SurveyListingViewModel
            {
                Surveys = surveys
            });
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