using Blakroq.Tests;
using Xunit;

namespace TicTacToe.General;

public class PlayerTests
{
    [UnitTest]
    public void ItShouldPlay()
    {
        Player player = new('X');
        player.Play(0);

        Assert.True(player.State[0]);
    }

    [UnitTest]
    public void ItShouldHaveAValidStateValue()
    {
        Player player = new('X');
        player.Play(0);
        player.Play(1);
    }

    [UnitTest]
    public void ItShouldDetermineIfWinningState_RowTop()
    {
        Player player = new('X');
        player.Play(0, 1, 2);
        Assert.True(player.IsWinningState());
    }

    [UnitTest]
    public void ItShouldDetermineIfWinningState_RowMiddle()
    {
        Player player = new('X');
        player.Play(3, 4, 5);
        Assert.True(player.IsWinningState());
    }

    [UnitTest]
    public void ItShouldDetermineIfWinningState_RowBottom()
    {
        Player player = new('X');
        player.Play(6, 7, 8);
        Assert.True(player.IsWinningState());
    }

    [UnitTest]
    public void ItShouldDetermineIfWinningState_ColumnLeft()
    {
        Player player = new('X');
        player.Play(0, 3, 6);
        Assert.True(player.IsWinningState());
    }

    [UnitTest]
    public void ItShouldDetermineIfWinningState_ColumnMiddle()
    {
        Player player = new('X');
        player.Play(1, 4, 7);
        Assert.True(player.IsWinningState());
    }

    [UnitTest]
    public void ItShouldDetermineIfWinningState_ColumnRight()
    {
        Player player = new('X');
        player.Play(2, 5, 8);
        Assert.True(player.IsWinningState());
    }

    [UnitTest]
    public void ItShouldDetermineIfWinningState_CrossTopLeft()
    {
        Player player = new('X');
        player.Play(0, 4, 8);
        Assert.True(player.IsWinningState());
    }

    [UnitTest]
    public void ItShouldDetermineIfWinningState_CrossBottomLeft()
    {
        Player player = new('X');
        player.Play(6, 4, 2);
        Assert.True(player.IsWinningState());
    }

    [UnitTest]
    public void ItShouldDetermineIfWinningState_False()
    {
        Player player = new('X');
        player.Play(0);
        Assert.False(player.IsWinningState());
    }
}
