using Blakroq.Tests;
using Xunit;

namespace TicTacToe.General;

public class TicTacToeBoardTests
{
    [UnitTest]
    public void ItShouldHaveNineBoardPositions()
    {
        Assert.Equal(9, TicTacToeBoard.BOARD_POSITIONS);
    }

    [UnitTest]
    public void ItShouldStartWithXsTurn()
    {
        TicTacToeBoard board = new();
        Assert.Equal('X', board.GetPlayerTurn().DisplayCharacter);
    }

    [UnitTest]
    public void ItShouldSerializeToString()
    {
        TicTacToeBoard board = new();
        Assert.Equal("---------", board.ToString());
    }

    [UnitTest]
    public void ItShouldValidateTheBoardState_InvalidCharacters()
    {
        Assert.Throws<ArgumentException>(() => new TicTacToeBoard("INVALID CHARACTERS"));
    }

    [UnitTest]
    public void ItShouldValidateTheBoardState_InvalidLength()
    {
        Assert.Throws<ArgumentException>(() => new TicTacToeBoard("XXXOOO"));
    }

    [UnitTest]
    public void ItShouldSetFromBoardState()
    {
        TicTacToeBoard board = new("X--------");

        Assert.True(board.PlayerX.State[0]);
        Assert.Equal(board.PlayerO, board.GetPlayerTurn());
    }

    [UnitTest]
    public void ItShouldDetermineIfValidMove_Taken()
    {
        TicTacToeBoard board = new("X--------");
        Assert.False(board.IsValidMove(0));
    }

    [UnitTest]
    public void ItShouldDetermineIfValidMove_OffBoard()
    {
        TicTacToeBoard board = new("X--------");
        Assert.False(board.IsValidMove(-1));
        Assert.False(board.IsValidMove(10));
    }

    [UnitTest]
    public void ItShouldDetermineIfValidMove()
    {
        TicTacToeBoard board = new("X--------");
        for (int i = 1; i < 9; i++)
        {
            Assert.True(board.IsValidMove(i));
        }
    }

    [UnitTest]
    public void ItShouldPlayATurnAndAdvance()
    {
        TicTacToeBoard board = new();
        board.Move(1);

        Assert.True(board.PlayerX.State[1]);
        Assert.Equal(board.PlayerO, board.GetPlayerTurn());
        Assert.Equal("-X-------", board.ToString());
    }

    [UnitTest]
    public void ItShouldDetermineIfBoardIsFull()
    {
        TicTacToeBoard board = new();

        for (int i = 0; i < 8; i++)
        {
            board.PlayerX.Play(i);
            Assert.False(board.IsBoardFull());
        }

        board.PlayerX.Play(8);
        Assert.True(board.IsBoardFull());
    }
}
