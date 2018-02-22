namespace Library.Web.Areas.LibraryBlog.Models.Surveys
{
    using System.Collections.Generic;
    using Search;

    public class SurveyListingViewModel : SearchFormModel
    {
        public IEnumerable<SurveyFormModel> Surveys { get; set; }
    }
}