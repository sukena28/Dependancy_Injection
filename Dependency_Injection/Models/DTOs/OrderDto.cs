namespace Dependency_Injection.Models.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; }
        public string Name { get; set; }
    }
}
