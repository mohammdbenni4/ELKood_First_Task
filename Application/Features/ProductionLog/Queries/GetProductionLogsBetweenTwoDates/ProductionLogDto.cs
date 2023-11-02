using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductionLog.Queries.GetProductionLogsBetweenTwoDates
{
    public class ProductionLogDto
    {
        public string? Id { get; set; }
        public string? Message { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        
    }
}
