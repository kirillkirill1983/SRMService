using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceStationApi.DTO
{
     public class WorkerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public List<ServiceDTO> Services { get; set; }

    }
}
