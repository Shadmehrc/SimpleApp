using Application.Decorator;
using Application.IFacade;
using Domain.Models;
using Domain.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("[controller]/v{version:ApiVersion}")]
    //[Authorize]
    public class BaseController : Controller
    {
        private readonly ILogger<BaseController> _logger;
        private readonly IOrderFacade _orderFacade;
        private readonly OrderDecorator _orderDecorator;

        public BaseController(ILogger<BaseController> logger, IOrderFacade orderFacade, OrderDecorator orderDecorator)
        {
            _logger = logger;
            _orderFacade = orderFacade;
            _orderDecorator = orderDecorator;
        }

        [HttpGet]
        [Route("TestAPI")]
        public async Task<Response<TokenModel>> Get()
        {
            var result = Response<TokenModel>.Success(new TokenModel() { Audience = "Test" });
            _logger.LogInformation("api done");
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddOrder")]
        public async Task<bool> AddOrder(ProductModel productModel)
        {
            var result= await _orderDecorator.AddOrder(productModel);
            return result;
        }
    }
}