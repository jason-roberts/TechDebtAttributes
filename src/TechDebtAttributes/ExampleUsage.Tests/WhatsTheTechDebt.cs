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
            var assemblyToReportOn = Assembly.GetAssembly(typeof (SomeThing));

            Console.WriteLine(assemblyToReportOn.CalculateTechDebtFor());
        }
    }
}
