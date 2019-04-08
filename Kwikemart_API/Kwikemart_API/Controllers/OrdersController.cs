using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Kwikemart_API.Models;
using Kwikemart_API.Services;
using Microsoft.AspNetCore.Authorization;

namespace Kwikemart_API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {

        public IOrderService _orderService { get; }

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// Set new order from an user(Only logged Users can buy a product)
        /// </summary>
        /// <param name="orders"></param>
        /// <returns></returns>
        [Authorize(Roles = "User")]
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