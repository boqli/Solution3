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

        public CartController(IProductsService productsService, IOrdersService ordersService, ICartService cartService, ICategoriesService categoriesService)
        {
            _productsService = productsService;
            _ordersService = ordersService;
            _cartService = cartService;
            _categoriesService = categoriesService;

        }

        public IActionResult Index()
        {
            var list = _cartService.GetItems().FirstOrDefault();
            return View(list);
        }
        /*
        public ProductViewModel getCardId(Guid id)
        {
            ProductViewModel p = _productsService.GetProduct(id);
            return p.Id;
        }
        */

        /*
        public CartItemViewModel getCartId(string email)
        {
            CartItemViewModel c = _cartService

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
                    CartIdFK = 1, //create a method to get current cart, rename to cart
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
            }

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin, User")]
        public IActionResult Checkout()
        {
            try
            {
                //getcart id
                //var cart = _productsService.GetProduct(id);
                //var cartId= GetCart(); implmement

                var order = new OrderViewModel()
                {
                    UserEmail = User.Identity.Name,
                    DatePlaced = DateTime.Now
                };

                var orderDetailsc = new OrderDetailsViewModel()
                {

                };

                _ordersService.AddOrder(order);

                TempData["feedback"] = "Order was added successfully";
            }
            catch (Exception ex)
            {
                //log error
                TempData["warning"] = "Order was not added! " + ex;
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
