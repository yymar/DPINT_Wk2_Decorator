using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FighterWithConsoleApplication.Model
{
    public class PoisonFighterDecorator : FighterDecorator
    {
        public int PoisonStrength { get; set; }

        public PoisonFighterDecorator(IFighter nextFighter) : base(nextFighter)
        {
        }
        
        public override IEnumerable<string> Descriptives => base.Descriptives.Append("Poison");

        public override Attack Attack()
        {
            var attack = base.Attack();

            if (PoisonStrength > 0)
            {

                attack.Messages.Add("Poison weakening, current value: " + PoisonStrength);
                attack.Value += PoisonStrength;
                PoisonStrength -= 2;
            }
            else
            {
                attack.Messages.Add("Poison ran out.");
            }

            return attack;
        }
    }
}
