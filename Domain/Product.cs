using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Product
    {
        [Key]
        public string Id { get; set; }
        public string ProductName { get; set; }
        public string ProductType { get; set; }

        public string CompanyId { get; set;}
        
    }
}
