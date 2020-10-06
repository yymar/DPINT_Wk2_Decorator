using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FighterWithConsoleApplication.Model
{
    public class ShieldFighterDecorator : FighterDecorator
    {
        public ShieldFighterDecorator(IFighter nextFighter) : base(nextFighter)
        {
        }


        public int ShieldDefends { get; set; }

        public override IEnumerable<string> Descriptives => base.Descriptives.Append("Shield");


        public override void Defend(Attack attack)
        {
            if (ShieldDefends > 0)
            {
                attack.Messages.Add("Shield protected, attack value = 0");
                attack.Value = 0;
                ShieldDefends--;
            }

            base.Defend(attack);
        }
    }
}
