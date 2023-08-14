using TechDebtAttributes;

namespace ExampleUsage;

[TechDebt(2,6, Description = "This really is silly")]
public enum SillyEnum
{
    Alpha,
    Beta,
    [TechDebt(47,23)]
    Tomato,
}