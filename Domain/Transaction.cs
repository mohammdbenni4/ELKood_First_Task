using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Transaction
    {
        [Key]
        public string Id { get; set; }
        public DateTime Date { get; set; }

        public int TransAmount { get; set; }

        public int NewAmountInThisBrunch { get; set; }

        public string BrunchId { get; set; }
        public Brunch Brunch { get; set; }

        public string? DistributionLogId { get; set; }
        public DistributionLog? DistributionLog { get; set; }


    }
}
