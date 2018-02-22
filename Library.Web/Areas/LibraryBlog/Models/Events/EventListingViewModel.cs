namespace Library.Web.Areas.LibraryBlog.Models.Events
{
    using System.Collections.Generic;
    using Search;

    public class EventListingViewModel : SearchFormModel
    {
        public IEnumerable<EventFormModel> Events { get; set; }
    }
}