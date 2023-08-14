using System.Reflection;
using TechDebtAttributes;
using Xunit;
using Xunit.Abstractions;

namespace ExampleUsage.Tests;

public class UsingTechDebtAttributesInTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public UsingTechDebtAttributesInTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void ReportOnTechDebtButNeverFailATest()
    {
        var assemblyContainingTechDebt = Assembly.GetAssembly(typeof (SomeThing));

        var report = TechDebtReporter.GenerateReport(assemblyContainingTechDebt);

        _testOutputHelper.WriteLine(report);
    }


    [Fact]
    public void ReportOnTechDebtAndThrowIfTotalPainExceeded()
    {
        var assemblyContainingTechDebt = Assembly.GetAssembly(typeof(SomeThing));

        const int maximumPainInCodebaseThatWereWillingToLiveWith = 10;

        Assert.Throws<TechDebtPainExceededException>(() => TechDebtReporter.AssertMaxPainNotExceeded(assemblyContainingTechDebt, maximumPainInCodebaseThatWereWillingToLiveWith));
        // TechDebtReporter.AssertMaxPainNotExceeded(assemblyContainingTechDebt, maximumPainInCodebaseThatWereWillingToLiveWith);
    }
}