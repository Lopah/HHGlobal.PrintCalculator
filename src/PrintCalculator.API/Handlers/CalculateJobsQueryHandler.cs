using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HHGlobal.PrintCalculator.API.Queries;
using HHGlobal.PrintCalculator.API.Responses;
using HHGlobal.PrintCalculator.Core.Entities;
using JetBrains.Annotations;
using MediatR;

namespace HHGlobal.PrintCalculator.API.Handlers;

[UsedImplicitly]
public class CalculateJobsQueryHandler : IRequestHandler<CalculateJobsQuery, CalculateJobResponse>
{
    /// <summary>Handles a request</summary>
    /// <param name="request">The request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Response from the request</returns>
    public Task<CalculateJobResponse> Handle(CalculateJobsQuery request, CancellationToken cancellationToken)
    {
        var dto = request.Model;

        if (dto.JobItems is null || !dto.JobItems.Any())
        {
            throw new ArgumentNullException(nameof(dto.JobItems), "Cannot calculate not existing job items.");
        }

        var jobs = new List<Job>();
        var isMarginApplied = dto.ExtraMargin is not null && dto.ExtraMargin == "extra-margin";

        foreach (var jobItem in dto.JobItems)
        {
            var isExempt = jobItem.SalesTax is not null && jobItem.SalesTax == "exempt";
            jobs.Add(new(jobItem.Name, jobItem.Price, isExempt));
        }

        var calculation = new JobCalculation(jobs, isMarginApplied);

        // Can be handled by a dedicated mapper, doing it here for now.

        var mappedJobs = calculation.Jobs.Select(x => new JobItemResponse
        {
            Name = x.Name,
            Price = x.TotalPrice
        });
        return Task.FromResult(new CalculateJobResponse(mappedJobs, calculation.TotalPrice));
    }
}