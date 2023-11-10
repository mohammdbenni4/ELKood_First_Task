using Application.Features.ProductionLog.Commands.CreateProductionLog;
using Application.Features.ProductionLog.Queries.GetProductionLogsBetweenTwoDates;
using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProductionLogRepository : IProductionLogRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductionLogRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ProductionLogViewModel> CreateProductionLog(ProductionLogViewModel model)
        {
            if(model.CompanyName==""||model.BrunchName=="")
            {
                model.Message = "All Fields are requierd";
                return model;
            }

            var comp = await _context.Companies.SingleOrDefaultAsync(c=>c.CompanyName==model.CompanyName);

            if (comp == null)
            {
                model.Message = "There is no Company under this Name !";
                return model;
            }
            var cy = comp.ConstructionYear;
            var da = new DateTime(cy,1,1,0,0,0);
            if (model.DateOfCreate < da) 
            {
                model.Message = " WOW! , Creation Day Befor The company Constructed ?!";
                return model;
            }
            if(model.DateOfCreate > DateTime.Now)
            {
                model.Message = "You can't produce prodects in future!";
                return model;
            }

            bool ok1 = false;
            bool ok2 = false;
            Brunch b = null; 
            var brunches = await _context.Brunches.Where(b=>b.CompanyId==comp.Id && b.IsItMainBrunch == true).ToListAsync();

          

            for(int i = 0;i<brunches.Count;i++)
            {
                if (brunches[i].BrunchName == model.BrunchName)
                {
                    ok1 = true;
                }
                if(brunches[i].IsItMainBrunch == true)
                {
                    ok2 = true;
                }
                if(brunches[i].BrunchName == model.BrunchName && brunches[i].IsItMainBrunch == true) b = brunches[i];
            }
            if (!ok2) { model.Message = "There is no main brunch in this company !"; return model; }
            if (!ok1) { model.Message = "There is no brunch under this name in this company !"; return model; }
           

            if (model.Amount < 0) 
            { model.Message = "you Can't prduce negative amount !!"; return model; }

            if (model.Amount == 0)
            { model.Message = "you Can't prduce zero amount !!"; return model; }

            var newlog = new ProductionLog
            {
                Id = model.Id,
                Amount = model.Amount,
                DateOfCreate = model.DateOfCreate,
                Brunch = b,
                BrunchId = b.Id,
            };

            var transactionsAfter = await _context.Transactions.Where(x => x.Date >= model.DateOfCreate && x.BrunchId == b.Id && x.DistributionLogId==null).ToListAsync();
            var transactions = await _context.Transactions.Where(x => x.Date <= model.DateOfCreate && x.BrunchId == b.Id&&x.DistributionLogId==null).ToListAsync();
            
            var LastTranFromBrunch = new Transaction();
            if (transactionsAfter.Any())
            {
                for (int i = 0; i < transactionsAfter.Count(); i++)
                    transactionsAfter[i].NewAmountInThisBrunch += model.Amount;

               

            }
            if (transactions.Any())
            {
                transactions.Sort((a, b) => a.Date.CompareTo(b.Date));
                LastTranFromBrunch = transactions[transactions.Count - 1];
                  

            }

            int curAmount = 0;
            if (transactions.Any()) curAmount = LastTranFromBrunch.NewAmountInThisBrunch;

            var transaction = new Transaction
            {
                Id = Guid.NewGuid().ToString(),
                Date = model.DateOfCreate,
                TransAmount = model.Amount,
                NewAmountInThisBrunch = curAmount + model.Amount,
                Brunch = b,
                BrunchId = b.Id,
                
            };

            
            await _context.ProductionLogs.AddAsync(newlog);
            await _context.Transactions.AddAsync(transaction);

            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<List<ProductionLogDto>> GetProductionLogBetweenTwoDates(FindTheRequirdBrunch model)
        {
            List<ProductionLogDto> list = new List<ProductionLogDto>();
            if (model.CompanyName == "" || model.BrunchName == "")
            {
                var l = new ProductionLogDto();
                l.Message = "There is no Company under this Name !";
                list.Add(l);
                return list;
            }

            var comp = await _context.Companies.SingleOrDefaultAsync(c => c.CompanyName == model.CompanyName);
            
            if (comp == null)
            {
                var l = new ProductionLogDto();
                l.Message = "There is no Company under this Name !";
                list.Add(l);
                return list;
            }

           


            Brunch b = null;
            var brunches = await _context.Brunches.Where(b => b.CompanyId == comp.Id).ToListAsync();
            bool ok1 = false;
            bool ok2 = false;
            for (int i = 0; i < brunches.Count; i++)
            {
                if (brunches[i].BrunchName == model.BrunchName)
                {
                    ok1 = true;
                }
                if (brunches[i].IsItMainBrunch == true)
                {
                    ok2 = true;
                }
                if (brunches[i].BrunchName == model.BrunchName && brunches[i].IsItMainBrunch == true) b = brunches[i];
            }
            if (!ok2)
            {
                var l = new ProductionLogDto();
                l.Message = "There is no main brunch in this company!"; 
                list.Add(l);
                return list;
               
            }
            if (!ok1)
            {
                var l = new ProductionLogDto();
                l.Message = "There is no brunch under this name in this company !";
                list.Add(l);
                return list;

            }
            var compConstructionYear = new DateTime(comp.ConstructionYear,1,1,0,0,0);
            if (model.StartDate < compConstructionYear)
            {
                var l = new ProductionLogDto();
                l.Message = "There is no logs befor the company construction!";
                list.Add(l);
                return list;
            }

            if (model.EndDate > DateTime.Now)
            {
                var l = new ProductionLogDto();
                l.Message = "There is no logs in the future!";
                list.Add(l);
                return list;
            }


            var allProductionLogs = await _context.ProductionLogs.Where(p => p.BrunchId == b.Id).ToListAsync();
            for(int i = 0;i<allProductionLogs.Count;i++)
            {
                if (allProductionLogs[i].DateOfCreate <= model.EndDate && allProductionLogs[i].DateOfCreate >= model.StartDate) 
                {
                    var l = new ProductionLogDto
                    {
                        Id = allProductionLogs[i].Id,
                        Amount = allProductionLogs[i].Amount,
                        Date = allProductionLogs[i].DateOfCreate
                    };
                    list.Add(l);
                }
            }

            return list;
        }
    }
}
