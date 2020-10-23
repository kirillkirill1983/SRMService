using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceStationApi.Domain
{
    public class Service
    {
        public int Id { get; set; }
        public string Description{ get; set; }
        public DateTime Date { get; set; }
        public int WorkerId { get; set; }
        public Worker Worker { get; set; }
        public int WorkId {get;set;}
        public Work Work { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }

    }
}
