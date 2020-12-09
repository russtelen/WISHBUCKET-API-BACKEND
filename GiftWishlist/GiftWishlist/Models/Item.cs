using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GiftWishlist.Models
{
    public class Item:BaseEntity
    {
 
        public string Name { get; set; }
        public bool IsComplete { get; set; }

        public int WishlistID { get; set; }
        
        public string OwnerEmail { get; set; }

        // Below are Optional
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public string PurchaseURL { get; set; }
        [DataType(DataType.Currency)]
        public decimal? Price { get; set; }

    }
}