using System.IO;
using Library.Services.Models.EmailSender;
using Microsoft.Extensions.FileProviders;

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

           

            services.AddSingleton<IFileProvider>(
            new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));

            services
                .AddIdentity<User, IdentityRole>(options =>
                {
                    options.SignIn.RequireConfirmedEmail = true;
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

            services.Configure<AuthMessageSenderOptions>(Configuration.GetSection("EmailSettings"));
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
                    name: "viewGallery",
                    template: "libraryblog/galleries/galleries",
                    defaults: new { area = "LibraryBlog", controller = "Galleries", action = "Galleries" });

                routes.MapRoute(
                    name: "editGallery",
                    template: "libraryblog/galleries/edit/{id}",
                    defaults: new { area = "LibraryBlog", controller = "Galleries", action = "Edit" });

                routes.MapRoute(
                    name: "deleteGallery",
                    template: "libraryblog/galleries/delete/{id}",
                    defaults: new { area = "LibraryBlog", controller = "Galleries", action = "Delete" });

                routes.MapRoute(
                    name: "destroyGallery",
                    template: "libraryblog/galleries/destroy/{id}",
                    defaults: new { area = "LibraryBlog", controller = "Galleries", action = "Destroy" });

                routes.MapRoute(
                    name: "viewArticle",
                    template: "libraryblog/articles/articles",
                    defaults: new { area = "LibraryBlog", controller = "Articles", action = "Articles" });

                routes.MapRoute(
                    name: "editArticle",
                    template: "libraryblog/articles/edit/{id}",
                    defaults: new { area = "LibraryBlog", controller = "Articles", action = "Edit" });

                routes.MapRoute(
                    name: "deleteArticle",
                    template: "libraryblog/articles/delete/{id}",
                    defaults: new { area = "LibraryBlog", controller = "Articles", action = "Delete" });

                routes.MapRoute(
                    name: "destroyArticle",
                    template: "libraryblog/articles/destroy/{id}",
                    defaults: new { area = "LibraryBlog", controller = "Articles", action = "Destroy" });

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
