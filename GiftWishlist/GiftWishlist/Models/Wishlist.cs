using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GiftWishlist.Models
{
    public class Wishlist:BaseEntity
    {

        public Wishlist()
        {
            Items = new List<Item>();
        }
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime? DueDate { get; set; }

        public virtual ICollection<Item> Items { get; set; } 


    }
}
