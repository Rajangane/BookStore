using BusinessLayer.Interfaces;
using CommomLayer.Models;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class CartBL : ICartBL
    {
        ICartRL cartRL;
        public CartBL(ICartRL cartRL)
        {
            this.cartRL = cartRL;
        }

        public string AddToCart(CartModel cartModel)
        {
            try
            {
                return this.cartRL.AddToCart(cartModel);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public string UpdateCartQuantity(int cartId, int quantity)
        {
            try
            {
                return this.cartRL.UpdateCartQuantity(cartId, quantity);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<CartModel> RetrieveCartDetails(int userId)
        {
            try
            {
                return this.cartRL.RetrieveCartDetails(userId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public string DeleteCart(int cartId)
        {
            try
            {
                return this.cartRL.DeleteCart(cartId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }

}