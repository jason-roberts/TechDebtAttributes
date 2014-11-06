using System;
using System.Reflection;
using TechDebtAttributes;
using Xunit;

namespace ExampleUsage.Tests
{
    public class WhatsTheTechDebt
    {
        [Fact]
        public void CalcTechDebt()
        {
            var assemblyContainingTechDebt = Assembly.GetAssembly(typeof (SomeThing));

            var report = TechDebtReporter.GenerateReport(assemblyContainingTechDebt);

            Console.WriteLine(report);
        }
    }
}
