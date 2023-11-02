using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Companies.Commands.CreateNewCompany
{
    public class CreateCompanyCommand : IRequest<CompanyViewModel> 
    {
        public string CompanyName { get; set; }
        public string CompanyLocation { get; set; }
        public int ConstructionYear { get; set; }
        public string CompanyActivity { get; set; }
        public string ProductName { get; set; }
        public string ProductType { get; set; }

    }
}
