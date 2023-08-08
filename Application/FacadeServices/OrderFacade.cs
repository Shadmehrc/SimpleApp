using Application.IFacade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Application.FacadeServices
{
    public class OrderFacade : IOrderFacade
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<OrderFacade> _logger;

        public OrderFacade(IOrderService orderService, ILogger<OrderFacade> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }
        public async Task<bool> AddOrder(ProductModel productModel)
        {
            try
            {
                var checkAvailability = await _orderService.CheckAvailability(productModel);
                if (checkAvailability)
                {
                    return await _orderService.AddOrder(productModel);
                }
                return false;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return false;
            }
           
        }
    }
}
