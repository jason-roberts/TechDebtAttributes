using TechDebtAttributes;

namespace ExampleUsage
{
    public interface ISomeExampleInterface
    {        
        void X();
        [TechDebt(10, 100, Description = "This should be moved to it's own interface")]
        void Y();
        void Z();
    }
}