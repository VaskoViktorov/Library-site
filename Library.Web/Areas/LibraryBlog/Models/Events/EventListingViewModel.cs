using System.Collections.Generic;

namespace Library.Web.Areas.LibraryBlog.Models.Events
{
    public class EventListingViewModel
    {
        public IEnumerable<EventFormModel> Events { get; set; }
    }
}
