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
    using Common.Infrastructure;

    public class SubscriptionService : ISubscriptionService
    {
        private readonly LibraryDbContext db;

        public SubscriptionService(LibraryDbContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(string name, DepartmentType department, SubscriptionType type, Language language)
        {
            var subscription = new Subscription
            {
                Name = name,
                Department = department,
                Type = type,
                Language = language
            };

            this.db.Add(subscription);
            await this.db.SaveChangesAsync();
        }

        public async Task EditAsync(int id, string name, DepartmentType department, SubscriptionType type, Language language)
        {
            var subscription = await this.db.Subscriptions.FindAsync(id);

            if (subscription == null)
            {
                return;
            }

            subscription.Name = name;
            subscription.Department = department;
            subscription.Type = type;
            subscription.Language = language;

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
                .Where(s => s.Id == id)
                .ProjectTo<SubscriptionServiceModel>()
                .FirstOrDefaultAsync();

        public async Task<IEnumerable<SubscriptionListingServiceModel>> AllNewspapersAsync(string language)
            => await this.db
                .Subscriptions
                .OrderBy(n => n.Name)
                .Where(n => n.Type == SubscriptionType.Newspaper && n.Language == (Language)language.ParseLang())
                .ProjectTo<SubscriptionListingServiceModel>()
                .ToListAsync();

        public async Task<IEnumerable<SubscriptionListingServiceModel>> AllMagazinesAsync(string language)
            => await this.db
                .Subscriptions
                .OrderBy(m => m.Name)
                .Where(m => m.Type == SubscriptionType.Magazine && m.Language == (Language)language.ParseLang())
                .ProjectTo<SubscriptionListingServiceModel>()
                .ToListAsync();


        public async Task<IEnumerable<SubscriptionListingServiceModel>> AllNewspapersEnAsync()
            => await this.db
                .Subscriptions
                .OrderBy(a => a.Name)
                .Where(a => a.Type == SubscriptionType.Newspaper && a.Language == Language.En)
                .ProjectTo<SubscriptionListingServiceModel>()
                .ToListAsync();

        public async Task<IEnumerable<SubscriptionListingServiceModel>> AllMagazinesEnAsync()
            => await this.db
                .Subscriptions
                .OrderBy(a => a.Name)
                .Where(a => a.Type == SubscriptionType.Magazine && a.Language == Language.En)
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