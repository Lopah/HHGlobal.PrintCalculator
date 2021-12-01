using System;
using System.Collections.Generic;
using FluentAssertions;
using HHGlobal.PrintCalculator.Core.Entities;
using Xunit;

namespace HHGlobal.PrintCalculator.Core.Unit.PrintJobs;

/// <summary>
/// Treating this test case as User-Acceptance-Tests
/// </summary>
public class JobCalculationTests
{
    [Fact]
    public void JobCalculation_WhenGivenEmptyListOfEmptyJobs_ThrowsArgumentNullException()
    {
        var nullJobs = Array.Empty<Job>();

        var createCalculationWithNoJobs = () => new JobCalculation(nullJobs);
        createCalculationWithNoJobs.Should().ThrowExactly<ArgumentNullException>();
    }

    [Fact]
    [Trait("Reference Data ", "Job 0")]
    public void Job_WithoutAnythingExtra_ShouldCalculateItCorrectly()
    {
        var item1 = new Job("item", 100m);
        var jobs = new List<Job> { item1 };
        var calculation = new JobCalculation(jobs);

        item1.TotalPrice.Should().Be(107m);
        calculation.TotalPrice.Should().Be(118m);
    }
    
    [Fact]
    [Trait("Reference Data", "Job 1")]
    public void Job_GivenExtraMargin_ShouldCalculateItCorrectly()
    {
        var item1 = new Job("envelopes", 520m);
        var item2 = new Job("letterhead", 1983.37m, true);
        var jobs = new List<Job> { item1, item2 };
        var calculation = new JobCalculation(jobs, true);
        
        item1.TotalPrice.Should().Be(556.40m);
        item2.TotalPrice.Should().Be(1983.37m);
        calculation.TotalPrice.Should().Be(2940.30m);
    }

    [Fact]
    [Trait("Reference Data", "Job 2")]
    public void Job_GivenOneItemWithoutAnythingSpecial_ShouldCalculateItCorrectly()
    {
        var item1 = new Job("t-shirts", 294.04m);
        var jobs = new List<Job> { item1 };
        var calculation = new JobCalculation(jobs);
        
        item1.TotalPrice.Should().Be(314.62m);
        calculation.TotalPrice.Should().Be(346.96m);
    }

    [Fact]
    [Trait("Reference Data", "Job 3")]
    public void Job_Given2ItemsWithExemptionsAndMargin_ShouldCalculateItCorrectly()
    {
        
        var item1 = new Job("frisbees", 19385.38m, true);
        var item2 = new Job("yo-yos", 1829m, true);
        var jobs = new List<Job> { item1, item2 };
        var calculation = new JobCalculation(jobs, true);
        
        item1.TotalPrice.Should().Be(19385.38m);
        item2.TotalPrice.Should().Be(1829m);
        calculation.TotalPrice.Should().Be(24608.68m);
    }
}