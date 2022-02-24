using CommomLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface ICartRL
    {
        string AddToCart(CartModel cartModel);
        string UpdateCartQuantity(int cartId, int quantity);
        List<CartModel> RetrieveCartDetails(int userId);
        string DeleteCart(int cartId);
    }
}
