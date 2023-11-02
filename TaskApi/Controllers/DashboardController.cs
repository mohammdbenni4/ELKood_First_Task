using Application.Features.Brunches.Commands.CreateNewBrunch;
using Application.Features.Companies.Commands.CreateNewCompany;
using Application.Features.DistributionLog.Commands.CreateDistributionLog;
using Application.Features.ProductionLog.Commands.CreateProductionLog;
using Application.Features.ProductionLog.Queries.GetProductionLogsBetweenTwoDates;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DashboardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateCompany")]
        public async Task<ActionResult> CreateCompany([FromBody]CreateCompanyCommand model)
        {
            var result =await  _mediator.Send(model);
          
            if(result.Message!=""&&result.Message!=null)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }


        [HttpPost("AddBrunch")]
        public async Task<ActionResult> CreateBrunche([FromBody]CreateBrunchCommand model)
        {
            var result = await _mediator.Send(model);
            if (result.Message != "" && result.Message != null)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);

        }
        [HttpPost("AddProductionLog")]
        public async Task<ActionResult> CreateProductionLog([FromBody] CreateProductionLogCommand model)
        {
            var result = await _mediator.Send(model);
            if (result.Message != "" && result.Message != null)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);

        }
        [HttpPost("AddDistributionLog")]
        public async Task<ActionResult> CreateDistributionLog([FromBody] CreateDistributionlogCommand model)
        {
            var result = await _mediator.Send(model);
            if (result.Message != "" && result.Message != null)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);

        }

        [HttpPost("GetProductionLogsBetweenTwoDates")]
        public async Task<ActionResult> GetProductionLogsBetweenTwoDates([FromBody] GetProductionLogsQuery model)
        {
            var result = await _mediator.Send(model);

            if (result[0].Message != "" && result[0].Message != null)
            {
                return BadRequest(result[0].Message);
            }

            return Ok(result);

        }

    }
}
