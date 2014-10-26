Add attributes to your production code where you find technical debt that you can not currently fix:

```
[TechDebt(10, 44, description = "This is dumb, we should remove it")]
public interface ISomeDumbInterface
{     
	}
```

Add a test in your test project:

```
public class WhatsTheTechDebt
{
	[Fact]
	public void CalcTechDebt()
	{
		var assemblyToReportOn = Assembly.GetAssembly(typeof (SomeThing));

		Console.WriteLine(assemblyToReportOn.CalculateTechDebtFor());
	}
}	
```	
	
Run the test and get the report:	

```	
Start of Tech Debt Report - finding all [TechDebt] attribute usages
Benefit to fix: 1666.7  Void .ctor() Pain:5000 Effort to fix:3
Benefit to fix: 5 Quick fix to stop stupid stuff happening sometimes Void SomeMethod() Pain:5 Effort to fix:1
Benefit to fix: 2  ExampleUsage.SillyEnum Tomato Pain:47 Effort to fix:23
Benefit to fix: 0.3 This really is silly ExampleUsage.SillyEnum Pain:2 Effort to fix:6
Benefit to fix: 0.2 This is dumb, we should remove it ExampleUsage.ISomeDumbInterface Pain:10 Effort to fix:44
Benefit to fix: 0.1 This should be moved to it's own interface Void Y() Pain:10 Effort to fix:100
Benefit to fix: 0 There's a lot of work to fix this whole class for not much gain ExampleUsage.SomeThing Pain:1 Effort to fix:200
End of Tech Debt Report.
```
