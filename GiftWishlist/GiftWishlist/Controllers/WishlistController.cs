using GiftWishlist.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiftWishlist.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistController : ControllerBase
    {
        private readonly WishContext _db;

        public WishlistController(WishContext db)
        {
            _db = db;
        }

        // GetAll() is automatically recognized as
        // https://localhost:<port #>/api/todo
        [HttpGet]
        public IActionResult GetAll()
        {

            try
            {
                var wishlist = _db.Wishlists.ToList();
                if (wishlist == null || wishlist.Count < 1)
                {
                    return NotFound();
                }

                return Ok(wishlist);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            
        }

        //Detail
        [HttpGet("{id}", Name = "GetOne")]
        public IActionResult GetById(int id)
        {
            try
            {
                var wishlist = _db.Wishlists.Where(t => t.Id == id).FirstOrDefault();
                if (wishlist == null)
                {
                    return NotFound();
                }
                return Ok(wishlist);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        //Delete
        [HttpDelete]
        [Route("MyDelete")] // Custom Route
        public IActionResult MyDelete(long Id)
        {
            var item = _db.Wishlists.Where(t => t.Id == Id).FirstOrDefault();
            if (item == null)
            {
                return NotFound();
            }
            _db.Wishlists.Remove(item);
            _db.SaveChanges();
            return new ObjectResult(item);
        }

    }
}
