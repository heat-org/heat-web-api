using AutoMapper;
using Heat.Application.Common;
using Heat.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heat.Application
{
    public class RouteService : BaseService, IRouteService
    {
        #region Constructor
        public RouteService(HeatContext context, IMapper mapper) : base(context, mapper) { }
        #endregion

        #region Methods
        public async Task<IEnumerable<RutaDTO>> GetAll()
        {
            return (await _unit.Ruta.Get()).Select(p => _mapper.Map<RutaDTO>(p));
        }
        public async Task<IEnumerable<RutaDTO>> GetAllInfo()
        {
            string query = "dbo.SP_Buscar_RutasInfo";
            return await _context.SP_Buscar_RutasInfo.FromSqlRaw(query).Select(p => _mapper.Map<RutaDTO>(p)).ToListAsync();
        }
        #endregion
    }
}