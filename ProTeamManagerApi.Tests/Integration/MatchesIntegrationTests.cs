using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using ProTeamManagerApi.Core.DTOs;
using Xunit;

namespace ProTeamManagerApi.Tests.Integration;

public class MatchesIntegrationTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;

    public MatchesIntegrationTests(CustomWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task PostMatch_ShouldReturnBadRequest_WhenScoreIsNegative()
    {
        var invalidMatch = new CreateMatchDto("G2 Esports", "LEC Spring", DateTime.UtcNow, -1, 3, 1);

        var response = await _client.PostAsJsonAsync("/api/matches", invalidMatch);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
}