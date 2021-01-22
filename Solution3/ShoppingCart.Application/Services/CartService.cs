using AutoMapper;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.Services
{
    public class CartService : ICartService
    {
        private IMapper _mapper;
        private ICartRepository _cartRepo;
        private ICategoriesRepository _categoriesRepo;
        public CartService(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepo = cartRepository;
            _mapper = mapper;
        }

        public IQueryable<CartViewModel> GetItems()
        {
            var list = from c in _cartRepo.GetItems()
                       select new CartViewModel()
                       {
                           //do smth
                       };
            return list;
        }

        
    }
}
