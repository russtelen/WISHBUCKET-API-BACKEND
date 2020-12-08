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
        public DbSet<Item> Items {get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seeder function
        }
    }
}
