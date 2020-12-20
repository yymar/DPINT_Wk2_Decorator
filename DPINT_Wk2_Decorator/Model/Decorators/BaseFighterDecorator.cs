using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPINT_Wk2_Decorator.Model
{
    public abstract class BaseFighterDecorator : IFighter
    {
        public int Lives { get => _fighter.Lives; set { _fighter.Lives = value; } }
        public int AttackValue { get => _fighter.AttackValue; set { _fighter.AttackValue = value; } }
        public int DefenseValue { get => _fighter.DefenseValue; set { _fighter.DefenseValue = value; } }

        protected IFighter _fighter;

        public BaseFighterDecorator(IFighter fighter)
        {
            this._fighter = fighter;
        }

        public virtual Attack Attack()
        {
            if (_fighter != null)
            {
                return this._fighter.Attack();
            }
            else
            {
                return null;
            }
        }

        public virtual void Defend(Attack attack)
        {
            if (_fighter != null)
            {
                this._fighter.Defend(attack);
            }
            else
            {
                Console.WriteLine("_fighter == null");
            }
        }
    }
}