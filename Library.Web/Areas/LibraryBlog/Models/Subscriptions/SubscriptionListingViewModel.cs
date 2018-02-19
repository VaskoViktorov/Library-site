namespace Library.Web.Areas.LibraryBlog.Models.Subscriptions
{
    using Services.LibraryBlog.Models.Subscriptions;
    using System.Collections.Generic;
    using Search;

    public class SubscriptionListingViewModel : SearchFormModel
    {
        public IEnumerable<SubscriptionListingServiceModel> Newspapers { get; set; }

        public IEnumerable<SubscriptionListingServiceModel> Magazines { get; set; }
    }
}