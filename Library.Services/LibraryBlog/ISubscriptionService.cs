namespace Library.Services.LibraryBlog
{
    using Data.Models;
    using Models.Subscriptions;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISubscriptionService
    {
        Task CreateAsync(string name, DepartmentType department, SubscriptionType type, Language language);

        Task EditAsync(int id, string name, DepartmentType department, SubscriptionType type, Language language);

        Task DeleteAsync(int id);

        Task<SubscriptionServiceModel> ByIdAsync(int id);

        Task<IEnumerable<SubscriptionListingServiceModel>> AllNewspapersAsync(string language);

        Task<IEnumerable<SubscriptionListingServiceModel>> AllMagazinesAsync(string language);

        Task<bool> UniqueCheckAsync(string name);
    }
}