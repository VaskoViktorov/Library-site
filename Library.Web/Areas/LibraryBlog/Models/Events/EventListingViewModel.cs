namespace Library.Web.Areas.LibraryBlog.Models.Events
{
    using System.Collections.Generic;

    public class EventListingViewModel
    {
        public IEnumerable<EventFormModel> Events { get; set; }
    }
}