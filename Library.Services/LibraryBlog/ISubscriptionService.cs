namespace Library.Services.LibraryBlog
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Data.Models;
    using Models.Subscriptions;


    public interface ISubscriptionService
    {
        Task CreateAsync(string name, DepartmentType department, SubscriptionType type, Language language);

        Task EditAsync(int id, string name, DepartmentType department, SubscriptionType type, Language language);

        Task DeleteAsync(int id);

        Task<SubscriptionServiceModel> ByIdAsync(int id);

        Task<IEnumerable<SubscriptionListingServiceModel>> AllNewspapersAsync();

        Task<IEnumerable<SubscriptionListingServiceModel>> AllMagazinesAsync();

        Task<IEnumerable<SubscriptionListingServiceModel>> AllNewspapersEnAsync();

        Task<IEnumerable<SubscriptionListingServiceModel>> AllMagazinesEnAsync();
        Task<bool> UniqueCheckAsync(string name);
    }
}
