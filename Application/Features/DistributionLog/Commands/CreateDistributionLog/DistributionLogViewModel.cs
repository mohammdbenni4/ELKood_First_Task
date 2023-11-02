using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.DistributionLog.Commands.CreateDistributionLog
{
    public class DistributionLogViewModel
    {
        public string Id { get; set; }
        public string  CompanyName { get; set; }
        public string MainBrunchName { get; set; }
        public string SecondaryBrunchName { get; set; }
        public string? Message { get; set; }

        public DateTime Date { get; set; }
        public int Amount { get; set; }
    }
}
