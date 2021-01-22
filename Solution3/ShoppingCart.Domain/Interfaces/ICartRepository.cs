using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Domain.Interfaces
{
    public interface ICartRepository
    {

        IQueryable<CartItem> AddItem(CartItem ci);

        //IQueryable<Cart> getCartId(Cart x);

        IQueryable<Cart> GetItems();
    }
}
