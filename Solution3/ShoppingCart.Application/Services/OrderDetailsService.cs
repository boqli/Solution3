using AutoMapper;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Application.Services
{
    public class OrderDetailsService : IOrderDetailsService
    {

        private IMapper _mapper;
        private IOrdersRepository _ordersRepo;
        private IOrderDetailsRepository _orderDetailsRepo;
        public OrderDetailsService(IOrdersRepository ordersRepository, IOrderDetailsRepository orderDetailsRepository, IMapper mapper)
        {
            _mapper = mapper;
            _ordersRepo = ordersRepository;
            _orderDetailsRepo = orderDetailsRepository;
        }

        public void AddOrderDetails(OrderDetailsViewModel orderDetails)
        {
            var myOrder = _mapper.Map<OrderDetailsViewModel, OrderDetails>(orderDetails);
            _orderDetailsRepo.AddOrderDetails(myOrder);
        }

    }
}
