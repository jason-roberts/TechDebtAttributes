using TechDebtAttributes;

namespace ExampleUsage;

[TechDebt(1, 200, Description = "There's a lot of work to fix this whole class for not much gain")]
public class SomeThing
{
    [TechDebt(5,1, Description = "Quick fix to stop stupid stuff happening sometimes")]
    public void SomeMethod()
    {
    }
}