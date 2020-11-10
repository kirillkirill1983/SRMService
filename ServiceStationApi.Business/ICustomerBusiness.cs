using ServiceStationApi.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStationApi.Business
{
     public interface ICustomerBusiness
    {
        Task<bool> AddAsync(Customer customer);
    }
}
