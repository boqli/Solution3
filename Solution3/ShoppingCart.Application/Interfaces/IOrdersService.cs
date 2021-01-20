using System;
using ShoppingCart.Application.ViewModels;
using System.Linq;

namespace ShoppingCart.Application.Interfaces
{
    public interface IOrdersService
    {
        void Checkout(string email);

        IQueryable<OrderViewModel> GetProducts();

        OrderViewModel GetProducts(Guid id);

        void DeleteProduct(Guid id);

       //OrderViewModel GetOrder(string email);

        OrderViewModel AddOrder(OrderViewModel order);

    }
}
