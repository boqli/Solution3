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

        public IQueryable<Order> AddOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return _context.Orders;
        }

        public void AddOrderDetail(OrderDetails orderDetails)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(Order id)
        {
            //ShoppingCartDbContext context = new ShoppingCartDbContext();
            _context.Orders.Remove(id);
            _context.SaveChanges(); //this will save permanently into the db
        }

        public Order GetOrder(Order o)
        {
            throw new NotImplementedException();
        }

        public Order GetProduct(Guid id)
        {
            return _context.Orders.SingleOrDefault(x => x.Id == id);
        }

        public Order GetProduct(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Order> GetProducts()
        {
            //ShoppingCartDbContext context = new ShoppingCartDbContext();
            return _context.Orders;
        }
    }

}
