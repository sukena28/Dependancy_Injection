namespace Dependency_Injection.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();
        Order Edit(int id, Order input);
        Order GetById(int id);

    }
}
