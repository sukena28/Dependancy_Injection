using Dependency_Injection.Service;
using Microsoft.AspNetCore.Mvc;

namespace Dependency_Injection.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult Get()
        {
           var result = _orderService.GetAll();

           return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id )
        {
            var result = _orderService.Get(id);

            return Ok(result);
        }

        [HttpGet("complete")]
        public IActionResult CompleteOrder(int id)
        {
            var result = _orderService.CompleteOrder(id);

            return Ok(result);
        }

    }
}