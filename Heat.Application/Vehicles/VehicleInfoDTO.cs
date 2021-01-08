using System;
using System.Collections.Generic;
using System.Text;

namespace Heat.Application
{
    public class VehicleInfoDTO
    {
        public int ID { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public int RouteID { get; set; }
        public string Route { get; set; }
        public IEnumerable<VehicleInfoDetailDTO> Atributtes { get; set; }
        public IEnumerable<ReviewDTO> Reviews { get; set; }
    }
}