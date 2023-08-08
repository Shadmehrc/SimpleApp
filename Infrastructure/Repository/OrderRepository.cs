using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Models;

namespace Infrastructure.Repository
{
    public class OrderRepository:IOrderRepository
    {
        public async Task<bool> AddOrder(ProductModel productModel)
        {
            return true;
        }

        public async Task<bool> CheckAvailability(ProductModel productModel)
        {
            return true;
        }
    }
}
