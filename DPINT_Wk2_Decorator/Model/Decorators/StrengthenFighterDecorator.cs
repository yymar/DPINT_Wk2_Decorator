using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPINT_Wk2_Decorator.Model.Decorators
{
    public class StrengthenFighterDecorator : BaseFighterDecorator
    {
        public StrengthenFighterDecorator(IFighter fighter) : base(fighter)
        {
            this.Lives = fighter.Lives;
            this.AttackValue = fighter.AttackValue;
            this.DefenseValue = fighter.DefenseValue;
        }

        public override Attack Attack()
        {
            var attack = new Attack("Normal attack: " + this.AttackValue, this.AttackValue);

            double strengthenAttack = Convert.ToDouble(this.AttackValue) * 10 / 100;
            int strengthenAttackInt = (int)Math.Ceiling(strengthenAttack);

            attack.Value += strengthenAttackInt;
            attack.Messages.Add("Strengthened the attack with 10%: " + strengthenAttackInt + " (rounded up double: " + strengthenAttack + ")");

            base.Attack();
            return attack;
        }

        public override void Defend(Attack attack)
        {
            double strengthenDefense = Convert.ToDouble(this.AttackValue) * 10 / 100;
            int strengthenDefensekInt = (int)Math.Ceiling(strengthenDefense);

            attack.Value -= strengthenDefensekInt;
            attack.Messages.Add("Weakened the attack with 10%: " + strengthenDefensekInt + " (rounded up double: " + strengthenDefense + ")");

            base.Defend(attack);
        }
    }
}
