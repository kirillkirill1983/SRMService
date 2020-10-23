using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceStationApi.Domain
{
    public class Worker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public List<Service> Services { get; set; }
    }
}
