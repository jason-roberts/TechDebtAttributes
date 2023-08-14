using System;

namespace TechDebtAttributes;

[AttributeUsage(AttributeTargets.All)]
public class TechDebtAttribute : Attribute
{
    public TechDebtAttribute(int pain, int effortToFix)
    {
        Pain = pain;
        EffortToFix = effortToFix;
    }

    public double RelativeBenefitToFix => (double)Pain / EffortToFix;

    public int Pain { get; }
    public int EffortToFix { get; }
    public string Description { get; set; }
}