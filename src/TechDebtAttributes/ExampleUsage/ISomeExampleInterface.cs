using TechDebtAttributes;

namespace ExampleUsage
{
    public interface ISomeExampleInterface
    {        
        void X();
        [TechDebt(10, 100, description = "This should be moved to it's own interface")]
        void Y();
        void Z();
    }
}