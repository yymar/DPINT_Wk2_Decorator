﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPINT_Wk2_Decorator.Model.Decorators
{
    public class ShotgunFighterDecorator : BaseFighterDecorator
    {
        public bool UseShotgun { get; set; }
        public int ShotgunRoundsFired { get; set; }

        public ShotgunFighterDecorator(IFighter fighter) : base(fighter)
        {
            this.Lives = fighter.Lives;
            this.AttackValue = fighter.AttackValue;
            this.DefenseValue = fighter.DefenseValue;
            this.UseShotgun = true;
        }

        public override Attack Attack()
        {
            var attack = new Attack("Normal attack: " + this.AttackValue, this.AttackValue);

            if (UseShotgun)
            {
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
            }

            base.Attack();
            return attack;
        }
    }
}
