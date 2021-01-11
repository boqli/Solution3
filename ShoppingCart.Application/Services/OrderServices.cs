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
    public class OrderServices : IOrdersService
    {

        private IMapper _mapper;
        private IOrdersRepository _ordersRepo;
        public OrderServices(IOrdersRepository ordersRepository, IMapper mapper)
        {
            _mapper = mapper;
            _ordersRepo = ordersRepository;
        }

        public void DeleteProduct(int id)
        {
            var pToDelete = _ordersRepo.GetProduct(id);

            if (pToDelete != null)
            {
                _ordersRepo.DeleteProduct(pToDelete);
            }
        }

        public IQueryable<OrderViewModel> GetProducts()
        {
            var list = from c in _ordersRepo.GetProducts()
                       select new OrderViewModel()
                       {
                           Id = c.Id,
                           DatePlaced = c.DatePlaced,
                           UserEmail = c.UserEmail
                       };
            return list;
        }

        public OrderViewModel GetProducts(int id)
        {
            var myOrder = _ordersRepo.GetProduct(id);
            var result = _mapper.Map<OrderViewModel>(myOrder);
            return result;
        }
    }
}
