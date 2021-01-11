using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Domain.Interfaces
{
    public interface IOrdersRepository
    {

        IQueryable<Order> GetProducts();
        Order GetProduct(int id);
        void DeleteProduct(Order o);
    }
}
