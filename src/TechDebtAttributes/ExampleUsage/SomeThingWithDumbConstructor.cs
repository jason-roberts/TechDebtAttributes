using TechDebtAttributes;

namespace ExampleUsage
{
    public class SomeThingWithDumbConstructor
    {
        [TechDebt(5000, 3)]
        public SomeThingWithDumbConstructor()
        {
            
        }
    }
}