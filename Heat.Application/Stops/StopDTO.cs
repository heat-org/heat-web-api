using System;
using System.Collections.Generic;
using System.Text;

namespace Heat.Application
{
    public class StopDTO
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public int Order { get; set; }
        public string Street { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int RouteID { get; set; }
        public string Route { get; set; }
        public string RouteCode { get; set; }
        public int StatusID { get; set; }
    }
}
