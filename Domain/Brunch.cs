using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Brunch
    {
        [Key]
        public string Id { get; set; }
        public string BrunchName { get; set; }
        public string BrunchLocation { get; set; }
        public bool IsItMainBrunch { get; set; }

        [Required]
        public string CompanyId { get; set; }
        public Company Company { get; set; }


    }
}
