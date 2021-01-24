using ShoppingCart.Data.Context;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System.Linq;

namespace ShoppingCart.Data.Repositories
{
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        ShoppingCartDbContext _context;

        public OrderDetailsRepository(ShoppingCartDbContext context)
        {
            _context = context;
        }

        public IQueryable<OrderDetails> AddOrderDetails(OrderDetails od)
        {
            _context.OrderDetails.Add(od);
            _context.SaveChanges();
            return _context.OrderDetails;
        }
    }
}
