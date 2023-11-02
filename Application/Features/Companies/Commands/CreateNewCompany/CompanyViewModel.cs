using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Companies.Commands.CreateNewCompany
{
    public class CompanyViewModel
    {
        public string Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyLocation { get; set; }
        public int ConstructionYear { get; set; }
        public string CompanyActivity { get; set; }

        public string ProductId { get; set; }
        public string? Message { get; set; }
    }
}
