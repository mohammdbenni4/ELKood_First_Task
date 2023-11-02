using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brunches.Commands.CreateNewBrunch
{
    public class CreateBrunchCommand : IRequest<BrunchViewModel>
    {
        public string CompanyName { get; set; }
        public string BrunchName { get; set; }
        public string BrunchLocation { get; set; }

        public bool IsItMainBrunch { get; set; }
    }
}
