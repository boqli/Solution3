using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShoppingCart.Domain.Models
{
    public class CartItem
    {
        [Key]
        public int ItemId { get; set; }

        public virtual Cart Cart { get; set; }

        [Required]
        public int CartIdFK { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public virtual Product Product { get; set; }

        [Required]
        public Guid ProductFk { get; set; }

    }
}
