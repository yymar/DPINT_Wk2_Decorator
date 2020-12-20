namespace DPINT_Wk2_Decorator.Model.Decorators
{
    public class ShieldFighterDecorator : BaseFighterDecorator
    {
        public int ShieldDefends { get; set; }

        public ShieldFighterDecorator(IFighter fighter) : base(fighter)
        {
            this.Lives = fighter.Lives;
            this.AttackValue = fighter.AttackValue;
            this.DefenseValue = fighter.DefenseValue;
            this.ShieldDefends = 3;
        }

        public override void Defend(Attack attack)
        {
            if (ShieldDefends > 0)
            {
                attack.Messages.Add("Shield protected, attack value = 0");
                attack.Value = 0;
                ShieldDefends--;
            }
            else
            {
                base.Defend(attack);
            }
        }
    }
}