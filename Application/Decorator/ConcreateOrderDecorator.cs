using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.IFacade;
using Domain.Models;
using Microsoft.Extensions.Logging;

namespace Application.Decorator
{
    public class ConcreateOrderDecorator : OrderDecorator
    {
        private readonly ILogger<ConcreateOrderDecorator> _logger;

        public ConcreateOrderDecorator(IOrderFacade orderFacade, ILogger<ConcreateOrderDecorator> logger) : base(orderFacade)
        {
            _logger = logger;
        }

        public override async Task<bool> AddOrder(ProductModel productModel)
        {
            try
            {
                _logger.LogInformation($"Request Log from service => Received Product Name: {productModel.Name}");
                var result = await base.AddOrder(productModel);
                _logger.LogInformation($"Response Log from service => Result: {result.ToString()}");

                return result;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
       
        }

    }

}
