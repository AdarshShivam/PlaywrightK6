using System.Text.RegularExpressions;
using E2ETests.Pages;
using Microsoft.Playwright.NUnit;
namespace E2ETests;
[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class QuickPizzaTests : PageTest
{
[Test]
public async Task HomePage_Loads()
{
var home = new HomePage(Page);
await home.OpenAsync();
await Expect(Page).ToHaveTitleAsync(new Regex("pizza",
RegexOptions.IgnoreCase));
}
[Test]
public async Task RequestPizza_ShowsRecommendation()
{
var home = new HomePage(Page);
await home.OpenAsync();
await home.RequestPizzaAsync();
await Expect(home.Recommendation).ToBeVisibleAsync();
}
}

// This code defines a C# test class called `QuickPizzaTests` that uses NUnit for testing and Playwright for browser automation. The class contains two test methods that verify the behavior of a web application called "QuickPizza".