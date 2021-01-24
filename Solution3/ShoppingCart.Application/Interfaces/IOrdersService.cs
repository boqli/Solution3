using System;
using ShoppingCart.Application.ViewModels;
using System.Linq;

namespace ShoppingCart.Application.Interfaces
{
    public interface IOrdersService
    {

        bool Checkout(string email);

        IQueryable<OrderViewModel> GetProducts();

        OrderViewModel GetProducts(Guid id);

        void DeleteProduct(Guid id);

        //OrderViewModel GetOrder(string email);

        void AddOrder(OrderViewModel order);

        OrderViewModel GetOrder(string email);


    }
}
