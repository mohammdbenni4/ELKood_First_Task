using Application.Interfaces;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brunches.Commands.CreateNewBrunch
{
    public class CreateBrunchCommandHandler : IRequestHandler<CreateBrunchCommand, BrunchViewModel>
    {

        private readonly IBrunchRepository _brunchRepository;
        public CreateBrunchCommandHandler(IBrunchRepository brunchRepository)
        {
            _brunchRepository = brunchRepository;
        }


        public async Task<BrunchViewModel> Handle(CreateBrunchCommand request, CancellationToken cancellationToken)
        {
            
            var newBrunch = new BrunchViewModel
            {
                Id = Guid.NewGuid().ToString(),
                BrunchLocation = request.BrunchLocation,
                BrunchName = request.BrunchName,
                IsItMainBrunch = request.IsItMainBrunch,
                CompanyName = request.CompanyName,
                
            };

            var result = await _brunchRepository.CreateBrunch(newBrunch);


            return result;
        }
    }
}
