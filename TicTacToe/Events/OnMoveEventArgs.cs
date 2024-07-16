#pragma warning disable CS8618
using TicTacToe.General;

namespace TicTacToe.Events;

public class OnMoveEventArgs
{
    public Player Player;
    public int Position;
}