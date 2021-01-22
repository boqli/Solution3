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

        public CartController(IProductsService productsService, IOrdersService ordersService)
        {
            _productsService = productsService;
            _ordersService = ordersService;

        }

        public IActionResult Index()
        {

            return View();
        }

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
