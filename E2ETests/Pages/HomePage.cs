using Microsoft.Playwright;
namespace E2ETests.Pages;
public class HomePage(IPage page)
{
private ILocator PizzaButton => page.GetByRole(AriaRole.Button, new() {
Name = "Pizza, Please!" });
public ILocator Recommendation => page.GetByText("Our recommendation");
public Task OpenAsync() =>
page.GotoAsync("https://quickpizza.grafana.com");
public Task RequestPizzaAsync() => PizzaButton.ClickAsync();
}


// This code defines a C# class called `HomePage` that represents a page object model (POM) for a web page in an end-to-end (E2E) testing framework using Playwright. Here's a breakdown of what it does