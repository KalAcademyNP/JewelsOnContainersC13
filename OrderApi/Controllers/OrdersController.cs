using Common.Messaging;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OrderApi.Data;
using OrderApi.Models;
using System;
using System.Net;
using System.Threading.Tasks;

namespace OrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly OrdersContext _ordersContext;

        private readonly IConfiguration _config;

        private readonly ILogger<OrdersController> _logger;
        private IPublishEndpoint _bus;

        public OrdersController(OrdersContext ordersContext,
            ILogger<OrdersController> logger,
            IConfiguration config
            , IPublishEndpoint bus
            )
        {
            _config = config;
            _logger = logger;
            _ordersContext = ordersContext;
            _bus = bus;
        }

        [HttpGet("{id}", Name = "[action]")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetOrder(int id)
        {

            var item = await _ordersContext.Orders
                .Include(x => x.OrderItems)
                .SingleOrDefaultAsync(ci => ci.OrderId == id);
            if (item != null)
            {
                return Ok(item);
            }

            return NotFound();

        }

        [Route("new")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateOrder([FromBody] Order order)
        {
            order.OrderStatus = OrderStatus.Preparing;
            order.OrderDate = DateTime.UtcNow;

            _logger.LogInformation(" In Create Order");
            _logger.LogInformation(" Order" + order.UserName);


            _ordersContext.Orders.Add(order);
            _ordersContext.OrderItems.AddRange(order.OrderItems);
            _logger.LogInformation(" Order added to context");
            _logger.LogInformation(" Saving........");

            try
            {
                await _ordersContext.SaveChangesAsync();
                _bus.Publish(new OrderCompletedEvent(order.BuyerId)).Wait();
                return Ok(new { order.OrderId });
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("An error occored during Order saving .." + ex.Message);
                return BadRequest();
            }
        }
    }
}
