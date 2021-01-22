using AutoMapper;
using AutoMapper.QueryableExtensions;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
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
        public CartService(ICartRepository cartRepository, IMapper mapper, ICategoriesRepository categoriesRepo)
        {
            _cartRepo = cartRepository;
            _mapper = mapper;
            _categoriesRepo = categoriesRepo;
        }

        public void AddItem(CartItemViewModel ci)
        {
            var myItem = _mapper.Map<CartItemViewModel, CartItem>(ci);
            _cartRepo.AddItem(myItem);

        }

        public IQueryable<CartViewModel> GetItems()
        {
            //AutoMapper
            var products = _cartRepo.GetItems().ProjectTo<CartViewModel>(_mapper.ConfigurationProvider);
            return products;
        }


        /*
        public CartViewModel getCartId(string email)
        {
            var products = _cartRepo.getCartId().Where(x => x.Email.Contains(email))
                .ProjectTo<ProductViewModel>(_mapper.ConfigurationProvider);
            return products;
        }

        */

    }
}
