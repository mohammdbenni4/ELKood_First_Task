using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brunches.Commands.CreateNewBrunch
{
    public class BrunchViewModel
    {
        public string Id { get; set; }
        public string BrunchName { get; set; }
        public string BrunchLocation { get; set; }
        public string? Message { get; set; }
        public string CompanyName { get; set; }
        public bool IsItMainBrunch { get; set; }
        

    }
}
