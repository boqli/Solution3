using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;

namespace PresentationWebApp.Controllers
{
    public class CartController : Controller
    {

        private IProductsService _productsService;

        public CartController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        public IActionResult Index()
        {
            return View();
        }

        /*
        public IActionResult AddItemToCart(Guid id)
        {
            CartViewModel add = new CartViewModel();
            add.Product = _productsService.GetProduct(id);
        }
        */

    }
}
