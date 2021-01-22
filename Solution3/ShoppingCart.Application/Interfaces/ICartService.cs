using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.Interfaces
{
    public interface ICartService
    {

        public void AddItem(CartItemViewModel ci);

        public IQueryable<CartViewModel> GetItems();
        //public CartViewModel getCartId(string email);

    }
}
