using AutoMapper;
using ServiceStationApi.Domain;
using ServiceStationApi.DTO;

namespace ServiceStationApi.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Car, CarDTO>().ReverseMap();
            CreateMap<Detail, DetailDTO>().ReverseMap();
            CreateMap<Work, WorkDTO>().ReverseMap();
            CreateMap<Worker, WorkerDTO>().ReverseMap();
            CreateMap<Service, ServiceDTO>().ReverseMap();
        }
             
    }
}
