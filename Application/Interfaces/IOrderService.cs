using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IOrderService
    {
        Task<bool> AddOrder(ProductModel productModel);
        Task<bool> CheckAvailability(ProductModel productModel);

    }
}
