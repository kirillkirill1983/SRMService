using AutoMapper;
using Microsoft.EntityFrameworkCore.Query.Internal;
using ServiceStationApi.Domain;
using ServiceStationApi.DTO;
using ServiceStationApi.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStationApi.Business
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository,IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddAsync(CustomerDTO customerDto)
        {
            var customer=_mapper.Map<CustomerDTO,Customer>(customerDto);
            var result = await _customerRepository.Add(customer);
            return result;
        }

        public async Task<CustomerDTO> DeleteAsync(long Id)
        {
            Customer result = await _customerRepository.Delete(Id);
            var customer = _mapper.Map<Customer, CustomerDTO>(result);

            return customer;
        }

        public async Task<List<CustomerDTO>> GetAllAsynс()
        {
            var result = await _customerRepository.GetAll();
            return _mapper.Map<List<Customer>, List<CustomerDTO>>(result);
            
        }

        public async Task<CustomerDTO> GetByIdAsync(long Id)
        {
            var result = await _customerRepository.GetById(Id);
            var customer = _mapper.Map<Customer, CustomerDTO>(result);
            return customer;
        }

        public async Task<bool> UpDateAsync(CustomerDTO customerDTO)
        {
            var customer = _mapper.Map<CustomerDTO, Customer>(customerDTO);
                
            var result = await _customerRepository.Update(customer);
                return result;
     
        }
    }
}
