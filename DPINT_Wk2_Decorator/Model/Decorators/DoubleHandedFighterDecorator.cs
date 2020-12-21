using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPINT_Wk2_Decorator.Model.Decorators
{
    public class DoubleHandedFighterDecorator : BaseFighterDecorator
    {
        public bool DoubleHanded { get; set; }

        public DoubleHandedFighterDecorator(IFighter fighter) : base(fighter)
        {
            this.DoubleHanded = true;
        }

        public override Attack Attack()
        {
            var attack = _fighter.Attack();

            if (DoubleHanded)
            {
                attack.Value += AttackValue;
                attack.Messages.Add("Doubled the original attack value: " + AttackValue);
            }

            return attack;
        }

        public override void Defend(Attack attack)
        {
            if (DoubleHanded)
            {
                if (attack.Value != 0)
                {
                    attack.Messages.Add("One hand defended the attack: -" + DefenseValue);
                    attack.Value -= DefenseValue;
                }
            }

            _fighter.Defend(attack);
        }
    }
}
