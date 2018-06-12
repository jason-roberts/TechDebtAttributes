using TechDebtAttributes;

namespace ExampleUsage
{
    [TechDebt(3,6, Description = "What kind of cheese is this?")]
    internal class Cheese
    {
        [TechDebt(3, 8, Description = "What exactly is inner cheese")]
        internal class InnerCheese
        {
            
        }
    }
}
