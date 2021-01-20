using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Application.ViewModels
{
    public class CartViewModel
    {
        public int Id { get; set; }

        public virtual Product Product { get; set; }

        public Guid ProductFk { get; set; }

        public string Email { get; set; }


    }
}
