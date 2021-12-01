using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;

namespace HHGlobal.PrintCalculator.API.Requests;

/// <summary>
/// Represents individual jobs passed to API 
/// </summary>
[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public class CalculateJobRequest
{
    /// <summary>
    /// Whether to apply extra margin to a job
    /// </summary>
    public string? ExtraMargin { get; init; }

    [Required]
    public ICollection<JobItemRequest>? JobItems { get; init; }
}