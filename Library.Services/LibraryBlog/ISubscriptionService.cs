namespace Library.Services.LibraryBlog
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Data.Models;
    using Models.Subscriptions;


    public interface ISubscriptionService
    {
        Task CreateAsync(string name, string department, SubscriptionType type);

        Task EditAsync(int id, string name, string department, SubscriptionType type);

        Task DeleteAsync(int id);

        Task<SubscriptionServiceModel> ByIdAsync(int id);

        Task<IEnumerable<SubscriptionListingServiceModel>> AllNewspapersAsync();

        Task<IEnumerable<SubscriptionListingServiceModel>> AllMagazinesAsync();

        Task<bool> UniqueCheckAsync(string name);
    }
}
