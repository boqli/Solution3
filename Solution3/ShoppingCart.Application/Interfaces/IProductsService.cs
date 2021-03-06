﻿using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.Interfaces
{
    public interface IProductsService
    {
        IQueryable<ProductViewModel> GetProducts();

        IQueryable<ProductViewModel> GetProducts(int category);

        IQueryable<ProductViewModel> GetProducts(string keyword);

        ProductViewModel GetProduct(Guid id);

        void AddProduct(ProductViewModel product);

        void AddProduct(Product product);

        void DeleteProduct(Guid id);

        void DisableProduct(Guid id);

    }
}
