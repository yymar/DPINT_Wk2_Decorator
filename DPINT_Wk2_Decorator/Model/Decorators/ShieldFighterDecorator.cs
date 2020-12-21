namespace DPINT_Wk2_Decorator.Model.Decorators
{
    public class ShieldFighterDecorator : BaseFighterDecorator
    {
        public int ShieldDefends { get; set; }

        public ShieldFighterDecorator(IFighter fighter) : base(fighter)
        {
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

            _fighter.Defend(attack);
        }
    }
}