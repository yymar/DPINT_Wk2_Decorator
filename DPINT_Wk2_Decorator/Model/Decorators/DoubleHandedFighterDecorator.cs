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
            this.Lives = fighter.Lives;
            this.AttackValue = fighter.AttackValue;
            this.DefenseValue = fighter.DefenseValue;
            this.DoubleHanded = true;
        }

        public override Attack Attack()
        {
            var attack = new Attack("Double Handed attack: " + this.AttackValue, this.AttackValue);

            if (DoubleHanded)
            {
                attack.Value += AttackValue;
                attack.Messages.Add("Doubled the original attack value: " + AttackValue);
            }

            base.Attack();
            return attack;
        }

        public override void Defend(Attack attack)
        {
            if (DoubleHanded)
            {
                attack.Messages.Add("One hand defended the attack: -" + DefenseValue);
                attack.Value -= DefenseValue;
            }

            base.Defend(attack);
        }
    }
}
