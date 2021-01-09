using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Heat.Application
{
    public interface IReviewService
    {
        Task<bool> Save(ReviewDTO model);
        Task<bool> Report(ReportDTO model);
        Task<IEnumerable<ReviewDTO>> Get(int vehicleID);
        Task<IEnumerable<TypeReportDTO>> GetTypesReport();
    }
}
