namespace Heat.Persistance.Entities
{
    public class SP_Buscar_RutasInfo
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public string Color { get; set; }
        public string Code { get; set; }
        public string Ubicacion { get; set; }
        public int TiempoEstimadoSegundos { get; set; }
        public int ConductorID { get; set; }
        public string Conductor { get; set; }
        public string Desde { get; set; }
        public string Hasta { get; set; }
        public int? HastaOrden { get; set; }
        public int? DesdeOrden { get; set; }
    }
}