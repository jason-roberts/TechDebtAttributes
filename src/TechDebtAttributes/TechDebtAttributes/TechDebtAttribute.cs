using System;

namespace TechDebtAttributes
{
    [AttributeUsage(
        AttributeTargets.Class | AttributeTargets.Constructor | AttributeTargets.Delegate | AttributeTargets.Enum |
        AttributeTargets.Event | AttributeTargets.Field | AttributeTargets.GenericParameter | AttributeTargets.Interface |
        AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Struct,
        AllowMultiple = false)]
    public class TechDebtAttribute : Attribute
    {
        private readonly int _effortToFix;
        private readonly int _pain;

        public TechDebtAttribute(int pain, int effortToFix)
        {
            _pain = pain;
            _effortToFix = effortToFix;
        }

        public double RelativeBenefitToFix
        {
            get { return (double) Pain / EffortToFix; }
        }

        // ReSharper disable InconsistentNaming
        public string description = "";
        // ReSharper restore InconsistentNaming

        public int Pain
        {
            get { return _pain; }
        }

        public int EffortToFix
        {
            get { return _effortToFix; }
        }
    }
}