using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class DistributionLog
    {
        [Key]
        public string Id { get; set; }
        public string MainBrunchId { get; set; }
        public string SecondaryBrunchId { get; set; }

        public DateTime Date { get; set; }
        public int Amount { get; set; }
    }
}
