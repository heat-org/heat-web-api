using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Heat.Application.Entities;
using Microsoft.EntityFrameworkCore;

namespace Heat.Application.Vehicles
{
    public class VehicleServices : IVehicleServices
    {
        private IHeatContext context;
        private readonly IMapper _mapper;

        public VehicleServices(IHeatContext context, IMapper mapper)
        {
            this.context = context;
            _mapper = mapper;

        }

        public async Task<VehiclesLogVM> SaveLocationAsync(VehiclesLogVM viewModel)
        {
            var bitacora = new BitacoraUbicacion();
            bitacora.VehiculoId = viewModel.VehiculoId;
            bitacora.Ubicacion = viewModel.Ubicacion;
            context.BitacoraUbicacion.Add(bitacora);
            await context.SaveChangesAsync();
            return viewModel;
        }

        public async Task<List<VehiclesLogVM>> GetLocationsAsync()
        {
            
            return _mapper.Map<List<VehiclesLogVM>>(await context.BitacoraUbicacion.ToListAsync());

             
        }

        public async Task<Vehiculo> GetVehicleInfoAsync(int id)
        {
            return await context.Vehiculo.Include(x => x.BitacoraUbicacion)
                .Include(x => x.ConductorActual)
                .Include(x => x.Ruta)
                .Include(x => x.TipoVehiculo)
                .Include(x => x.VehiculoDetalle)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

    }
}
