using System.Net;

using AzureOpenAIProxy.AppHost.Tests.Fixtures;

using FluentAssertions;

namespace AzureOpenAIProxy.AppHost.Tests.PlaygroundApp.Pages;
public class AdminPageTests(AspireAppHostFixture host) : IClassFixture<AspireAppHostFixture>
{
    [Fact]
    public async Task Given_Resource_When_Invoked_Endpoint_Then_It_Should_Return_OK()
    {
        // Arrange
        using var httpClient = host.App!.CreateHttpClient("playgroundapp");

        // Act
        var response = await httpClient.GetAsync("/admin");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Theory]
    [InlineData("_content/Microsoft.FluentUI.AspNetCore.Components/Microsoft.FluentUI.AspNetCore.Components.lib.module.js")]
    public async Task Given_Resource_When_Invoked_Endpoint_Then_It_Should_Return_JavaScript_Elements(string expected)
    {
        // Arrange
        using var httpClient = host.App!.CreateHttpClient("playgroundapp");

        // Act
        var html = await httpClient.GetStringAsync("/admin");

        // Assert
        html.Should().Contain(expected);
    }

    [Theory]
    [InlineData("<div class=\"fluent-tooltip-provider\"></div>")]
    public async Task Given_Resource_When_Invoked_Endpoint_Then_It_Should_Return_HTML_Elements(string expected)
    {
        // Arrange
        using var httpClient = host.App!.CreateHttpClient("playgroundapp");

        // Act
        var html = await httpClient.GetStringAsync("/admin");

        // Assert
        html.Should().Contain(expected);
    }
}