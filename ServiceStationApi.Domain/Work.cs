﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceStationApi.Domain
{
    public class Work
    {
        public int Id { get; set; }
        public string TypeWokr{ get; set; }
        public decimal Price { get; set; }
        public List<Detail> Details { get; set; }
        public List<Service> Services { get; set; }
    }
}
