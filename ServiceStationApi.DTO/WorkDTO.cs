using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceStationApi.DTO
{
    public class WorkDTO
    {
        public int Id { get; set; }
        public string TypeWokr { get; set; }
        public decimal Price { get; set; }
        public List<DetailDTO> Details { get; set; }
        public List<ServiceDTO> Services { get; set; }

    }
}
