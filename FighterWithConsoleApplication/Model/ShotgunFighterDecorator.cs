using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FighterWithConsoleApplication.Model
{
    public class ShotgunFighterDecorator : FighterDecorator
    {
        public ShotgunFighterDecorator(IFighter nextFighter) : base(nextFighter)
        {
        }

        public int ShotgunRoundsFired { get; private set; }

        public override IEnumerable<string> Descriptives => base.Descriptives.Append("Shotgun");

        public override Attack Attack()
        {
            var attack = base.Attack();
            if (ShotgunRoundsFired < 2)
            {
                attack.Messages.Add("Shotgun: 20");
                attack.Value += 20;
                ShotgunRoundsFired++;
            }
            else
            {
                attack.Messages.Add("Shotgun reloading, no extra damage.");
                ShotgunRoundsFired = 0;
            }
            return attack;
        }
    }
}
