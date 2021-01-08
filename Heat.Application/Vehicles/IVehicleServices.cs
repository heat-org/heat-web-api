using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Heat.Persistance.Entities;

namespace Heat.Application.Vehicles
{
    public interface IVehicleServices
    {
        Task<VehiclesLogVM> SaveLocationAsync(VehiclesLogVM viewModel);
        Task<VehicleDTO> GetVehicleInfoAsync(int id);
        Task<IEnumerable<VehicleDTO>> GetAllActives();
    }
}