using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductionLog.Commands.CreateProductionLog
{
    public class CreateProductionLogCommand :IRequest<ProductionLogViewModel>
    {
        public string CompanyName { get; set; }
        public string BrunchName { get; set; }
        public int Amount {get; set; }
        public DateTime DateOfCreate { get; set; }

       

    }
}
