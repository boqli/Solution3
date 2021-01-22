using AutoMapper;
using AutoMapper.QueryableExtensions;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Data.Repositories;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Linq;

namespace ShoppingCart.Application.Services
{
    public class OrderService : IOrdersService
    {

        private IMapper _mapper;
        private IOrdersRepository _ordersRepo;
        private IOrderDetailsRepository _orderDetailsRepo;
        public OrderService(IOrdersRepository ordersRepository, IOrderDetailsRepository orderDetailsRepository, IMapper mapper)
        {
            _mapper = mapper;
            _ordersRepo = ordersRepository;
            _orderDetailsRepo = orderDetailsRepository;
        }


        /*
         * 1)approach - storing items in cart table in db
         * a)user must be logged in
         * b)in the checkout method you need to fetch list of cart items from db
         * 
         * 2)approach - storing items in cart controller
         * a) in the checkout method you need to pass the list from the controller to checkout
         * 
         * 3)approach - storing items in cart in a cookie (tinstema tad dgha)
         * a) user may not be logged in
         * b) form a list from the controller and parse from cookie (hassle)
         * 
         */


        public void Checkout(string email)
        {
            // IF NOT STORING PRODUCTS LIST IN DATABASE, PASS LIST ( List<CartViewModel> )
            //1. Get a list of products that have been added to the cart for given email from the db

            //2. loop within the list of products to check qty from the stock
            //if you find a prodcuct with qty > stock- throw new Exeption("not enough stock"); OR
            //if you find a producy with qty > stock - retun false

            //3. Create order
            Guid orderId = Guid.NewGuid();
            Order o = new Order();
            o.Id = orderId;
            //continue setting up other properties


            //4. loop within the list of products and create OrderDetails for each prod
            OrderDetails details = new OrderDetails();
            details.OrderId = orderId;
            //details.ProductFK =
            //4.1 deduct qty from stock
            //continue setting up other properties

            //END LOOP

            //5. Call the AddOrder from inside the IOrderRepository (_ordersRepo) (this can be merged with step 3)

            //6. Call the AddOrderDetails from inside the IOrderRepository (_ordersRepo) (this can be merged with step 4)
        }

        public void DeleteProduct(Guid id)
        {
            var pToDelete = _ordersRepo.GetProduct(id);

            if (pToDelete != null)
            {
                _ordersRepo.DeleteProduct(pToDelete);
            }
        }

        public IQueryable<OrderViewModel> GetProducts()
        {
            var list = from c in _ordersRepo.GetProducts()
                       select new OrderViewModel()
                       {
                           Id = c.Id,
                           DatePlaced = c.DatePlaced,
                           UserEmail = c.UserEmail
                       };
            return list;
        }

        public OrderViewModel GetProducts(Guid id)
        {
            var myOrder = _ordersRepo.GetProduct(id);
            var result = _mapper.Map<OrderViewModel>(myOrder);
            return result;
        }

        public void AddProduct(OrderViewModel order)
        {
            var myOrder = _mapper.Map<Order>(order);
            _ordersRepo.AddOder(myOrder);
        }

        //OrderViewModel minflok void
        public void GetOrder(string email)
        {
            //throw new NotImplementedException();
        }

        public OrderViewModel AddOrder(OrderViewModel order)
        {
            throw new NotImplementedException();
        }
    }
}
