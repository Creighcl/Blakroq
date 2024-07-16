using Blakroq.MiniMax;
using TicTacToe.Events;
using TicTacToe.General;

namespace TicTacToe.AI;

public class AgentGameState : TreeGameState<OnMoveEventArgs>
{
    internal TicTacToeBoard Board = new();
    internal Player AgentPlayer, OpponentPlayer;
    internal Difficulty Difficulty;

    public AgentGameState(TicTacToeBoard board, Difficulty difficulty, Player agentPlayer) 
    {
        Difficulty = difficulty;
        Board = board; 
        AgentPlayer = agentPlayer;
        OpponentPlayer = Board.PlayerX == AgentPlayer ? Board.PlayerO : Board.PlayerX;
    }

    public int Evaluate()
    {
        if (AgentPlayer.IsWinningState()) { return 10000; }
        if (OpponentPlayer.IsWinningState()) { return -10000; }
        if (Board.IsBoardFull()) { return 0; }

        if (Difficulty == Difficulty.EASY) { return 0; }

        int score = 0;

        int centerWorth = 15;
        if (!Board.IsBoardEmpty()) { centerWorth = 150; }

        if (Difficulty >= Difficulty.MEDIUM)
        {
            if (AgentPlayer.State[0]) { score += 25; }
            if (AgentPlayer.State[2]) { score += 25; }
            if (AgentPlayer.State[6]) { score += 25; }
            if (AgentPlayer.State[8]) { score += 25; }
            if (AgentPlayer.State[4]) { score += centerWorth; }
        }

        if (Difficulty >= Difficulty.HARD)
        {
            if (IsWinConditionPresent(AgentPlayer, 0, 1, 2)) { score += 100; }
            if (IsWinConditionPresent(AgentPlayer, 3, 4, 5)) { score += 100; }
            if (IsWinConditionPresent(AgentPlayer, 6, 7, 8)) { score += 100; }
            if (IsWinConditionPresent(AgentPlayer, 0, 4, 8)) { score += 100; }
            if (IsWinConditionPresent(AgentPlayer, 2, 4, 6)) { score += 100; }
            if (IsWinConditionPresent(AgentPlayer, 0, 3, 6)) { score += 100; }
            if (IsWinConditionPresent(AgentPlayer, 1, 4, 7)) { score += 100; }
            if (IsWinConditionPresent(AgentPlayer, 2, 5, 8)) { score += 100; }
        
            if (IsWinConditionPresent(OpponentPlayer, 0, 1, 2)) { score -= 500; }
            if (IsWinConditionPresent(OpponentPlayer, 3, 4, 5)) { score -= 500; }
            if (IsWinConditionPresent(OpponentPlayer, 6, 7, 8)) { score -= 500; }
            if (IsWinConditionPresent(OpponentPlayer, 0, 4, 8)) { score -= 500; }
            if (IsWinConditionPresent(OpponentPlayer, 2, 4, 6)) { score -= 500; }
            if (IsWinConditionPresent(OpponentPlayer, 0, 3, 6)) { score -= 500; }
            if (IsWinConditionPresent(OpponentPlayer, 1, 4, 7)) { score -= 500; }
            if (IsWinConditionPresent(OpponentPlayer, 2, 5, 8)) { score -= 500; }
        }

        return score;
    }

    private bool IsWinConditionPresent(Player player, int a, int b, int c)
    {
        Player opponent = player == AgentPlayer ? OpponentPlayer : AgentPlayer;

        if (opponent.State[a]) { return false; }
        if (opponent.State[b]) { return false; }
        if (opponent.State[c]) { return false; }

        int presentForPlayer = 0;
        if (player.State[a]) { presentForPlayer++; }
        if (player.State[b]) { presentForPlayer++; }
        if (player.State[c]) { presentForPlayer++; }

        return presentForPlayer == 2;
    }

    public List<OnMoveEventArgs> GetPossibleMoves()
    {
        List<OnMoveEventArgs> possibleMoves = [];

        Player currentPlayer = Board.GetPlayerTurn();

        for(int i = 0; i < 9; i++)
        {
            bool isValidMove = Board.IsValidMove(i);
            if (isValidMove) { possibleMoves.Add(new() { Player = currentPlayer, Position = i }); }
        }

        return possibleMoves;
    }

    public void ApplyMove(OnMoveEventArgs move) { Board.Move(move.Position); }
    public void UndoMove(OnMoveEventArgs move) { Board.UndoMove(move.Player, move.Position); }
    public bool IsGameOver() { return Board.IsGameOver(); }
}
