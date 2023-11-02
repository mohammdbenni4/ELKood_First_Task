using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Company
    {
        [Key]
        public string Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyLocation { get; set; }
        public int ConstructionYear { get; set; }
        public string CompanyActivity { get; set; }

        public string ProductId { get; set; }

        public List<Brunch>? Brunches { get; set; }


    }
}
