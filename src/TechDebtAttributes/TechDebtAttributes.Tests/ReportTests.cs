using System.Reflection;
using ApprovalTests;
using ApprovalTests.Reporters;
using ExampleUsage;
using Xunit;

namespace TechDebtAttributes.Tests
{
    public class ReportTests
    {
        [Fact]
        [UseReporter(typeof(DiffReporter))]
        public void ShouldRenderReport()
        {
            var assemblyToReportOn = Assembly.GetAssembly(typeof(SomeThing));

            Approvals.Verify(TechDebtReporter.GenerateReport(assemblyToReportOn));
        }
    }
}
