using System;
using System.Reflection;
using TechDebtAttributes;
using Xunit;

namespace ExampleUsage.Tests
{
    public class UsingTechDebtAttributesInTests
    {
        [Fact]
        public void ReportOnTechDebtButNeverFailATest()
        {
            var assemblyContainingTechDebt = Assembly.GetAssembly(typeof (SomeThing));

            var report = TechDebtReporter.GenerateReport(assemblyContainingTechDebt);

            Console.WriteLine(report);
        }


        // This test will fail because there is more than total of 10 pain in tech debt
        [Fact]
        public void ReportOnTechDebtAndFailTestIfTotalPainExceeded()
        {
            var assemblyContainingTechDebt = Assembly.GetAssembly(typeof(SomeThing));

            const int maximumPainInCodebaseThatWereWillingToLiveWith = 10;

            TechDebtReporter.AssertMaxPainNotExceeded(assemblyContainingTechDebt, maximumPainInCodebaseThatWereWillingToLiveWith);            
        }
    }
}
