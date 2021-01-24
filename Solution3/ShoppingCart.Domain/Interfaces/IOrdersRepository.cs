using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Domain.Interfaces
{
    public interface IOrdersRepository
    {

        void AddOrderDetail(OrderDetails orderDetails);

        //MIGHT JUST NEED THESE TWO

        IQueryable<Order> GetProducts();

        Order GetProduct(Guid id);

        void DeleteProduct(Order o);

        Order GetOrder(Order o);

        IQueryable<Order> AddOrder(Order o);

    }
}
