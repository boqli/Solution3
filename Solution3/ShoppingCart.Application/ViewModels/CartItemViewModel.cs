using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Application.ViewModels
{
    public class CartItemViewModel
    {

        public int ItemId { get; set; }

        //public virtual CartViewModel Cart { get; set; }

        public int CartIdFK { get; set; }

        public int Quantity { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual ProductViewModel Product { get; set; }

        public Guid ProductFk { get; set; }


    }
}
