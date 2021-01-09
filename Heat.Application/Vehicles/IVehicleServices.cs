using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Heat.Persistance.Entities;

namespace Heat.Application.Vehicles
{
    public interface IVehicleServices
    {
        VehiclesLogVM SaveLocation(VehiclesLogVM viewModel);
        Task<VehicleInfoDTO> GetVehicleInfoAsync(int id);
        Task<IEnumerable<VehicleDTO>> GetAllActives();
    }
}