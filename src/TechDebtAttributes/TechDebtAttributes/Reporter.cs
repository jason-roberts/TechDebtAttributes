using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TechDebtAttributes
{
    public static class TechDebtReporter
    {
        public static string GenerateReport(Assembly assembly)
        {
            var typesWithTechDebt = FindTypesWithTechDebtFor(assembly);

            var reportLines = GenerateReportLines(typesWithTechDebt);

            var sb = new StringBuilder();

            sb.AppendLine("Start of Tech Debt Report - finding all [TechDebt] attribute usages");

            foreach (var item in reportLines.OrderByDescending(x => x.Attribute.RelativeBenefitToFix))
            {
                sb.AppendLine(item.ToString());
            }

            sb.AppendLine("End of Tech Debt Report.");

            return sb.ToString();
        }

        private static List<ReportLine> GenerateReportLines(IEnumerable<MemberInfo> typesWithTechDebt)
        {
            var reportItems = new List<ReportLine>();

            foreach (var type in typesWithTechDebt)
            {
                var techDebtAttribute =
                    (TechDebtAttribute) type.GetCustomAttributes(typeof (TechDebtAttribute), inherit: false)[0];

                reportItems.Add(new ReportLine
                                {
                                    Attribute = techDebtAttribute,
                                    TypeOrMemberName = type.ToString()
                                });
            }
            return reportItems;
        }

        private static IEnumerable<MemberInfo> FindTypesWithTechDebtFor(Assembly assembly)
        {
            return assembly.GetTypes()
                .SelectMany(type => type.GetMembers())
                .Union(assembly.GetTypes())
                .Where(type => Attribute.IsDefined(type, typeof (TechDebtAttribute)));
        }

        private class ReportLine
        {
            public string TypeOrMemberName { get; set; }
            public TechDebtAttribute Attribute {get; set; }

            public override string ToString()
            {
                return string.Format("Benefit to fix: {0:0.#} {1} {2} Pain:{3} Effort to fix:{4}",
                    Attribute.RelativeBenefitToFix, Attribute.description, TypeOrMemberName, Attribute.Pain,
                    Attribute.EffortToFix);
            }
        }

        public static void AssertMaxPainNotExceeded(Assembly assemblyToReportOn, int maxAllowableMain)
        {
            var typesWithDebt = FindTypesWithTechDebtFor(assemblyToReportOn);

            var totalPain = (from t in typesWithDebt
                             let techDebtAttribute = (TechDebtAttribute) t.GetCustomAttributes(typeof(TechDebtAttribute), inherit: false)[0]
                            select techDebtAttribute).Sum(x => x.Pain);

            if (totalPain > maxAllowableMain)
            {
                throw new TechDebtPainExceededException();
            }
        }
    }
}
