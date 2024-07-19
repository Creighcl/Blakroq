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

        while(!board.IsGameOver())
        {
            board.MoveForAgent(Difficulty.HARD);
            board.MoveForAgent(Difficulty.EASY);
        }        
    }
}
