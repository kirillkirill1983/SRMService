using Microsoft.EntityFrameworkCore.Query.Internal;
using ServiceStationApi.Domain;
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

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<bool> AddAsync(Customer customer)
        {
            var tabl = new Customer();
            tabl.Name = customer.Name;
            tabl.Phone = customer.Phone;
            var result = await _customerRepository.Add(tabl);
            return result ;
        }

        public async Task<bool> DeleteAsync(long Id)
        {
            try
            {
                var result = await _customerRepository.Delete(Id);
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<Customer>> GetAllAsynk()
        {
            var customerList = new List<Customer>();
            var result = await _customerRepository.GetAll();
            foreach (var item in result)
            {
                customerList.Add(new Customer
                {
                    Id = item.Id,
                    Name = item.Name,
                    Phone = item.Phone,
                    Cars = item.Cars
                });

            }
            return customerList;
        }

        public async Task<Customer> GetByIdAsync(long Id)
        {
            var result = await _customerRepository.GetById(Id);
            var table = new Customer();
            table.Id = result.Id;
            table.Name = result.Name;
            table.Phone = result.Phone;
            table.Cars = result.Cars;
            return table;
        }

        public async Task<bool> UpDateAsync(Customer customer)
        {
            try
            {
                var table = new Customer();
                table.Id = customer.Id;
                table.Name = customer.Name;
                table.Phone = customer.Phone;
                table.Cars = customer.Cars;
                var result = await _customerRepository.Update(table);
                return result;

            }
            catch (Exception ex)
            {
                return false;

            } 
            
        }
    }
}
