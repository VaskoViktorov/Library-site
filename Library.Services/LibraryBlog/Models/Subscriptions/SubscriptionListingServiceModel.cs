namespace Library.Services.LibraryBlog.Models.Subscriptions
{
    using Common.Mapping;
    using Data.Models;

    public class SubscriptionListingServiceModel : IMapFrom<Subscription>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DepartmentType Department { get; set; }

        public Language Language { get; set; }
    }
}
