using CommomLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IWishListRL
    {
        string AddWishlist(WishlistModel wishlist);
        string DeleteBookFromWishlist(int wishlistId);
        List<WishlistModel> RetrieveWishlist(int userId);
    }
}
