using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Data.Context;
using ShoppingCart.Domain.Models;

namespace PresentationWebApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService _productsService;
        private readonly ICartService _cartService;
        private readonly ICategoriesService _categoriesService;
        private IWebHostEnvironment _env;
        private ShoppingCartDbContext _context;
        public ProductsController(IProductsService productsService, ICategoriesService categoriesService, ICartService cartService,
             IWebHostEnvironment env, ShoppingCartDbContext context)
        {
            _productsService = productsService;
            _categoriesService = categoriesService;
            _env = env;
            _cartService = cartService;
            _context = context;
        }

        public async Task<IActionResult> Index(int pageNumber=1)
        {
            var list = _productsService.GetProducts();
            var listOfCategeories = _categoriesService.GetCategories();
            ViewBag.Categories = listOfCategeories;
            return View( list);
            //await PaginatedList<Product>.CreateAsync(_context.Products,pageNumber,10)
        }

        [HttpPost]
        public IActionResult Search(string keyword) //using a form, and the drop down select list must have name attribute = to category
        {
            var list = _productsService.GetProducts(keyword);
            var listOfCategeories = _categoriesService.GetCategories();
            ViewBag.Categories = listOfCategeories;
            return View("Index", list);
        }

        //use this for cartitem view model return cartviewmodel
        public IActionResult Details(Guid id)
        {
            var p = _productsService.GetProduct(id);
            return View( p);
        }

        //the engine will load a page with empty fields
        [HttpGet]
        [Authorize (Roles ="Admin")] //is going to be accessed only by authenticated users
        public IActionResult Create()
        {
            //fetch a list of categories
            var listOfCategeories = _categoriesService.GetCategories();

            //we pass the categories to the page
            ViewBag.Categories = listOfCategeories;

            return View();
        }

        //here details input by the user will be received
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(ProductViewModel data, IFormFile f)
        {
            try
            {
                if(f !=  null)
                {
                    if(f.Length > 0)
                    {
                        //C:\Users\Ryan\source\repos\SWD62BEP\SWD62BEP\Solution3\PresentationWebApp\wwwroot
                        string newFilename = Guid.NewGuid() + System.IO.Path.GetExtension(f.FileName);
                        string newFilenameWithAbsolutePath = _env.WebRootPath +  @"\Images\" + newFilename;
                        
                        using (var stream = System.IO.File.Create(newFilenameWithAbsolutePath))
                        {
                            f.CopyTo(stream);
                        }

                        data.ImageUrl = @"\Images\" + newFilename;
                    }
                }

                _productsService.AddProduct(data);

                TempData["feedback"] = "Product was added successfully";
            }
            catch (Exception ex)
            {
                //log error
                TempData["warning"] = "Product was not added! "+ex;
            }

           var listOfCategeories = _categoriesService.GetCategories();
           ViewBag.Categories = listOfCategeories;
            return View(data);
        
        } //fiddler, burp, zap, postman

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _productsService.DeleteProduct(id);
                TempData["feedback"] = "Product was deleted";
            }
            catch (Exception ex)
            {
                //log your error 

                TempData["warning"] = "Product was not deleted" + ex; //Change from ViewData to TempData
            }

            return RedirectToAction("Index");
        }


        [Authorize(Roles = "Admin")]
        public IActionResult DisableProduct(Guid id)
        {
            try
            {
                _productsService.DisableProduct(id);
                TempData["feedback"] = "Product was disabled";
            }
            catch (Exception ex)
            {
                //log your error 

                TempData["warning"] = "Product was not disabled" + ex; //Change from ViewData to TempData
            }

            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult searchByCategory(int category)
        {
            var list = _productsService.GetProducts(category);
            var listOfCategeories = _categoriesService.GetCategories();
            ViewBag.Categories = listOfCategeories;

            return View("Index", list);
        }



        


    }
}
