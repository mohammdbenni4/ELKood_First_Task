using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductionLog.Queries.GetProductionLogsBetweenTwoDates
{
    public class GetProductionLogsQueryHandler : IRequestHandler<GetProductionLogsQuery, List<ProductionLogDto>>
    {
        private readonly IProductionLogRepository _productionLog;

        public GetProductionLogsQueryHandler(IProductionLogRepository productionLog)
        {
            _productionLog = productionLog;
        }
        public async Task<List<ProductionLogDto>> Handle(GetProductionLogsQuery request, CancellationToken cancellationToken)
        {
            var m = new FindTheRequirdBrunch
            {
                BrunchName = request.BrunchName,
                CompanyName = request.CompanyName,
                EndDate = request.EndDate,
                StartDate = request.StartDate
            };
            var result = await _productionLog.GetProductionLogBetweenTwoDates(m);

           return result;
        }
    }
}
