using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductionLog.Commands.CreateProductionLog
{
    public class CreateProductionLogCommandHandler : IRequestHandler<CreateProductionLogCommand, ProductionLogViewModel>
    {
        private readonly IProductionLogRepository _productionLogRepository;
        public CreateProductionLogCommandHandler(IProductionLogRepository productionLogRepository)
        {
            _productionLogRepository = productionLogRepository;
        }
        public Task<ProductionLogViewModel> Handle(CreateProductionLogCommand request, CancellationToken cancellationToken)
        {

            var newlog = new ProductionLogViewModel
            {
                Id = Guid.NewGuid().ToString(),
                Amount = request.Amount,
                DateOfCreate = request.DateOfCreate,
                CompanyName = request.CompanyName,
                BrunchName = request.BrunchName,
            };
            var result = _productionLogRepository.CreateProductionLog(newlog);

            return result;
        }
    }
}
