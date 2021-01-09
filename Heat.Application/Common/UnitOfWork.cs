using Heat.Persistance;
using Heat.Persistance.Common;
using Heat.Persistance.Context;
using Heat.Persistance.Entities;

namespace Heat.Application.Common
{
    public class UnitOfWork
    {
        #region Properties
        HeatContext context;
        #endregion

        #region Constructors        
        public UnitOfWork(HeatContext context)
        {
            this.context = context;
        }
        #endregion

        #region Properties
        private IRepository<Usuario> _Usuario;
        public IRepository<Usuario> Usuario
        {
            get
            {
                if (_Usuario == null)
                {
                    _Usuario = new Repository<Usuario>(context);
                }
                return _Usuario;
            }
        }
        private IRepository<Ruta> _Ruta;
        public IRepository<Ruta> Ruta
        {
            get
            {
                if (_Ruta == null)
                {
                    _Ruta = new Repository<Ruta>(context);
                }
                return _Ruta;
            }
        }
        private IRepository<Parada> _Parada;
        public IRepository<Parada> Parada
        {
            get
            {
                if (_Parada == null)
                {
                    _Parada = new Repository<Parada>(context);
                }
                return _Parada;
            }
        }
        private IRepository<Vehiculo> _Vehiculo;
        public IRepository<Vehiculo> Vehiculo
        {
            get
            {
                if (_Vehiculo == null)
                {
                    _Vehiculo = new Repository<Vehiculo>(context);
                }
                return _Vehiculo;
            }
        }
        private IRepository<BitacoraUbicacion> _BitacoraUbicacion;
        public IRepository<BitacoraUbicacion> BitacoraUbicacion
        {
            get
            {
                if (_BitacoraUbicacion == null)
                {
                    _BitacoraUbicacion = new Repository<BitacoraUbicacion>(context);
                }
                return _BitacoraUbicacion;
            }
        }
        private IRepository<Comentario> _Comentario;
        public IRepository<Comentario> Comentario
        {
            get
            {
                if (_Comentario == null)
                {
                    _Comentario = new Repository<Comentario>(context);
                }
                return _Comentario;
            }
        }
        private IRepository<VehiculoDetalle> _VehiculoDetalle;
        public IRepository<VehiculoDetalle> VehiculoDetalle
        {
            get
            {
                if (_VehiculoDetalle == null)
                {
                    _VehiculoDetalle = new Repository<VehiculoDetalle>(context);
                }
                return _VehiculoDetalle;
            }
        }
        private IRepository<Reporte> _Reporte;
        public IRepository<Reporte> Reporte
        {
            get
            {
                if (_Reporte == null)
                {
                    _Reporte = new Repository<Reporte>(context);
                }
                return _Reporte;
            }
        }
        private IRepository<TipoReporte> _TipoReporte;
        public IRepository<TipoReporte> TipoReporte
        {
            get
            {
                if (_TipoReporte == null)
                {
                    _TipoReporte = new Repository<TipoReporte>(context);
                }
                return _TipoReporte;
            }
        }
        #endregion
    }
}