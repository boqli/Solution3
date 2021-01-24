using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationWebApp.Helper;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Models;

namespace PresentationWebApp.Controllers
{
    public class CartController : Controller
    {
        private IProductsService _productsService;
        private IOrdersService _ordersService;
        private ICategoriesService _categoriesService;
        private ICartService _cartService;
        private IOrderDetailsService _orderDetailsService;

        public CartController(IProductsService productsService, IOrderDetailsService orderDetailsService, IOrdersService ordersService, ICartService cartService, ICategoriesService categoriesService)
        {
            _productsService = productsService;
            _ordersService = ordersService;
            _cartService = cartService;
            _categoriesService = categoriesService;
            _orderDetailsService = orderDetailsService;

        }

        public IActionResult Index()
        {
            var list = _cartService.GetItems().FirstOrDefault();
            return View(list);
        }

        /*
        public CartItemViewModel getCartId(string email)
        {
            CartViewModel c = _cartService

        }
        */

        //[HttpPost]
        public IActionResult AddToCart(Guid id)
        {
            try
            {
                var cart = _productsService.GetProduct(id);
                //var cartId= GetCart(); implmement

                var cartItem = new CartItemViewModel()
                {
                    ItemId = 0,
                    Quantity = 1,
                    CartIdFK = 1, //create a method to get current cart, rename to cart (get card via email , if cart exist use that, if not create cart)
                    DateCreated = DateTime.Now,
                    ProductFk = id
                };

                _cartService.AddItem(cartItem);

                TempData["feedback"] = "Product was added successfully";
            }
            catch (Exception ex)
            {
                //log error

                TempData["warning"] = "Product was not added! " + ex;
                return RedirectToAction("error", "Home");
            }

            return RedirectToAction("Index","Products");
        }

        public IActionResult Delete(Guid id)
        {
            try
            {
                _cartService.DeleteProduct(id);
                TempData["feedback"] = "Product was removed from cart";
            }
            catch (Exception ex)
            {
                //log your error 

                TempData["warning"] = "Product was not removed from cart" + ex; //Change from ViewData to TempData
                return RedirectToAction("error", "Home");
            }

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin, User")]
        public IActionResult Checkout()
        {
            try
            {
                var n =_cartService.GetItems().Where(x => x.Email == User.Identity.Name).FirstOrDefault();
                //var ord = _ordersService.GetOrder(User.Identity.Name);

                var email = User.Identity.Name;
                //getcart id
                //var cart = _productsService.GetProduct(id);
                //var cartId= GetCart(); implmement

                var order = new OrderViewModel()
                {
                    UserEmail = email,
                    DatePlaced = DateTime.Now
                };

                _ordersService.AddOrder(order);
                /*
                var orderid = _ordersService.GetOrder(email).Id;
                
                foreach (var x in n.CartItems)
                {
                    var orderDetails = new OrderDetailsViewModel()
                    {
                         Price = x.Product.Price,
                         Quantity = x.Quantity,
                         ProductFk = x.Product.Id,
                         OrderId = order.Id
                    };
                    _orderDetailsService.AddOrderDetails(orderDetails);
                }
                */

                TempData["feedback"] = "Order was added successfully";
            }
            catch (Exception ex)
            {
                //log error
                TempData["warning"] = "Order was not added! " + ex;
                return RedirectToAction("error", "Home");
            }

            return RedirectToAction("Index", "Products");
            /*
            if (_ordersService.Checkout(User.Identity.Name))
            {
                TempData["feedback"] = "Your order was created";
                //empty cart
                return RedirectToAction("Index", "Products");
            }
            else
            {
                TempData["feedback"] = "Something went wrong with your order!";
                return RedirectToAction("Index", "Products");
            }
            */
        }

        //once checkout() is done move cart to order then remove from cart
        //IMPROTANT SHIT

    }
}
