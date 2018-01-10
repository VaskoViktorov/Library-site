using System.Collections.Generic;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Library.Services.LibraryBlog.Models.Subscriptions;
using Microsoft.EntityFrameworkCore;

namespace Library.Services.LibraryBlog.Implementations
{
    using System.Threading.Tasks;
    using Data;
    using Data.Models;

    public class SubscriptionService : ISubscriptionService
    {
        private readonly LibraryDbContext db;

        public SubscriptionService(LibraryDbContext db)
        {
            this.db = db;
        }

        public async Task Create(string name, string department, SubscriptionType type)
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

        public async Task Edit(int id, string name, string department, SubscriptionType type)
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

        public async Task Delete(int id)
        {
            var subscription = await this.db.Subscriptions.FindAsync(id);

            if (subscription == null)
            {
                return;
            }

            this.db.Subscriptions.Remove(subscription);

            await this.db.SaveChangesAsync();
        }

        public async Task<SubscriptionServiceModel> ById(int id)
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
