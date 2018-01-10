namespace Library.Web.Areas.LibraryBlog.Models
{
    using System.Collections.Generic;
    using Services.LibraryBlog.Models.Subscriptions;

    public class SubscriptionListingViewModel
    {
        public IEnumerable<SubscriptionListingServiceModel> Newspapers { get; set; }

        public IEnumerable<SubscriptionListingServiceModel> Magazines { get; set; }
    }
}
