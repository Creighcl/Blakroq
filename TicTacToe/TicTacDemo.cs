using Blakroq.Tests;
using TicTacToe.AI;
using TicTacToe.Events;
using TicTacToe.General;

namespace TicTacToe;

public class TicTacDemo
{
    [UnitTest]
    public void ItShouldDemo()
    {
        TicTacToeBoard board = new();

        board.Move(0);
        board.MoveForAgent(Difficulty.HARD);

        board.Move(8);
        board.MoveForAgent(Difficulty.HARD);

        board.Move(6);
        board.MoveForAgent(Difficulty.HARD);
    }
}
