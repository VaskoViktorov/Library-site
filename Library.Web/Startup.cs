namespace Library.Web
{
    using AutoMapper;
    using Data;
    using Data.Models;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<LibraryDbContext>(options =>
                options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")));

            services
                .AddIdentity<User, IdentityRole>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                })
                .AddEntityFrameworkStores<LibraryDbContext>()
                .AddDefaultTokenProviders();

            services.AddDomainServices();

            services.AddAutoMapper();

            services.AddRouting(routing => routing.LowercaseUrls = true);

            services.AddMvc(options =>
            {
                options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDatabaseMigration();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "viewBooks",
                    template: "libraryblog/books/books",
                    defaults: new { area = "LibraryBlog", controller = "Books", action = "Books" });

                routes.MapRoute(
                    name: "editBook",
                    template: "libraryblog/books/edit/{id}",
                    defaults: new { area = "LibraryBlog", controller = "Books", action = "Edit" });

                routes.MapRoute(
                    name: "deleteBook",
                    template: "libraryblog/books/delete/{id}",
                    defaults: new { area = "LibraryBlog", controller = "Books", action = "Delete" });

                routes.MapRoute(
                    name: "destroyBook",
                    template: "libraryblog/books/destroy/{id}",
                    defaults: new { area = "LibraryBlog", controller = "Books", action = "Destroy" });

                routes.MapRoute(
                    name: "editSubscription",
                    template: "libraryblog/subscriptions/edit/{id}",
                    defaults: new { area = "LibraryBlog", controller = "Subscriptions", action = "Edit" });

                routes.MapRoute(
                    name: "deleteSubscription",
                    template: "libraryblog/subscriptions/delete/{id}",
                    defaults: new { area = "LibraryBlog", controller = "Subscriptions", action = "Delete" });

                routes.MapRoute(
                    name: "destroySubscription",
                    template: "libraryblog/subscriptions/destroy/{id}",
                    defaults: new { area = "LibraryBlog", controller = "Subscriptions", action = "Destroy" });

                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
