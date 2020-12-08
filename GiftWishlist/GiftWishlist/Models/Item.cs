using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GiftWishlist.Models
{
    public class Item
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int WishlistId { get; set; } // Make this a Foreign Key 
        public string Name { get; set; }
        public bool IsComplete { get; set; }

        // Below are Optional
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public string PurchaseURL { get; set; }
        public decimal Price { get; set; }

    }
}