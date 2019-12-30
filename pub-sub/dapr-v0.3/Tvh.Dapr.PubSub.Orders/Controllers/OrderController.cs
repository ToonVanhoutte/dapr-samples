using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Dapr;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Tvh.Dapr.PubSub.Orders.Models;

namespace Tvh.Dapr.PubSub.Orders.Controllers
{
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("api/order")]
        public async Task<IActionResult> ReceiveOrder([FromBody]Order order)
        {
            _logger.LogInformation($"Order with id {order.id} received!");

            //Validate order placeholder

            using (var httpClient = new HttpClient())
            {
                var result = await httpClient.PostAsync(
                    "http://localhost:3500/v1.0/publish/ordertopic",
                    new StringContent(JsonConvert.SerializeObject(order), Encoding.UTF8, "application/json")
                );

                _logger.LogInformation($"Order with id {order.id} published with status {result.StatusCode}!");
            }

            return Ok();
        }

        [Topic("ordertopic")]
        [HttpPost]
        [Route("ordertopic")]
        public async Task<IActionResult> ProcessOrder([FromBody]Order order)
        {
            //Process order placeholder
                
            _logger.LogInformation($"Order with id {order.id} processed!");
            return Ok();
        }
    }
}