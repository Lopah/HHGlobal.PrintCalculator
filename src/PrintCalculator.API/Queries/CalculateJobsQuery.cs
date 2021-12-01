using HHGlobal.PrintCalculator.API.Requests;
using HHGlobal.PrintCalculator.API.Responses;
using JetBrains.Annotations;
using MediatR;

namespace HHGlobal.PrintCalculator.API.Queries;

[UsedImplicitly]
public class CalculateJobsQuery : IRequest<CalculateJobResponse>
{
    public CalculateJobRequest Model { get; }

    public CalculateJobsQuery(CalculateJobRequest model)
    {
        Model = model;
    }
}