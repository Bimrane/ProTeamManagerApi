using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using ProTeamManagerApi.Core.DTOs;
using Xunit;

namespace ProTeamManagerApi.Tests.Integration;

public class TeamsIntegrationTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;

    public TeamsIntegrationTests(CustomWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task PostTeam_ShouldReturnCreated_WhenDataIsValid()
    {
        var newTeam = new CreateTeamDto("Karmine Corp", "League of Legends");

        var response = await _client.PostAsJsonAsync("/api/teams", newTeam);

        response.StatusCode.Should().Be(HttpStatusCode.Created);
        
        var createdTeam = await response.Content.ReadFromJsonAsync<TeamResponseDto>();
        createdTeam.Should().NotBeNull();
        createdTeam!.Name.Should().Be("Karmine Corp");
        createdTeam.Game.Should().Be("League of Legends");
    }

    [Fact]
    public async Task PostTeam_ShouldReturnBadRequest_WhenNameIsEmpty()
    {
        var invalidTeam = new CreateTeamDto("", "League of Legends");

        var response = await _client.PostAsJsonAsync("/api/teams", invalidTeam);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    async Task DeleteTeam_ShouldReturnNoContent_AndRemoveTeam()
    {
        var newTeam = new CreateTeamDto("Team to Delete", "Valorant");
        var createResponse = await _client.PostAsJsonAsync("/api/teams", newTeam);
        var createdTeam = await createResponse.Content.ReadFromJsonAsync<TeamResponseDto>();

        var deleteResponse = await _client.DeleteAsync($"/api/teams/{createdTeam!.Id}");

        deleteResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);

        var getResponse = await _client.GetAsync($"/api/teams/{createdTeam.Id}");
        getResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
}