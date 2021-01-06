using AutoMapper;
using Heat.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heat.Application.Common
{
    public class BaseService
    {
        public readonly UnitOfWork _unit;
        public readonly IMapper _mapper;
        public readonly HeatContext _context;
        public BaseService(HeatContext context, IMapper mapper)
        {
            _unit = new UnitOfWork(context);
            _context = context;
            _mapper = mapper;
        }
        public BaseService(HeatContext context)
        {
            _unit = new UnitOfWork(context);
            _context = context;
        }
    }
}