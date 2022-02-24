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
    public class CartController : Controller
    {
        ICartBL cartBL;

        public CartController(ICartBL cartBL)
        {
            this.cartBL = cartBL;
        }

        [HttpPost]
        [Route("addToCarts")]
        public IActionResult AddToCart([FromBody] CartModel cart)
        {
            try
            {
                string result = this.cartBL.AddToCart(cart);
                if (result.Equals("Book Added succssfully to Cart"))
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

        [HttpPut]
        [Route("updateBookQuantity")]
        public IActionResult UpdateCartQuantity(int cartId, int quantity)
        {
            try
            {
                string result = this.cartBL.UpdateCartQuantity(cartId, quantity);
                if (result.Equals("Quantity Updated Successfully"))
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
        [Route("getCartDetails")]
        public IActionResult RetrieveCartDetails(int userId)
        {
            try
            {
                var result = this.cartBL.RetrieveCartDetails(userId);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Data retrieved successfully", Data = result });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "Get cart details is unsuccessful" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("deleteBook")]
        public IActionResult DeleteCart(int cartId)
        {
            try
            {
                string result = this.cartBL.DeleteCart(cartId);
                if (result.Equals("Cart details deleted successfully"))
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
    }
}
   