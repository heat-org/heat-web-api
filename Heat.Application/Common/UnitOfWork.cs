using Heat.Persistance;
using Heat.Persistance.Common;
using Heat.Persistance.Context;
using Heat.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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
        #endregion
    }
}
