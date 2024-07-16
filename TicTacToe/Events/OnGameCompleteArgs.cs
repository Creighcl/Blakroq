#pragma warning disable CS8618

using TicTacToe.General;

namespace TicTacToe.Events;

public class OnGameCompleteArgs
{
    public Player? Winner;
}
