using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;

namespace HHGlobal.PrintCalculator.API.Requests;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public class JobItemRequest
{
    public string Name { get; init; }

    /// <summary>
    /// In USD
    /// </summary>
    public decimal Price { get; init; }

    /// <summary>
    /// Whether the item is exempt from taxes
    /// </summary>
    public string? SalesTax { get; init; }
}