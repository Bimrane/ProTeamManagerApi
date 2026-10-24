using FluentAssertions;
using Moq;
using ProTeamManagerApi.Core.Models;
using ProTeamManagerApi.Core.Repositories;
using ProTeamManagerApi.Core.Services;
using Xunit;

namespace ProTeamManagerApi.Tests.Services;

public class PlayerServiceTests
{
    private readonly Mock<IPlayerRepository> _playerRepoMock;
    private readonly Mock<ITeamRepository> _teamRepoMock;
    private readonly PlayerService _playerService;

    public PlayerServiceTests()
    {
        _playerRepoMock = new Mock<IPlayerRepository>();
        _teamRepoMock = new Mock<ITeamRepository>();
        _playerService = new PlayerService(_playerRepoMock.Object, _teamRepoMock.Object);
    }

    [Fact]
    public async Task CreatePlayerAsync_Should_ThrowKeyNotFoundException_WhenTeamDoesNotExist()
    {
        // Arrange
        int invalidTeamId = 99;
        _teamRepoMock.Setup(r => r.GetByIdAsync(invalidTeamId)).ReturnsAsync((Team?)null);

        // Act
        Func<Task> act = async () => await _playerService.CreatePlayerAsync("Canna", "Toplaner", invalidTeamId);

        // Assert
        await act.Should().ThrowAsync<KeyNotFoundException>()
            .WithMessage($"L'équipe avec l'ID {invalidTeamId} est introuvable.");
    }
}