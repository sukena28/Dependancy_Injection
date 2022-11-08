using Dependency_Injection.Repositories;
using Dependency_Injection.Service;
using Microsoft.AspNetCore.Mvc;

namespace Dependency_Injection.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IEnumerable<Order> Get()
        {
           return _orderService.GetAll();
        }

        [HttpGet("complete")]
        public Order CompleteOrder(int id)
        {
            return _orderService.CompleteOrder(id);
        }

    }
}