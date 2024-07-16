using Blakroq.Tests;
using TicTacToe.Events;
using TicTacToe.General;
using Xunit;

namespace TicTacToe.AI;

public class TicTacAgentTests
{
    [UnitTest]
    public void ItShouldSearch()
    {
        TicTacToeBoard board = new();
        TicTacAgent agent = new();
        OnMoveEventArgs bestMove = agent.Search(board, Difficulty.HARD);
        Assert.Equal(0, bestMove.Position);
    }

    [UnitTest]
    public void ItShouldFindBestMove()
    {
        TicTacToeBoard board = new("XX-OO----");
        TicTacAgent agent = new();
        OnMoveEventArgs bestMove = agent.Search(board, Difficulty.HARD);
        Assert.Equal(2, bestMove.Position);
    }

    [UnitTest]
    public void ItShouldFindFork()
    {
        TicTacToeBoard board = new("X---O--OX");
        TicTacAgent agent = new();
        OnMoveEventArgs bestMove = agent.Search(board, Difficulty.HARD);

        board.Move(bestMove.Position);
        Assert.Equal(2, bestMove.Position);

        AgentGameState state = new(board, Difficulty.HARD, board.PlayerX);
        int score = state.Evaluate();
    }

    [UnitTest]
    public void ItShouldFindOptimalBlock()
    {
        TicTacToeBoard board = new("X---O---X");
        TicTacAgent agent = new();
        OnMoveEventArgs bestMove = agent.Search(board, Difficulty.HARD);

        board.Move(bestMove.Position);
        Assert.Equal(1, bestMove.Position);
    }
}
