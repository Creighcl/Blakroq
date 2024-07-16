using Blakroq.MinMax;
using TicTacToe.Events;
using TicTacToe.General;

namespace TicTacToe.AI;

public class TicTacAgent
{
    public OnMoveEventArgs Search(TicTacToeBoard board, Difficulty difficulty, Player? playerToOptimize = null)
    {
        if (playerToOptimize == null) { playerToOptimize = board.GetPlayerTurn(); }

        TreeMaximizer<OnMoveEventArgs> miniMax = new();
        AgentGameState state = new(board, difficulty, playerToOptimize);

        return miniMax.FindBestMove(state, 1);
    }
}
