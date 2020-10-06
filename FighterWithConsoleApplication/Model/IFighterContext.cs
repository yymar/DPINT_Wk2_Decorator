using System.Collections.Generic;

namespace FighterWithConsoleApplication.Model
{
    public interface IFighterContext
    {
        void AddNewFighter();
        void RebuildFighter(int fighterId, IEnumerable<string> options);
        void AttackWithFighter(int fighterId);

    }
}