using AutoMapper;
using Heat.Application.Common;
using Heat.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heat.Application
{
    public class StopService : BaseService, IStopService
    {
        #region Constructors
        public StopService(HeatContext context, IMapper mapper) : base(context, mapper) { }
        #endregion

        #region Methods
        public async Task<IEnumerable<StopDTO>> GetByRouteID(int routeID)
        {
            if (routeID == 0)
                return (await _unit.Parada.Get(filter: p => p.EstatusId == 1 && p.Orden != null,
                                               includeProperties: "Ruta")).Select(p => _mapper.Map<StopDTO>(p));
            else
                return (await _unit.Parada.Get(filter: p => p.RutaId == routeID && p.EstatusId == 1 && p.Orden != null,
                                               includeProperties: "Ruta")).Select(p => _mapper.Map<StopDTO>(p));
        }
        #endregion
    }
}