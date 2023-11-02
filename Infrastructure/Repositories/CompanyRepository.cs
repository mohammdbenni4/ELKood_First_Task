using Application.Features.Companies.Commands.CreateNewCompany;
using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Infrastructure.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _context;

        public CompanyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CompanyViewModel> CreateCompany(Company company, Product product)
        {
            var comp = new CompanyViewModel
            {
                Id = company.Id,
                CompanyName = company.CompanyName,
                ConstructionYear = company.ConstructionYear,
                CompanyActivity = company.CompanyActivity,
                CompanyLocation = company.CompanyLocation,
            };


            if (company.CompanyName==""||company.CompanyLocation==""||company.CompanyActivity==""||product.ProductName==""||product.ProductType=="")
            {
                comp.Message = "All Fields are Required ";
                return comp;
            } 
            

            var compExist = await _context.Companies.SingleOrDefaultAsync(o=>o.CompanyName==company.CompanyName);
            if (compExist != null)
            {
                comp.Message = "This Company ALREADY Exist !!";
                return comp;
            }
            
            

            if (company.ConstructionYear < 1910)
            {
                comp.Message = "Sorry Construction year must be greater than or equal 1910";
                return comp;
            }

            await _context.Companies.AddAsync(company);
            await _context.Products.AddAsync(product) ;

            await _context.SaveChangesAsync();

            return comp;
        }
    }
}
