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
                var items = _db.Items.ToList();
                if (items == null || items.Count < 1)
                {
                    return NotFound();
                }

                return Ok(items);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            
        }

    }
}
