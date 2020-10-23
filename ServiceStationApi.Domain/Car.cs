using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceStationApi.Domain
{
    public class Car
    {
        public int Id { get; set; }
        public string Car_model { get; set; }
        public string Nubber { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
