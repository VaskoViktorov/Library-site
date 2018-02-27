namespace Library.Web.Areas.LibraryBlog.Models.Surveys
{
    using System.Collections.Generic;

    public class SurveyListingViewModel
    {
        public IEnumerable<SurveyFormModel> Surveys { get; set; }
    }
}