namespace Library.Services.LibraryBlog
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Data.Models;
    using Models.Subscriptions;


    public interface ISubscriptionService
    {
        Task Create(string name, string department, SubscriptionType type);

        Task Edit(int id, string name, string department, SubscriptionType type);

        Task Delete(int id);

        Task<SubscriptionServiceModel> ById(int id);

        Task<IEnumerable<SubscriptionListingServiceModel>> AllNewspapersAsync();

        Task<IEnumerable<SubscriptionListingServiceModel>> AllMagazinesAsync();

        Task<bool> UniqueCheckAsync(string name);
    }
}
