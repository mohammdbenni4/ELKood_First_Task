using Application.Features.Companies.Commands.CreateNewCompany;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICompanyRepository
    {
        Task<CompanyViewModel> CreateCompany(Company company,Product product);
    }
}
