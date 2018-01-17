using Library.Common.Mapping;
using Library.Data.Models;

namespace Library.Services.LibraryBlog.Models.Subscriptions
{
   public class SubscriptionListingServiceModel : IMapFrom<Subscription>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DepartmentType Department { get; set; }
    }
}
