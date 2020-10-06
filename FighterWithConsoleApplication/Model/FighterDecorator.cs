using System;
using System.Collections.Generic;
using System.Text;

namespace FighterWithConsoleApplication.Model
{
    public abstract class FighterDecorator : IFighter
    {
        public int Lives { get => NextFighter.Lives; set => NextFighter.Lives = value; }
        public int AttackValue { get => NextFighter.AttackValue; set => NextFighter.AttackValue = value; }
        public int DefenseValue { get => NextFighter.DefenseValue; set => NextFighter.DefenseValue = value; }
        public IFighter NextFighter { get; }

        public virtual IEnumerable<string> Descriptives => NextFighter.Descriptives;

        public FighterDecorator(IFighter nextFighter)
        {
            NextFighter = nextFighter;
        }

        public virtual Attack Attack()
        {
            return NextFighter.Attack();
        }

        public virtual void Defend(Attack attack)
        {
            NextFighter.Defend(attack);
        }
    }
}
