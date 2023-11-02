using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.DistributionLog.Commands.CreateDistributionLog
{
    public class CreateDistributionlogCommandHandler : IRequestHandler<CreateDistributionlogCommand, DistributionLogViewModel>
    {
        private readonly IDistributionLogRepository _distributionlogRepository;
        public CreateDistributionlogCommandHandler(IDistributionLogRepository distributionlogRepository)
        {
            _distributionlogRepository = distributionlogRepository;
        }
        public async Task<DistributionLogViewModel> Handle(CreateDistributionlogCommand request, CancellationToken cancellationToken)
        {

            var dislog = new DistributionLogViewModel
            {
                Id = Guid.NewGuid().ToString(),
                Amount = request.Amount,
                Date = request.Date,
                MainBrunchName = request.MainBrunchName,
                SecondaryBrunchName = request.SecondaryBrunchName,
                Message = "",
                CompanyName = request.CompanyName
            };

            var result  = await _distributionlogRepository.CreateDistributionLog(dislog);

           return result;
        }
    }
}
