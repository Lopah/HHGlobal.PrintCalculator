using System;
using System.Collections.Generic;
using System.Linq;

namespace HHGlobal.PrintCalculator.Core.Entities;

public class JobCalculation
{
    private const decimal _marginAmount = 0.11m;
    private readonly bool _hasHasExtraMargin;
    private decimal CalculateMargin() => _hasHasExtraMargin ? _marginAmount + 0.05m : _marginAmount;

    public JobCalculation(ICollection<Job> jobs, bool hasExtraMargin = false)
    {
        if (jobs is null || !jobs.Any())
        {
            throw new ArgumentNullException(nameof(jobs), "Jobs cannot be null.");
        }
        
        Jobs = jobs;


        _hasHasExtraMargin = hasExtraMargin;
    }

    public ICollection<Job> Jobs { get; }

    public decimal TotalPrice => Math.Round(Jobs.Sum(x => x.TotalPrice + x.BasePrice * CalculateMargin()), 2, MidpointRounding.ToZero);
}