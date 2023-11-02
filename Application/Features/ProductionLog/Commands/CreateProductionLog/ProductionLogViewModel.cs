using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductionLog.Commands.CreateProductionLog
{
    public class ProductionLogViewModel
    {
        public string? Id { get; set; }
        public int Amount { get; set; }
        public DateTime DateOfCreate { get; set; }
        public string? CompanyId { get; set; }
        public string? CompanyName { get; set;}
        public string? BrunchName { get; set;}


        public string? Message { get; set;}
    }
}
