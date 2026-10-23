using FluentAssertions;
using Moq;
using ProTeamManagerApi.Core.Models;
using ProTeamManagerApi.Core.Repositories;
using ProTeamManagerApi.Core.Services;
using Xunit;

namespace ProTeamManagerApi.Tests.Services;

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
        var teamName = "Karmine Corp";
        var game = "League of Legends";

        _teamRepositoryMock
            .Setup(r => r.AddAsync(It.IsAny<Team>()))
            .ReturnsAsync((Team t) => { t.Id = 1; return t; });

        var result = await _teamService.CreateTeamAsync(teamName, game);

        result.Should().NotBeNull();
        result.Id.Should().Be(1);
        result.Name.Should().Be(teamName);
        result.Game.Should().Be(game);

        _teamRepositoryMock.Verify(r => r.AddAsync(It.IsAny<Team>()), Times.Once);
    }

    [Fact]
    public async Task GetTeamDetailsAsync_Should_ReturnTeam_WhenTeamExists()
    {
        var team = new Team
        {
            Id = 1,
            Name = "Karmine Corp",
            Game = "League of Legends"
        };

        _teamRepositoryMock
            .Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync(team);

        var result = await _teamService.GetTeamDetailsAsync(1);

        result.Should().NotBeNull();
        result!.Id.Should().Be(1);
        result.Name.Should().Be("Karmine Corp");
        result.Game.Should().Be("League of Legends");

        _teamRepositoryMock.Verify(
            r => r.GetByIdAsync(1),
            Times.Once);
    }


    [Fact]
    public async Task GetTeamDetailsAsync_Should_ReturnNull_WhenTeamDoesNotExist()
    {
        _teamRepositoryMock
            .Setup(r => r.GetByIdAsync(999))
            .ReturnsAsync((Team?)null);

        var result = await _teamService.GetTeamDetailsAsync(999);

        result.Should().BeNull();

        _teamRepositoryMock.Verify(
            r => r.GetByIdAsync(999),
            Times.Once);
    }
}
