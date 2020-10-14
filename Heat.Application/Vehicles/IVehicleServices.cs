using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Heat.Application.Entities;

namespace Heat.Application.Vehicles
{
    public interface IVehicleServices
    {
        Task<VehiclesLogVM> SaveLocationAsync(VehiclesLogVM viewModel);
        Task<List<VehiclesLogVM>> GetLocationsAsync();
        Task<Vehiculo> GetVehicleInfoAsync(int id);

    }
}
