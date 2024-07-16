#pragma warning disable CS8619, CS8600
using Blakroq.MiniMax;

namespace Blakroq.MinMax;

public class TreeMaximizer<T>
{
    public T FindBestMove(TreeGameState<T> gameState, int depth)
    {
        return MinimaxAlgorithm(gameState, depth, int.MinValue, int.MaxValue).Move;
    }

    private (T Move, int Score) MinimaxAlgorithm(TreeGameState<T> gameState, int depth, int alpha, int beta)
    {
        if (depth == 0 || gameState.IsGameOver())
        {
            return (default(T), gameState.Evaluate());
        }

        T bestMoveToMaximize = default(T);
        T bestMoveToMinimize = default(T);
        int maxEval = int.MinValue;
        int minEval = int.MaxValue;

        foreach (var move in gameState.GetPossibleMoves())
        {
            gameState.ApplyMove(move);
            int eval = MinimaxAlgorithm(gameState, depth - 1, alpha, beta).Score;
            gameState.UndoMove(move);

            if (eval > maxEval)
            {
                maxEval = eval;
                bestMoveToMaximize = move;
            }

            if (eval < minEval)
            {
                minEval = eval;
                bestMoveToMinimize = move;
            }

            alpha = Math.Max(alpha, eval);
            if (beta <= alpha)
            {
                break;
            }
        }

        return (bestMoveToMaximize, maxEval);
    }
}
