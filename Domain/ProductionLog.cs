using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ProductionLog
    {
        [Key]
        public string Id { get; set; }
        public int Amount { get; set; }
        public DateTime DateOfCreate { get; set; }

      /*  public string CompanyId { get; set; }
        public Company Company { get; set; }
*/
        public string BrunchId { get; set; }
        public Brunch Brunch { get; set; }
    }
}
