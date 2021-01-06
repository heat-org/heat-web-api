using System;
using System.Collections.Generic;
using System.Text;

namespace Heat.Application
{
    public class RutaDTO
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public string Codigo { get; set; }
        public string Ubicacion { get; set; }
        public int TiempoEstimadoSegundos { get; set; }
        public int ConductorID { get; set; }
        public string Conductor { get; set; }
        public string From { get; set; }
        public string To { get; set; }
    }
}