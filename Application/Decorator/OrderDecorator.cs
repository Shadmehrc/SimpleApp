using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.IFacade;
using Domain.Models;

namespace Application.Decorator
{
    public abstract class OrderDecorator : IOrderFacade
    {
        private readonly IOrderFacade _orderFacade;

        protected OrderDecorator(IOrderFacade orderFacade)
        {
            _orderFacade = orderFacade;
        }

        public virtual async Task<bool> AddOrder(ProductModel productModel)
        {
           return  await _orderFacade.AddOrder(productModel);
        }
    }
}
