using ShoppingCart.Data.Context;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Data.Repositories
{
    public class CartRepository : ICartRepository
    {

        ShoppingCartDbContext _context;
        public CartRepository(ShoppingCartDbContext context)
        {
            _context = context;

        }
        
        public IQueryable<CartItem> AddItem(CartItem ci)
        {
            _context.CartItems.Add(ci);
            _context.SaveChanges();
            return _context.CartItems;
        }

        public IQueryable<Cart> GetItems()
        {
            return _context.Carts;
        }
    }
}
