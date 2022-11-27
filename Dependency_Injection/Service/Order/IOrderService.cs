using Dependency_Injection.Models.DTOs;

namespace Dependency_Injection.Service
{
    public interface IOrderService
    {
        IEnumerable<OrderDto> GetAll();

        OrderDto Get(int id);

        OrderDto CompleteOrder(int id);


    }
}
