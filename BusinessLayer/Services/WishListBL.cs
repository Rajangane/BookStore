using BusinessLayer.Interfaces;
using CommomLayer.Models;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
   public  class WishListBL : IWishListBL
    {
        IWishListRL wishlistRL;
        public WishListBL(IWishListRL wishlistRL)
        {
            this.wishlistRL = wishlistRL;
        }

        public string AddWishlist(WishlistModel wishlist)
        {
            try
            {
                return this.wishlistRL.AddWishlist(wishlist);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public string DeleteBookFromWishlist(int wishlistId)
        {
            try
            {
                return this.wishlistRL.DeleteBookFromWishlist(wishlistId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<WishlistModel> RetrieveWishlist(int userId)
        {
            try
            {
                return this.wishlistRL.RetrieveWishlist(userId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
