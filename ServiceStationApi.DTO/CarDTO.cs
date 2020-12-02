using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceStationApi.DTO
{
    public class CarDTO
    {
        public int Id { get; set; }
        public string CarModel { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public CustomerDTO CustomerDTO { get; set; }
        
    }
}
