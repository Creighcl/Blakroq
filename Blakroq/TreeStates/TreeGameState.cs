namespace Blakroq.MiniMax;

public interface TreeGameState<T>
{
    List<T> GetPossibleMoves();
    void ApplyMove(T move);
    void UndoMove(T move);
    bool IsGameOver();
    int Evaluate();
}
