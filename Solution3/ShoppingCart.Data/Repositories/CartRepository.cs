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

        public void DeleteProduct(CartItem p)
        {
            //ShoppingCartDbContext context = new ShoppingCartDbContext();
            _context.CartItems.Remove(p);
            _context.SaveChanges(); //this will save permanently into the db
        }

        public CartItem GetProduct(Guid id)
        {
            //ShoppingCartDbContext context = new ShoppingCartDbContext();
            //single or default will return ONE product! or null
            return _context.CartItems.SingleOrDefault(x => x.ProductFk == id);
        }
    }
}
