using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShoppingCart.Domain.Models
{
    public class OrderDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public virtual Product Product { get; set; }



        [Required]
        public Guid ProductFK { get; set; }

        public virtual Order Order { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public double Price { get; set; }

        [DefaultValue(false)]
        public bool Disable { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }

    }
}
