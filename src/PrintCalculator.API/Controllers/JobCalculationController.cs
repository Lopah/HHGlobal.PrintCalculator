using System.Net;
using System.Threading;
using System.Threading.Tasks;
using HHGlobal.PrintCalculator.API.Queries;
using HHGlobal.PrintCalculator.API.Requests;
using HHGlobal.PrintCalculator.API.Responses;
using HHGlobal.PrintCalculator.API.Responses.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HHGlobal.PrintCalculator.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[ProducesErrorResponseType(typeof(ErrorResponse))]
[ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest, "application/json")]
[ProducesResponseType(typeof(CalculateJobResponse), (int)HttpStatusCode.OK)]
public class JobCalculationController : ControllerBase
{
    private readonly IMediator _mediator;

    public JobCalculationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> GetCalculatedJob([FromBody] CalculateJobRequest request, CancellationToken cancellationToken)
    {
        var query = new CalculateJobsQuery(request);
        var response = await _mediator.Send(query, cancellationToken);
        
        return Ok(response);
    }
}