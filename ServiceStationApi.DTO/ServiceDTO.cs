using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceStationApi.DTO
{
    public class ServiceDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int WorkerId { get; set; }
        public WorkDTO WorkDTO { get; set; }
        public WorkerDTO WorkerDTO { get; set; }
    }
}
