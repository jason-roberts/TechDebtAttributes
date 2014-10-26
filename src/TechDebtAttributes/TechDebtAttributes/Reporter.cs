using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TechDebtAttributes
{
    public static class AssemblyExtensions
    {
        public static string CalculateTechDebtFor(this Assembly assembly)
        {
            var types = assembly.GetTypes()
                .SelectMany(type => type.GetMembers())
                .Union(assembly.GetTypes())
                .Where(type => Attribute.IsDefined(type, typeof (TechDebtAttribute)));


            var sb = new StringBuilder();

            

            var reportItems = new List<ReportLine>();

            foreach (var type in types)
            {
                var techDebtAttribute = (TechDebtAttribute) type.GetCustomAttributes(typeof (TechDebtAttribute), inherit: false)[0];

                reportItems.Add(new ReportLine
                                {
                                    Attribute = techDebtAttribute,
                                    TypeOrMemberName = type.ToString()
                                });
                
            }


            sb.AppendLine("Start of Tech Debt Report - finding all [TechDebt] attribute usages");

            foreach (var item in reportItems.OrderByDescending(x => x.Attribute.RelativeBenefitToFix))
            {
                sb.AppendLine(item.ToString());
            }

            sb.AppendLine("End of Tech Debt Report.");

            return sb.ToString();
        }

        public class ReportLine
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
    }
}
