using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FighterWithConsoleApplication.Model
{
    public class MinionFighterDecorator : FighterDecorator
    {
        public int MinionLives { get; set; }
        public int MinionAttackValue { get; set; }

        public MinionFighterDecorator(IFighter nextFighter) : base(nextFighter)
        {
        }

        public override IEnumerable<string> Descriptives => base.Descriptives.Append("Minion");

        public override void Defend(Attack attack)
        {
            if (MinionLives > 0)
            {
                int tmpLives = MinionLives;
                MinionLives -= Math.Max(0, attack.Value);
                attack.Value -= Math.Max(0, tmpLives - MinionLives);
                attack.Messages.Add("Minion defended from the attack: -" + attack.Value);
            }

            base.Defend(attack);
        }

        public override Attack Attack()
        {
            var attack = base.Attack();
            attack.Messages.Add("Minion helping the attack: " + MinionAttackValue);
            attack.Value += MinionAttackValue;
            return attack;
        }
    }
}
