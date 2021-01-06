using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Heat.Application
{
    public interface IRouteService
    {
        Task<IEnumerable<RutaDTO>> GetAll();
        Task<IEnumerable<RutaDTO>> GetAllInfo();
    }
}