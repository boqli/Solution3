using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            var list = _cartService.GetItems();
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
                //var cart = GetCart(); implmement

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

            return View("Index");
        }

        //once checkout() is done move cart to order then remove from cart
        //IMPROTANT SHIT


        /*
                private int isExist(string id)
                {
                    List<CartItem> cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
                    for(int i=0; i < cart.Count; i++)
                    {
                        if (cart[i].Product.Id.Equals(id))
                        {
                            return i;
                        }
                    }
                    return -1;
                }

                public IActionResult AddToCart(Guid id)
                {
                    ProductViewModel productViewModel = new ProductViewModel();
                    if(SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart") == null)
                    {
                        List<CartItem> cart = new List<CartItem>();
                        cart.Add(new CartItem { Product = productViewModel.find(id), Quantity = 1 });
                    }
                }
                */
        /*
        public IActionResult AddItemToCart(Guid id)
        {
            CartViewModel add = new CartViewModel();
            add.Product = _productsService.GetProduct(id);
        }
        */

    }
}
