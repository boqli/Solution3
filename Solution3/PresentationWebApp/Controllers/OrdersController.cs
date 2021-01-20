using System;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;

namespace PresentationWebApp.Controllers
{
    public class OrdersController : Controller
    {
        private IOrdersService _ordersService;
        private IMembersService _memberService;
        private IProductsService _productsService;
 
        public OrdersController(IOrdersService ordersService, IMembersService membersService, IProductsService productsService)
        {
            _ordersService = ordersService;
            _productsService = productsService;
            _memberService = membersService;
        }
        /*
        public IActionResult Index()
        {
            var email = User.Identity.Name;
            var order = _ordersService.GetOrder(email);
            return View(order);//list
        }
        */

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
        /*
        public OrderViewModel GetOrder()
        {
            var email = User.Identity.Name;
            var order = _ordersService.GetOrder(email);
            if(order.Id != null)
            {
                OrderViewModel orderViewModel = new OrderViewModel()
                {
                    //Id = 0,
                    UserEmail = email
                };
                order = _ordersService.AddOrder(orderViewModel);
            }
            return order;
        }
        */

    }
}
