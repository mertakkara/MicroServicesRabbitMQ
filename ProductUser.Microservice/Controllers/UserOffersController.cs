using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProductUser.Microservice.Model;
using ProductUser.Microservice.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace ProductUser.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOffersController : ControllerBase
    {
        private readonly IUserService userService;

        public UserOffersController(IUserService _userService)
        {
            userService = _userService;
        }

        [HttpGet("offerlist")]
        public Task<IEnumerable<ProductOfferDetail>> ProductListAsync()
        {
            var productList = userService.GetProductListAsync();
            return productList;

        }

        [HttpGet("getofferbyid")]
        public Task<ProductOfferDetail> GetProductByIdAsync(int Id)
        {
            return userService.GetProductByIdAsync(Id);
        }
    
    }
}
