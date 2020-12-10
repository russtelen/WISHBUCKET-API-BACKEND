using GiftWishlist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiftWishlist.ViewModels
{
    public class WishlistVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime? DueDate { get; set; }
        public List<Item> Items { get; set; }
    }
}
