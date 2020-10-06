using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FighterWithConsoleApplication.Model
{
    public class DoubleHandledFighterDecorator : FighterDecorator
    {
        public DoubleHandledFighterDecorator(IFighter nextFighter) : base(nextFighter)
        {
        }

        public override IEnumerable<string> Descriptives => base.Descriptives.Append("Double-handed");

        public override void Defend(Attack attack)
        {
            attack.Messages.Add("One hand defended the attack: -" + DefenseValue);
            attack.Value -= DefenseValue;
            base.Defend(attack);
        }

        public override Attack Attack()
        {
            var attack = base.Attack();
            attack.Value += AttackValue;
            attack.Messages.Add("Doubled the original attack value: " + AttackValue);
            return attack;
        }
    }
}
