using AutoMapper;
using AutoMapper.QueryableExtensions;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Data.Repositories;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.Services
{
    public class ProductsService : IProductsService
    {
        private IMapper _mapper;
        private IProductsRepository _productsRepo;
        public ProductsService(IProductsRepository productsRepository, IMapper mapper)
        {
            _mapper = mapper;
            _productsRepo = productsRepository;
        }

        public void AddProduct(ProductViewModel product)
        {
            var myProduct = _mapper.Map<Product>(product);
            myProduct.Category = null;
            _productsRepo.AddProduct(myProduct);
        }

        public void AddProduct(Product product)
        {
            var myProduct = _mapper.Map<Product>(product);
            myProduct.Category = null;
            _productsRepo.AddProduct(myProduct);
        }

        public void DeleteProduct(Guid id)
        {
            var pToDelete = _productsRepo.GetProduct(id);

            if (pToDelete != null)
            {
                _productsRepo.DeleteProduct(pToDelete);
            }
        }

        public void DisableProduct(Guid id)
        {
            var pToDisable = _productsRepo.GetProduct(id);

            if (pToDisable != null)
            {
                _productsRepo.DisableProduct(id);
            }

        }


        public ProductViewModel GetProduct(Guid id)
        {
            //AutoMapper
            var myProduct = _productsRepo.GetProduct(id);
            var result = _mapper.Map<ProductViewModel>(myProduct);
            return result;
        }

        public IQueryable<ProductViewModel> GetProducts()
        {
            //AutoMapper
            var products = _productsRepo.GetProducts().ProjectTo<ProductViewModel>(_mapper.ConfigurationProvider);
            return products;
        }

        public IQueryable<ProductViewModel> GetProducts(string keyword)
        {

            var products = _productsRepo.GetProducts().Where(x => x.Description.Contains(keyword) || x.Name.Contains(keyword))
                .ProjectTo<ProductViewModel>(_mapper.ConfigurationProvider);
            return products;

        }


        public IQueryable<ProductViewModel> GetProducts(int category)
        {
            var products = _productsRepo.GetProducts().Where(x => x.CategoryId.Equals(category))
                .ProjectTo<ProductViewModel>(_mapper.ConfigurationProvider);
            return products;

        }

    }
}
