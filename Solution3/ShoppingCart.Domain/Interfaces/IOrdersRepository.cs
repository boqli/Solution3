using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Domain.Interfaces
{
    public interface IOrdersRepository
    {


        //MIGHT JUST NEED THESE TWO

        IQueryable<Order> GetProducts();

        Order GetProduct(Guid id);

        void DeleteProduct(Order o);

        IQueryable<Order> AddOrder(Order o);

        Order GetOrder(string email);

    }
}
