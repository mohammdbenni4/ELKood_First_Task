using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductionLog.Queries.GetProductionLogsBetweenTwoDates
{
    public class FindTheRequirdBrunch
    {
        public string CompanyName { get; set; }
        public string BrunchName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
