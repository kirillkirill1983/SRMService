using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceStationApi.DTO
{
    public class DetailDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int WorkId { get; set; }
        public WorkDTO WorkDTO { get; set; }
    }
}
