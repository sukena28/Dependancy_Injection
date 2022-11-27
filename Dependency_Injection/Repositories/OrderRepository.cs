namespace Dependency_Injection.Repositories
{
    public class OrderRepository: IOrderRepository
    {
        private static IEnumerable<Order> _orders;
        public OrderRepository()
        {
            Seed();
        }
        public IEnumerable<Order> GetAll()
        {
            return _orders;
        }
        public Order GetById(int id)
        {
            var order = _orders.FirstOrDefault(x => x.Id == id);

            if (order == null)
                throw new Exception($"The Order of id {id} is not exists");

            return order;
        }

        public Order Edit(int id, Order input)
        {
            var order = _orders.FirstOrDefault(x => x.Id == id);

            if (order == null)
                throw new Exception($"The Order of id {id} is not exists");


            order.Status = input.Status;
            order.Name = input.Name;
            order.Price  = input.Price;

            return _orders.FirstOrDefault(x => x.Id == id) ?? new Order();

        }
        private void Seed()
        {
            if (_orders == null)
            {
                _orders = new List<Order>()
            {
                new Order() { Id =  1, Name = "Order 1", Price = 20},
                new Order() { Id =  2, Name = "Order 2", Price = 50}
            };
            }


        }
    }
}
