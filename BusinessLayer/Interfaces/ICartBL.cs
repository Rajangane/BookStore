using CommomLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
   public interface ICartBL
   {
        string AddToCart(CartModel cartModel);
        string UpdateCartQuantity(int cartId, int quantity);
        List<CartModel> RetrieveCartDetails(int userId);
        string DeleteCart(int cartId);
    }
}
