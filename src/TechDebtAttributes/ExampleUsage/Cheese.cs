using TechDebtAttributes;

namespace ExampleUsage
{
    [TechDebt(3,6, description = "What kind of cheese is this?")]
    internal class Cheese
    {
        [TechDebt(3, 8, description = "What exactly is inner cheese")]
        internal class InnerCheese
        {
            
        }
    }
}
