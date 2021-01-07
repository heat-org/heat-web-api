using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Heat.Application
{
    public interface IStopService
    {
        Task<IEnumerable<StopDTO>> GetByRouteID(int routeID);
    }
}