namespace Dependency_Injection.Service
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAll();

        Order Get(int id);

        Order CompleteOrder(int id);


    }
}
