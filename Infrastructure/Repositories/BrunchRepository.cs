using Application.Features.Brunches.Commands.CreateNewBrunch;
using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BrunchRepository : IBrunchRepository
    {
        private readonly ApplicationDbContext _context;
        public BrunchRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<BrunchViewModel> CreateBrunch(BrunchViewModel model)
        {

            if(model.CompanyName==""||model.BrunchName==""||model.BrunchLocation=="")
            {
                model.Message = " All Fields are requierd";
                return model;
            }

            var comp = await _context.Companies.SingleOrDefaultAsync(c =>c.CompanyName==model.CompanyName);

            if (comp == null)
            {
                model.Message = "There Is no Company With This Name ! ";
                return model;
            }

            var brunches = await _context.Brunches.Where(b => b.CompanyId == comp.Id).ToListAsync();
            bool ok = true;
            for(int i = 0; i < brunches.Count; i++)
            {
                if (brunches[i].BrunchName==model.BrunchName)
                {
                    ok=false; break;
                }
            }

            if(!ok)
            {
                model.Message = "This brunch already exsist !";
                return model;   
            }

            var newBrunch = new Brunch
            {
                Id = model.Id,
                BrunchLocation = model.BrunchLocation,
                BrunchName = model.BrunchName,
                IsItMainBrunch = model.IsItMainBrunch,
                CompanyId = comp.Id,
                Company = comp,
                  
                
            };
             comp.Brunches?.Add(newBrunch);
            await _context.Brunches.AddAsync(newBrunch); 
            await _context.SaveChangesAsync();
            return model;
        }
    }
}
