using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using ProTeamManagerApi.Core.DTOs;
using Xunit;

namespace ProTeamManagerApi.Tests.Integration;

public class PlayersIntegrationTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;

    public PlayersIntegrationTests(CustomWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task PostPlayer_ShouldReturnBadRequest_WhenNicknameIsEmpty()
    {
        var invalidPlayer = new CreatePlayerDto("", "Toplaner", 1);

        var response = await _client.PostAsJsonAsync("/api/players", invalidPlayer);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task PostPlayer_ShouldReturnNotFound_WhenTeamDoesNotExist()
    {
        var playerWithFakeTeam = new CreatePlayerDto("Faker", "Midlaner", 999);

        var response = await _client.PostAsJsonAsync("/api/players", playerWithFakeTeam);

        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
}