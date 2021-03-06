﻿namespace Library.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class LibraryDbContext : IdentityDbContext<User>
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
            : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Subscription> Subscriptions { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Gallery> Galleries { get; set; }

        public DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Article>()
                .HasOne(a => a.Gallery)
                .WithOne(u => u.Article)
                .HasForeignKey<Gallery>(b => b.ArticleId);

            builder
                .Entity<Gallery>()
                .HasOne(a => a.Article)
                .WithOne(u => u.Gallery)
                .HasForeignKey<Article>(b => b.GalleryId);

            builder
                .Entity<Image>()
                .HasOne(a => a.Gallery)
                .WithMany(u => u.Images)
                .HasForeignKey(a => a.GalleryId);

            base.OnModelCreating(builder);
        }
    }
}