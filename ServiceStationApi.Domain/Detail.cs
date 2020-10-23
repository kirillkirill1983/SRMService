using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceStationApi.Domain
{
    public class Detail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int WorkId { get; set; }
        public Work Work { get; set; }

    }
}
