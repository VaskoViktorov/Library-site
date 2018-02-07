namespace Library.Services.LibraryBlog.Models.Subscriptions
{
    using Data.Models;

    public class SubscriptionServiceModel : SubscriptionListingServiceModel
    {
        public SubscriptionType Type { get; set; }
    }
}