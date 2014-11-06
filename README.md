# Track technical debt at the source code level

## Step 1: Capture

Add attributes to your production code where you find technical debt that you can not currently fix:

Install NuGet Package: TechDebtAttributes into your production assembly(s)


Use [TechDebt] attributes to when you find technical debt that you can't fix right away:

```
[TechDebt(10, 44, description = "This is dumb, we should remove it")]
public interface ISomeDumbInterface
{     
}
```

In the example above, this debt has a pain value of 10 and an effort to fix of 44.

You decide what the relative values mean for these ints.

## Step 2 Report

Install NuGet Package: TechDebtAttributes into your test project

Add a test in your test project to output a report of all tech debt:

```
public class WhatsTheTechDebt
{
	[Fact]
	public void ReportOnTechDebtButNeverFailATest()
	{
		var assemblyContainingTechDebt = Assembly.GetAssembly(typeof (SomeThing));

		var report = TechDebtReporter.GenerateReport(assemblyContainingTechDebt);

		Console.WriteLine(report);
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

## Step 3: Fail tests if too much tech debt exists (optional)

```
// This test will fail because there is more than total of 10 pain in all tech debt
[Fact]
public void ReportOnTechDebtAndFailTestIfTotalPainExceeded()
{
	var assemblyContainingTechDebt = Assembly.GetAssembly(typeof(SomeThing));

	const int maximumPainInCodebaseThatWereWillingToLiveWith = 10;

	TechDebtReporter.AssertMaxPainNotExceeded(assemblyContainingTechDebt, maximumPainInCodebaseThatWereWillingToLiveWith);            
}
```

## More examples:

https://github.com/jason-roberts/TechDebtAttributes/blob/master/src/TechDebtAttributes/ExampleUsage.Tests/UsingTechDebtAttributesInTests.cs

https://github.com/jason-roberts/TechDebtAttributes/blob/master/src/TechDebtAttributes/TechDebtAttributes.Tests/TechDebtReporterTests.cs


--------

## About Jason Roberts

Jason Roberts is a Microsoft MVP, [Pluralsight course author](http://bit.ly/psjasonroberts) and Journeyman Software Developer with over 12 years experience.

He is the author of the books [Keeping Software Soft](http://keepingsoftwaresoft.com)) and [C# Tips](http://bit.ly/sharpbook) and writes at his blog [DontCodeTired.com](http://dontcodetired.com).