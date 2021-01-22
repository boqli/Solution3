using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShoppingCart.Domain.Models
{
    public class CartItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemId { get; set; }

        public virtual Cart Cart { get; set; }

        [Required]
        [ForeignKey("Cart")]
        public int CartIdFK { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public virtual Product Product { get; set; }

        [Required]
        [ForeignKey("Product")]
        public Guid ProductFk { get; set; }

    }
}
