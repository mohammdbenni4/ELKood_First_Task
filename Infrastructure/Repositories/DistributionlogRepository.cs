using Application.Features.DistributionLog.Commands.CreateDistributionLog;
using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class DistributionLogRepository : IDistributionLogRepository
    {
        private readonly ApplicationDbContext _context;
        public DistributionLogRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DistributionLogViewModel> CreateDistributionLog(DistributionLogViewModel model)
        {
            if(model.CompanyName==""||model.MainBrunchName==""||model.SecondaryBrunchName=="")
            {
                model.Message = "All Fields Are requierd";
                return model;
            }

            var comp = await _context.Companies.SingleOrDefaultAsync(c=>c.CompanyName==model.CompanyName);
            if (comp == null) { model.Message = "There Is no Company in this Name !"; return model; }

            var brunches = await _context.Brunches.Where(b => b.CompanyId == comp.Id).ToListAsync();

            bool ok1 = false;
            bool ok2 = false;
            bool ok3 = false;
            bool ok4 = false;

            Brunch mainBr = null;
            Brunch secondaryBr = null;
            for (int i = 0; i < brunches.Count; i++)
            {
                if (brunches[i].BrunchName == model.MainBrunchName)
                {
                    ok1 = true;
                }
                if (brunches[i].BrunchName == model.SecondaryBrunchName)
                {
                    ok3 = true;
                }
                if (brunches[i].IsItMainBrunch == true)
                {
                    ok2 = true;
                }
                if (brunches[i].IsItMainBrunch == false)
                {
                    ok4 = true;
                }
                if (brunches[i].BrunchName == model.MainBrunchName && brunches[i].IsItMainBrunch == true) mainBr = brunches[i];
                if (brunches[i].BrunchName == model.SecondaryBrunchName && brunches[i].IsItMainBrunch == false) secondaryBr = brunches[i];
            }
            if (!ok2) { model.Message = "There is no main brunch in this company !"; return model; }
            if (!ok1) { model.Message = "There is no main brunch under this name in this company !"; return model; }
            if (!ok4) { model.Message = "There is no secondary brunch in this company !"; return model; }
            if (!ok3) { model.Message = "There is no secondary brunch under this name in this company !"; return model; }


            var transactions = await _context.Transactions.Where(x => x.Date <= model.Date && x.BrunchId == mainBr.Id&&x.DistributionLogId==null).ToListAsync();
            var LastTranFromBrunch = new Transaction();

            if (transactions.Any())
            {
                LastTranFromBrunch = transactions.
                   OrderBy(x => Math.Abs((model.Date - x.Date).TotalMilliseconds))
                   .First();
            }
            int curAmount = 0;
            if (transactions.Any()) curAmount = LastTranFromBrunch.NewAmountInThisBrunch;



            var transaction = new Transaction
            {
                Id = Guid.NewGuid().ToString(),
                Date = model.Date,
                TransAmount = model.Amount,
                NewAmountInThisBrunch =  model.Amount,
                Brunch = mainBr,
                BrunchId = mainBr.Id,
                DistributionLogId = model.Id
            };

            int da = comp.ConstructionYear;
            DateTime compConstructionDate = new DateTime(da, 1, 1, 0, 0, 0);
            if (model.Date < compConstructionDate)
            {
                model.Message = "sorry to interrupt you but, IN THIS DATE THIS COMPANY WAS'NT EXSIST !";
                return model;
            }

            if (model.Amount > curAmount)
            {
                model.Message = "SORRY! There Is't Enough products in THIS MAIN BRUNCH at TIHS DATE :( , You Can Try Another Main Brunch";
                return model;
            }

            if(model.Amount <= 0 )
            {
                model.Message = "You CAN'T send an Amount less Than or equal to zero !! , WE ARE NOT PLAYING HERE :)";
                return model;
            }

          

            if (model.Date > DateTime.Now)
            {
                model.Message = "You can't distribute products in the future !";
                return model;
            }
            var disLog = new DistributionLog
            {
                Id = model.Id,
                MainBrunchId = mainBr.Id,
                SecondaryBrunchId = secondaryBr.Id,
                Amount = model.Amount,
                Date = model.Date
            };

          
            var transactionsAfter = await _context.Transactions.Where(x => x.Date > model.Date && x.BrunchId == mainBr.Id).ToListAsync();
           
            if (transactions.Any())
            {
                for (int i = 0;i<transactionsAfter.Count;i++)
                    transactionsAfter[i].NewAmountInThisBrunch -= model.Amount;
            }
           

            await _context.DistributionLogs.AddAsync(disLog);
            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
            var dislog = await _context.DistributionLogs.SingleOrDefaultAsync(x=>x.Id==model.Id);
            transaction.DistributionLog = dislog;

            transactions.
                   OrderBy(x => Math.Abs((model.Date - x.Date).TotalMilliseconds));

            int cur = 0,j=transactions.Count-1;
            while (cur < model.Amount && j >=0) 
            {
                if (cur + transactions[j].TransAmount <= model.Amount)
                {
                    cur += transactions[j].TransAmount;
                    transactions[j].TransAmount = 0;
                }
                else
                {
                    transactions[j].TransAmount -= (model.Amount - cur);
                    cur = model.Amount;
                    
                }
                j--;
            }

            cur = 0;
            for (int i = 0;i<transactions.Count;i++)
            {
                cur += transactions[i].TransAmount;
                transactions[i].NewAmountInThisBrunch = cur;
            }


            await _context.SaveChangesAsync();
            return model;
        }
    }
}
