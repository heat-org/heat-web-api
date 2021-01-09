using System.Collections.Generic;

namespace Heat.Application
{
    public class VehicleInfoDTO
    {
        public int ID { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string Plate { get; set; }
        public int RouteID { get; set; }
        public string Route { get; set; }
        public int TypeID { get; set; }
        public string Type { get; set; }
        public int ConductorID { get; set; }
        public string Conductor { get; set; }
        public string PhotoConductor { get; set; }
        public string DateEntryConductor { get; set; }
        public decimal Rating { get; set; }
        public IEnumerable<VehicleInfoDetailDTO> Atributtes { get; set; }
        public IEnumerable<ReviewDTO> Reviews { get; set; }
    }
}