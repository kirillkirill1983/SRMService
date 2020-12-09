﻿using System.Collections.Generic;

namespace ServiceStationApi.DTO
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public List<CarDTO> Cars { get; set; }
     
    }
}
