﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Heat.Application.Vehicles
{
    public class VehicleDTO
    {
        public int ID { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public int RouteID { get; set; }
    }
}