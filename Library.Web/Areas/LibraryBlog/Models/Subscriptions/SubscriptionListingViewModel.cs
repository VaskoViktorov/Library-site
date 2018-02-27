namespace Library.Web.Areas.LibraryBlog.Models.Subscriptions
{
    using Services.LibraryBlog.Models.Subscriptions;
    using System.Collections.Generic;

    public class SubscriptionListingViewModel
    {
        public IEnumerable<SubscriptionListingServiceModel> Newspapers { get; set; }

        public IEnumerable<SubscriptionListingServiceModel> Magazines { get; set; }
    }
}