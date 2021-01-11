using Microsoft.EntityFrameworkCore;
using ShoppingCart.Data.Context;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace ShoppingCart.Data.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        ShoppingCartDbContext _context;

        public OrdersRepository(ShoppingCartDbContext context)
        {
            _context = context;
        }

        public void DeleteProduct(Order o)
        {
            //ShoppingCartDbContext context = new ShoppingCartDbContext();
            _context.Orders.Remove(o);
            _context.SaveChanges(); //this will save permanently into the db
        }

        public Order GetProduct(int id)
        {
            return _context.Orders.SingleOrDefault(x => x.Id == id);
        }

        public IQueryable<Order> GetProducts()
        {
            //ShoppingCartDbContext context = new ShoppingCartDbContext();
            return _context.Orders;
        }

    }

}
