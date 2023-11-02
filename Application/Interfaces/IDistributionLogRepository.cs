using Application.Features.DistributionLog.Commands.CreateDistributionLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IDistributionLogRepository
    {
        Task<DistributionLogViewModel> CreateDistributionLog(DistributionLogViewModel model);
    }
}
