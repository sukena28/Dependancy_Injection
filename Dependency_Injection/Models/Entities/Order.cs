namespace Dependency_Injection
{
    public class Order
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
   
    public enum OrderStatus
    {
        New =1 ,
        Pendding = 2,
        Completed = 3,
        Cancled = 4
    }
}