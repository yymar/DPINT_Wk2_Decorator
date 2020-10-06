using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FighterWithConsoleApplication.Model
{
    public class BattleGround : IFighterContext, IBattleGroundActions
    {
        private FighterFactory fighterFactory;
        public List<IFighter> Fighters { get; private set; } = new List<IFighter>();

        public event EventHandler<IFighter> FighterAdded;
        public event EventHandler<Tuple<int, IFighter>> FighterRebuilt;
        public event EventHandler<Tuple<int, Attack>> FighterAttacked;
        public event EventHandler<Tuple<int, Attack>> FighterDefended;

        public BattleGround(FighterFactory fighterFactory)
        {
            this.fighterFactory = fighterFactory;
        }

        public void AddNewFighter()
        {
            IFighter newFighter = fighterFactory.CreateFighter();
            Fighters.Add(newFighter);
            FighterAdded?.Invoke(this, newFighter);
        }

        public void AttackWithFighter(int fighterId)
        {
            if (Fighters.Count >= fighterId)
            {
                IFighter fighter = Fighters[fighterId - 1];
                Attack attack = fighter.Attack();
                FighterAttacked?.Invoke(this, new Tuple<int, Attack>(fighterId, attack));

                for (int i = 0; i < Fighters.Count; i++)
                {
                    if(i != fighterId - 1)
                    {
                        var attackToDefend = attack.Clone();
                        Fighters[i].Defend(attackToDefend);
                        FighterDefended?.Invoke(this, new Tuple<int, Attack>(i + 1, attackToDefend));
                    }
                }
            }
            else
            {
                throw new ArgumentException($"Fighter with ID {fighterId} does not exist", "fighterId");
            }
        }

        public void RebuildFighter(int fighterId, IEnumerable<string> options)
        {
            if(Fighters.Count >= fighterId)
            {
                IFighter oldFighter = Fighters[fighterId - 1];
                IFighter newFighter = fighterFactory.CreateFighter(oldFighter.Lives, oldFighter.AttackValue, oldFighter.DefenseValue, options);
                Fighters[fighterId - 1] = newFighter;
                FighterRebuilt?.Invoke(this, new Tuple<int, IFighter>(fighterId, newFighter));
            }
            else
            {
                throw new ArgumentException($"Fighter with ID {fighterId} does not exist", "fighterId");
            }
        }
    }
}
