using Heat.Application.Vehicles;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heat.WebApi.Hubs
{
    public class TrackerHub : Hub
    {
        private IVehicleServices _services;
        public TrackerHub(IVehicleServices service)
        {
            _services = service;
        }
        public Task UpdateVehiclePosition(VehicleDTO vehicle)
        {
            //var dto = new VehicleDTO
            //{
            //    ID = vehicle.VehiculoId.GetValueOrDefault(0),
            //    Location = vehicle.Ubicacion
            //};
            return Clients.All.SendAsync("SetVehiclePosition", vehicle);
        }
    }
}