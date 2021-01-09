using AutoMapper;
using Heat.Application.Common;
using Heat.Persistance.Context;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heat.Application.Vehicles
{
    public class VehicleServices : BaseService, IVehicleServices
    {
        #region Constructor
        public VehicleServices(HeatContext context, IMapper mapper) : base(context, mapper) { }
        #endregion

        public VehiclesLogVM SaveLocation(VehiclesLogVM viewModel)
        {
            string query = "dbo.SP_Save_Bitacora @VehiculoID,@Ubicacion";
            _unit.Parada.ExecuteProcedure(query, new SqlParameter("VehiculoID", viewModel.VehiculoId),
                                                      new SqlParameter("Ubicacion", viewModel.Ubicacion ?? string.Empty));
            return viewModel;
        }
        public async Task<VehicleInfoDTO> GetVehicleInfoAsync(int id)
        {
            var vehicleInfo = new VehicleInfoDTO();
            vehicleInfo = (await _unit.Vehiculo.Get(filter: p => p.Id == id,
                                             includeProperties: "Ruta,TipoVehiculo,ConductorActual"))
                               .Select(a => _mapper.Map<VehicleInfoDTO>(a))
                               .FirstOrDefault();
            vehicleInfo.Reviews = (await _unit.Comentario.Get(filter: p => p.VehiculoId == id && p.IndReportado.GetValueOrDefault(0) == 0))
                                              .Select(a => _mapper.Map<ReviewDTO>(a));

            vehicleInfo.Atributtes = (await _unit.VehiculoDetalle.Get(filter: p => p.VehiculoId == id,
                                                                      includeProperties: "Atributo",
                                                                      orderBy: a => a.OrderByDescending(w => w.Id)))
                                              .Select(a => _mapper.Map<VehicleInfoDetailDTO>(a));
            return vehicleInfo;
        }
        public async Task<IEnumerable<VehicleDTO>> GetAllActives()
        {
            return (await _unit.Vehiculo.Get()).Select(a => _mapper.Map<VehicleDTO>(a));
        }
    }
}