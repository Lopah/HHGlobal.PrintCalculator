using System;

namespace HHGlobal.PrintCalculator.Core.Entities;

public class Job
{
    private readonly bool _taxExempt;

    public Job(string name, decimal price, bool taxExempt = false)
    {
        _taxExempt = taxExempt;
        Name = name;
        BasePrice = price;
    }

    public string Name { get; }
    
    public decimal BasePrice { get; }

    public decimal TotalPrice => Math.Round(CalculatePrice(), 2);

    private decimal CalculatePrice() => BasePrice + BasePrice * CalculateTax();

    private decimal CalculateTax() => _taxExempt ? 0 : 0.07m;

}