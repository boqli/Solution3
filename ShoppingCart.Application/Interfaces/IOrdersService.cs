using System;
using ShoppingCart.Application.ViewModels;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ShoppingCart.Application.Interfaces
{
    public interface IOrdersService
    {

        IQueryable<OrderViewModel> GetProducts();

        OrderViewModel GetProducts(int id);

        void DeleteProduct(int id);

    }
}
