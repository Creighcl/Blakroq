using Blakroq.Tests;
using Xunit;

namespace TicTacToe.AI;

public class MinimaxTreeTests
{
    [UnitTest]
    public void ItShouldTakeObviousMove()
    {
        MinimaxTree mmt = new("XOX-X-OO-");
        int position = mmt.Solve(Difficulty.HARD, 4);
        Assert.Equal(8, position);
    }

    [UnitTest]
    public void ItShouldStopWin()
    {
        MinimaxTree mmt = new("X--OO-X--");
        int position = mmt.Solve(Difficulty.HARD, 4);
        Assert.Equal(5, position);
    }
}
