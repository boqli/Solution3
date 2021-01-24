using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;

namespace PresentationWebApp.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrdersService _ordersService;

        private IWebHostEnvironment _env;

        private readonly ILogger<OrdersController> _logger;

        public OrdersController(ILogger<OrdersController> logger)
        {
            _logger = logger;
        }

        public OrdersController(IOrdersService ordersService,IWebHostEnvironment env)
        {
            _ordersService = ordersService;
            _env = env;
        }

        public IActionResult Index()
        {
            //var list = _ordersService.GetProducts();
            return View();
        }

        public IActionResult Delete(Guid id)
        {
            try
            {
                _ordersService.DeleteProduct(id);
                TempData["feedback"] = "Product was deleted";
            }
            catch (Exception ex)
            {
                //log your error 

                TempData["warning"] = "Product was not deleted" + ex; //Change from ViewData to TempData
            }

            return RedirectToAction("Index");
        }

       


    }
}
