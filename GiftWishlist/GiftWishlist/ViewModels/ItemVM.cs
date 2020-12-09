using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiftWishlist.ViewModels
{
    public class ItemVM
    {
        public int Id { get; set; }
        public int WishlistID { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }

        // Below are Optional
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public string PurchaseURL { get; set; }
        public decimal? Price { get; set; }
    }
}
