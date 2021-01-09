using AutoMapper;
using Heat.Application.Common;
using Heat.Persistance.Context;
using Heat.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heat.Application
{
    public class ReviewService : BaseService, IReviewService
    {
        #region Constructor
        public ReviewService(HeatContext context, IMapper mapper) : base(context, mapper) { }
        #endregion

        #region Methods
        public async Task<bool> Save(ReviewDTO model)
        {
            bool isSaved = false;
            var usuario = (await _unit.Usuario.Get(filter: p => p.Username == model.User)).FirstOrDefault();

            if (usuario != null)
            {
                var review = new Comentario();
                review.Texto = model.Text;
                review.EstatusId = 1;
                review.IndReportado = 0;
                review.UsuarioId = usuario.Id;
                review.DateCreated = DateTime.Now;
                review.UserCreated = usuario.Username;
                review.VehiculoId = model.VehicleID;

                await _unit.Comentario.Insert(review);
                await _unit.Comentario.SaveChanges();
                isSaved = true;
            }

            return isSaved;
        }
        public async Task<bool> Report(ReportDTO model)
        {
            bool isSaved = false;
            var review = (await _unit.Comentario.Get(filter: p => p.Id == model.ReviewID)).FirstOrDefault();
            if (review != null)
            {
                review.IndReportado = 1;
                review.UserModify = model.User;
                review.DateModify = DateTime.Now;
                await _unit.Comentario.Update(review);
                await _unit.Comentario.SaveChanges();

                var report = new Reporte
                {
                    Texto = model.Text,
                    TipoReporteId = model.TypeID,
                    ComentarioId = model.ReviewID,
                    EstatusId = 1,
                    UserCreated = model.User,
                    DateCreated = DateTime.Now
                };
                await _unit.Reporte.Insert(report);
                await _unit.Reporte.SaveChanges();

                isSaved = true;
            }

            return isSaved;
        }

        public async Task<IEnumerable<ReviewDTO>> Get(int vehicleID)
        {
            return (await _unit.Comentario.Get(filter: p => p.VehiculoId == vehicleID && p.IndReportado.GetValueOrDefault(0) == 0,
                                               orderBy: order => order.OrderByDescending(a => a.Id)))
                                              .Select(a => _mapper.Map<ReviewDTO>(a));
        }
        public async Task<IEnumerable<TypeReportDTO>> GetTypesReport()
        {
            return (await _unit.TipoReporte.Get()).Select(a => _mapper.Map<TypeReportDTO>(a));
        }
        #endregion
    }
}
