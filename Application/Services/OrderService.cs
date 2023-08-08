using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Models;
using Microsoft.Extensions.Configuration;

namespace Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<bool> AddOrder(ProductModel productModel)
        {
            return await _orderRepository.AddOrder(productModel);

        }

        public async Task<bool> CheckAvailability(ProductModel productModel)
        {
            return await _orderRepository.CheckAvailability(productModel);
        }
    }
}
