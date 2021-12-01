using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;

namespace HHGlobal.PrintCalculator.API.Responses;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public class CalculateJobResponse
{
    public CalculateJobResponse(IEnumerable<JobItemResponse> items, decimal total)
    {
        Items = items;
        Total = total;
    }
    [Required]
    public IEnumerable<JobItemResponse> Items { get; }
    public decimal Total { get; }
}