using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Heat.Application.Common;
using Heat.Persistance.Context;
using Heat.Persistance.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Heat.Application.Vehicles
{
    public class VehicleServices : BaseService, IVehicleServices
    {
        #region Constructor
        public VehicleServices(HeatContext context, IMapper mapper) : base(context, mapper) { }
        #endregion

        public async Task<VehiclesLogVM> SaveLocationAsync(VehiclesLogVM viewModel)
        {
            string query = "dbo.SP_Save_Bitacora @VehiculoID,@Ubicacion";
            await _unit.Parada.ExecuteProcedure(query, new SqlParameter("VehiculoID", viewModel.VehiculoId),
                                                       new SqlParameter("Ubicacion", viewModel.Ubicacion ?? string.Empty));
            return viewModel;
        }
        public async Task<VehicleDTO> GetVehicleInfoAsync(int id)
        {
            return (await _unit.Vehiculo.Get(filter: p => p.Id == id))
                               .Select(a => _mapper.Map<VehicleDTO>(a))
                               .FirstOrDefault();
        }
        public async Task<IEnumerable<VehicleDTO>> GetAllActives()
        {
            return (await _unit.Vehiculo.Get()).Select(a => _mapper.Map<VehicleDTO>(a));
        }
    }
}