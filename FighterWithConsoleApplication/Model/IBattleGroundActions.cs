using System;

namespace FighterWithConsoleApplication.Model
{
    public interface IBattleGroundActions
    {
        event EventHandler<Tuple<int, Attack>> FighterAttacked;
        event EventHandler<Tuple<int, Attack>> FighterDefended;
    }
}