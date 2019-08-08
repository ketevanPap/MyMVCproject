using AutoMapper;
using MyMVCproject.Dtos;
using MyMVCproject.Models;

namespace MyMVCproject.App_Start
{
    public class MappingProfile : Profile 
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
        }
    }
}