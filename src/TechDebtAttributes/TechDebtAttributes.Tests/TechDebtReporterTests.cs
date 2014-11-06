using System.Reflection;
using AnotherExampleUsageAssembly;
using ApprovalTests;
using ApprovalTests.Reporters;
using ExampleUsage;
using Xunit;

namespace TechDebtAttributes.Tests
{
    public class TechDebtReporterTests
    {
        [Fact]
        [UseReporter(typeof(DiffReporter))]
        public void ShouldRenderReport()
        {
            var assemblyToReportOn = Assembly.GetAssembly(typeof(SomeThing));

            Approvals.Verify(TechDebtReporter.GenerateReport(assemblyToReportOn));
        }

        [Fact]
        [UseReporter(typeof(DiffReporter))]
        public void ShouldRenderReportWithMultipleAssemblies()
        {
            var assemblyToReportOn = new[]
                                     {
                                         Assembly.GetAssembly(typeof (SomeThing)),
                                         Assembly.GetAssembly(typeof (Mango))
                                     };

            Approvals.Verify(TechDebtReporter.GenerateReport(assemblyToReportOn));
        }

        [Fact]        
        public void ShouldThrowExceptionWhenPainLimitExceeded()
        {
            var assemblyToReportOn = Assembly.GetAssembly(typeof(SomeThing));

            Assert.Throws<TechDebtPainExceededException>(() => TechDebtReporter.AssertMaxPainNotExceeded(assemblyToReportOn, 1));
        }

        [Fact]
        public void ShouldNotThrowExceptionWhenPainIsAcceptableToTeam()
        {
            var assemblyToReportOn = Assembly.GetAssembly(typeof(SomeThing));

            TechDebtReporter.AssertMaxPainNotExceeded(assemblyToReportOn, int.MaxValue);
        }
    }
}
