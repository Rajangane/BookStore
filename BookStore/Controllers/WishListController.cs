using BusinessLayer.Interfaces;
using CommomLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class WishListController : Controller
    {
        IWishListBL wishlistBL;

        public WishListController(IWishListBL wishlistBL)
        {
            this.wishlistBL = wishlistBL;
        }
        [HttpPost]
        [Route("addToWishlist")]
        public IActionResult AddWishlist([FromBody] WishlistModel wishlist)
        {
            try
            {
                string result = this.wishlistBL.AddWishlist(wishlist);
                if (result.Equals("Book Wishlisted successfully"))
                {

                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("deleteWishlist")]
        public IActionResult DeleteBookFromWishlist(int wishlistId)
        {
            try
            {
                string result = this.wishlistBL.DeleteBookFromWishlist(wishlistId);
                if (result.Equals("Wishlist deleted successfully"))
                {

                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("getWishlistDetails")]
        public IActionResult RetrieveWishlist(int userId)
        {
            try
            {
                var result = this.wishlistBL.RetrieveWishlist(userId);
                if (result != null)
                {

                    return this.Ok(new { Status = true, Message = "Retrieve successfully", Data = result });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "Retrieval unsuccessful" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}
