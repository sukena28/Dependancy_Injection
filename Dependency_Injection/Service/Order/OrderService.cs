using AutoMapper;
using Dependency_Injection.Models.DTOs;
using Dependency_Injection.Repositories;
using Dependency_Injection.Services;

namespace Dependency_Injection.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IEnumerable<INotificationService> _messageSenderServices;
        private readonly IMapper _mapper;
        public OrderService(
            IMapper mapper,
            IOrderRepository orderRepository,
            IEnumerable<INotificationService> messageSenderServices)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _messageSenderServices = messageSenderServices;
        }
        public IEnumerable<OrderDto> GetAll()
        {
            var records = _orderRepository.GetAll();

            return _mapper.Map<IEnumerable<OrderDto>>(records);
        }

        public OrderDto Get(int id)
        {
            var record = _orderRepository.GetById(id);

            return _mapper.Map<OrderDto>(record);
        }

        public OrderDto CompleteOrder(int id)
        {
            var record = _orderRepository.GetById(id);


            record.Status = OrderStatus.Completed;

            _orderRepository.Edit(id, record);

            foreach (var messageSender in _messageSenderServices)
            {
                messageSender.SenMessage($"Order status with ID: {id} is changes to compolete ");
            }

            return _mapper.Map<OrderDto>(record); 
        }

    }
}
