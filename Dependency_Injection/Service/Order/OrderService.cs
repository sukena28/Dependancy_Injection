using Dependency_Injection.Repositories;
using Dependency_Injection.Services;

namespace Dependency_Injection.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IEnumerable<INotificationService> _messageSenderServices;

        public OrderService(IOrderRepository orderRepository, IEnumerable<INotificationService> messageSenderServices)
        {
            _orderRepository = orderRepository;
            _messageSenderServices = messageSenderServices;
        }
        public IEnumerable<Order> GetAll()
        {
            return _orderRepository.GetAll();
        }

        public Order Get(int id)
        {
            return _orderRepository.GetById(id);
        }

        public Order CompleteOrder(int id)
        {
           var order = _orderRepository.GetById(id);

            if (order == null)
                throw new Exception($"Order of Id {id} is not exists");

            order.Status = OrderStatus.Completed;

            _orderRepository.Edit(id, order);

            //Notify that Order Status is changed
            string message = $"Order status with ID: {id} is changes to compolete ";


            //IEnumrable DI Registeration
            foreach( var messageSender in _messageSenderServices)
            {
                messageSender.SenMessage(message);
            }

           return order;
        }

    }
}
