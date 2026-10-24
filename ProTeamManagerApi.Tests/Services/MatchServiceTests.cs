using FluentAssertions;
using Moq;
using ProTeamManagerApi.Core.Models;
using ProTeamManagerApi.Core.Repositories;
using ProTeamManagerApi.Core.Services;
using Xunit;

namespace ProTeamManagerApi.Tests.Services;

public class MatchServiceTests
{
    [Theory]
    [InlineData(3, 1, true)]
    [InlineData(1, 3, false)]
    public void Match_IsWon_Should_CalculateCorrectly(int teamScore, int opponentScore, bool expectedIsWon)
    {
        var match = new ProTeamManagerApi.Core.Models.Match
        {
            TeamScore = teamScore,
            OpponentScore = opponentScore
        };

        match.IsWon.Should().Be(expectedIsWon);
    }
}