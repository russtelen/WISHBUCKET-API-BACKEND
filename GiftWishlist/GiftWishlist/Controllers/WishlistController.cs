using GiftWishlist.Data;
using GiftWishlist.Models;
using GiftWishlist.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        //private List<WishlistVM> WishlistsToVM()
        //{
        //    return _db.Wishlists
        //        .Select(w => new WishlistVM
        //    {
        //        Id = w.Id,
        //        Name = w.Name,
        //        Password = w.Password,
        //        DueDate = w.DueDate
        //    }).ToList();
        //}

        // GetAll() is automatically recognized as
        // https://localhost:<port #>/api/todo
        [HttpGet]
        public IActionResult GetAll()
        {

            try
            {
                var wishlist = _db.Wishlists
                    .Include(i => i.Items)
                    .Where(w => w.Password == "")
                    .ToList();

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
        public IActionResult GetById(int id, string password)
        {
            try
            {
                var wishlist = _db.Wishlists
                    .Include(i => i.Items)
                    .Where(t => t.Id == id && t.Password == password)
                    .FirstOrDefault();

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


        [Authorize]
        [HttpPost]
        public IActionResult Create([FromBody] Wishlist wishlist)
        {
            if (wishlist.Name == "" || !ModelState.IsValid) // Any other bad inputs?
            {
                return BadRequest();
            }  
            _db.Wishlists.Add(wishlist);
            _db.SaveChanges();
            //return CreatedAtRoute("GetOne", new { id = wishlist.Id });
            return Ok();
        }

        [Authorize]
        [HttpPut]
        public IActionResult Update([FromBody] Wishlist newWishlist)
        {
            try
            {
                var wishlist = _db.Wishlists
                    .Where(t => t.Id == newWishlist.Id)
                    .FirstOrDefault();

                if (wishlist == null || !ModelState.IsValid)
                {
                    return NotFound();
                }

                wishlist.Name = newWishlist.Name;
                wishlist.DueDate = newWishlist.DueDate;

                _db.SaveChanges();

                return Ok(wishlist);

            } catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [Authorize]
        [HttpDelete]
        public IActionResult Delete(long Id)
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

        // ITEM ROUTES

        [HttpGet]
        [Route("{listId}/items/")]
        public IActionResult GetAllItems(int listId)
        {

            try
            {
                var items = _db.Items.Where(i => i.WishlistID == listId).ToList();
                if (items == null)
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

        [HttpGet]
        [Route("{listId}/item/{itemId}", Name ="GetItem")]
        public IActionResult GetItemById(int listId, int itemId)
        {
            try
            {
           
                var item = _db.Items.Where(i => i.Id == itemId && i.WishlistID == listId).FirstOrDefault();

                if (item == null)
                {
                    return NotFound();
                }
                return Ok(item);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [Authorize]
        [HttpPost]
        [Route("{listId}/item/")]
        public IActionResult CreateItem(int listId, [FromBody] Item item)
        {
            if (item.Name == null || item.Name == "" || !ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                var wishlist = _db.Wishlists.Where(t => t.Id == listId).FirstOrDefault();
                wishlist.Items.Add(item);
                _db.SaveChanges();
                return CreatedAtRoute("GetItem", new {listId = wishlist.Id, itemId = item.Id }, item);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [Authorize]
        [HttpDelete]
        [Route("{listId}/item/{itemId}")]
        public IActionResult DeleteItem(int listId, int itemId)
        {
            try
            {
                var wishlist = _db.Wishlists.Where(t => t.Id == listId).FirstOrDefault();
                if (wishlist == null)
                {
                    return NotFound();
                }

                var item = _db.Items.Where(i => i.Id == itemId && i.WishlistID == listId).FirstOrDefault();
                wishlist.Items.Remove(item);
                _db.SaveChanges();
                return new ObjectResult(item);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [Authorize]
        [HttpPut]
        [Route("{listId}/item/{itemId}")]
        public IActionResult GetByParams(int listId, int itemId, [FromBody] Item newItem)
        {
            var item = _db.Items.Where(i => i.Id == itemId && i.WishlistID == listId).FirstOrDefault();
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                item.IsComplete = newItem.IsComplete;
                item.Name = newItem.Name;
                item.PurchaseURL = newItem.PurchaseURL;
                item.Price = newItem.Price;
                item.ImageURL = newItem.ImageURL;
                _db.SaveChanges();
            }
            return new ObjectResult(item);
        }


    }
}
