namespace Library.Services.LibraryBlog.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Models.Subscriptions;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;


    public class SubscriptionService : ISubscriptionService
    {
        private readonly LibraryDbContext db;

        public SubscriptionService(LibraryDbContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(string name, string department, SubscriptionType type)
        {
            var subscription = new Subscription
            {
                Name = name,
                Department = department,
                Type = type
            };

            this.db.Add(subscription);
            await this.db.SaveChangesAsync();
        }

        public async Task EditAsync(int id, string name, string department, SubscriptionType type)
        {
            var subscription = await this.db.Subscriptions.FindAsync(id);

            if (subscription == null)
            {
                return;
            }
           
            subscription.Name = name;
            subscription.Department = department;
            subscription.Type = type;

            await this.db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var subscription = await this.db.Subscriptions.FindAsync(id);

            if (subscription == null)
            {
                return;
            }

            this.db.Subscriptions.Remove(subscription);

            await this.db.SaveChangesAsync();
        }

        public async Task<SubscriptionServiceModel> ByIdAsync(int id)
            => await this.db
                .Subscriptions
                .Where(a => a.Id == id)
                .ProjectTo<SubscriptionServiceModel>()
                .FirstOrDefaultAsync();

        public async Task<IEnumerable<SubscriptionListingServiceModel>> AllNewspapersAsync()
            => await this.db
                .Subscriptions
                .OrderBy(a => a.Name)
                .Where(a => a.Type == SubscriptionType.Newspaper)
                .ProjectTo<SubscriptionListingServiceModel>()
                .ToListAsync();

        public async Task<IEnumerable<SubscriptionListingServiceModel>> AllMagazinesAsync()
            => await this.db
                .Subscriptions
                .OrderBy(a => a.Name)
                .Where(a => a.Type == SubscriptionType.Magazine)
                .ProjectTo<SubscriptionListingServiceModel>()
                .ToListAsync();

        public async Task<bool> UniqueCheckAsync(string name)
        {
            if (await this.db.Subscriptions.AnyAsync(a => a.Name == name))
            {
                return true;
            }

            return false;
        }
    }
}
