using ServiceStationApi.Domain;
using ServiceStationApi.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStationApi.Business
{
     public interface ICustomerService
    {
        Task<bool> AddAsync(CustomerDTO customerDto);
        Task<List<CustomerDTO>> GetAllAsynс();
        Task<bool> UpDateAsync(CustomerDTO customerDTO);
        Task<CustomerDTO> GetByIdAsync(long Id);
        Task<CustomerDTO> DeleteAsync(long Id);
    }
}
