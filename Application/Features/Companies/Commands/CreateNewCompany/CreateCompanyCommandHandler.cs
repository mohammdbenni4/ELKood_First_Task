using Application.Interfaces;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Application.Features.Companies.Commands.CreateNewCompany
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, CompanyViewModel>
    {
        private readonly ICompanyRepository _companyRepository;
        public CreateCompanyCommandHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public async Task<CompanyViewModel> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            
            string prodGuid = Guid.NewGuid().ToString();
            var comp = new Company
            {
                Id = Guid.NewGuid().ToString(),
                CompanyActivity = request.CompanyActivity,
                CompanyName = request.CompanyName,
                CompanyLocation = request.CompanyLocation,
                ConstructionYear = request.ConstructionYear,
                ProductId = prodGuid
               
               
            };
            var newProd = new Product
            {
                Id = prodGuid,
                ProductName = request.ProductName,
                ProductType = request.ProductType,
                CompanyId = comp.Id,
            };

           var result =  await _companyRepository.CreateCompany(comp,newProd);

            return result;
        }
    }
}
