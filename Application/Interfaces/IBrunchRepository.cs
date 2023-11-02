using Application.Features.Brunches.Commands.CreateNewBrunch;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IBrunchRepository
    {
        Task<BrunchViewModel> CreateBrunch(BrunchViewModel model);  
    }
}
