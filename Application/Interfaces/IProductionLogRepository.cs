using Application.Features.ProductionLog.Commands.CreateProductionLog;
using Application.Features.ProductionLog.Queries.GetProductionLogsBetweenTwoDates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProductionLogRepository
    {
        Task<ProductionLogViewModel> CreateProductionLog(ProductionLogViewModel model);
        Task<List<ProductionLogDto>> GetProductionLogBetweenTwoDates(FindTheRequirdBrunch model);
    }
}
