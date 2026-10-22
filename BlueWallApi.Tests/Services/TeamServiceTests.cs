using FluentAssertions;
using Moq;
using BlueWallApi.Core.Models;
using BlueWallApi.Core.Repositories;
using BlueWallApi.Core.Services;
using Xunit;

namespace BlueWallApi.Tests.Services;

public class TeamServiceTests
{
    private readonly Mock<ITeamRepository> _teamRepositoryMock;
    private readonly TeamService _teamService;

    public TeamServiceTests()
    {
        _teamRepositoryMock = new Mock<ITeamRepository>();
        _teamService = new TeamService(_teamRepositoryMock.Object);
    }

    [Fact]
    public async Task CreateTeamAsync_Should_ReturnCreatedTeam_WhenDataIsValid()
    {
        // Arrange
        var teamName = "Karmine Corp";
        var game = "League of Legends";

        _teamRepositoryMock
            .Setup(r => r.AddAsync(It.IsAny<Team>()))
            .ReturnsAsync((Team t) => { t.Id = 1; return t; });

        // Act
        var result = await _teamService.CreateTeamAsync(teamName, game);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(1);
        result.Name.Should().Be(teamName);
        result.Game.Should().Be(game);
        
        _teamRepositoryMock.Verify(r => r.AddAsync(It.IsAny<Team>()), Times.Once);
    }
}