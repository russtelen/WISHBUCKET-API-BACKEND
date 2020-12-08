using GiftWishlist.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiftWishlist.Data
{
    public class WishContext:DbContext
    {
        public WishContext(DbContextOptions<WishContext> options) : base(options) { }
        public DbSet<Wishlist> Wishlists {get; set;}
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed Data
            modelBuilder.Entity<Wishlist>().HasData(
                new { Id = 1, Name = "Secret Santa 2020", Password = "", DueDate = DateTime.Now },
                new { Id = 2, Name = "SSD Completion Party", Password = "ssd", DueDate = new DateTime(2020, 5, 14, 13, 00, 02) },
                new { Id = 3, Name = "Secret Santa 2020", Password = "", DueDate = DateTime.Now }
            );


        }
    }
}
