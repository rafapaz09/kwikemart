using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Kwikemart_API.Models;
using Kwikemart_API.Services;

namespace Kwikemart_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        public IOrderService _orderService { get; }

        public OrdersController()
        {
            _orderService = new OrderService();
        }

        /// <summary>
        /// Set new order from an user
        /// </summary>
        /// <param name="orders"></param>
        /// <returns></returns>
        [HttpPost]
        
        public async Task<ActionResult> Post([FromBody] OrdersDto orders)
        {
            try
            {
                await _orderService.SetOrderAsync(orders);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}