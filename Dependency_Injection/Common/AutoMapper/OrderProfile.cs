using AutoMapper;
using Dependency_Injection.Models.DTOs;

namespace Dependency_Injection.AutoMapper
{
    public class OrderProfile: Profile
    {
        public OrderProfile()
        {
            CreateMap<Order,OrderDto>().ReverseMap();
        }
    }
}
