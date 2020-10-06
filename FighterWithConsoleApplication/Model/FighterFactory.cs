using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterWithConsoleApplication.Model
{
    public class FighterFactory
    {
        public Dictionary<string, string> FighterOptions { get; private set; }

        public const string DOUBLE_HANDED = "doublehanded";
        public const string MINION = "minion";
        public const string POISON = "poison";
        public const string SHIELD = "shield";
        public const string SHOTGUN = "shotgun";
        public const string STRENGTHEN = "strengthen";

        public FighterFactory()
        {
            FighterOptions = new Dictionary<string, string>();
            FighterOptions[DOUBLE_HANDED] = "A double handed sword for double attack and double defense.";
            FighterOptions[MINION] = "A little minion, adding attack and taking damage before the fighter does.";
            FighterOptions[POISON] = "A poison for 5 time attacks.";
            FighterOptions[SHIELD] = "Taking all your damase for 3 defenses.";
            FighterOptions[SHOTGUN] = "Adding attack, needs reloading every 2 times.";
            
            // TODO: Implement strengthen on fighter
            //FighterOptions[STRENGTHEN] = "Increasing attack by 10%, increasing defense by 10%.";
        }

        public IFighter CreateFighter(int lives = 80, int attack = 15, int defense = 4, IEnumerable<string> options = null)
        {
            IFighter fighter = new Fighter(lives, attack, defense);

            if (options != null)
            {
                foreach (var option in options)
                {
                    switch (option.ToLowerInvariant())
                    {
                        case DOUBLE_HANDED:
                            fighter = new DoubleHandledFighterDecorator(fighter);
                            break;
                        case MINION:
                            fighter = new MinionFighterDecorator(fighter)
                            {
                                MinionLives = fighter.Lives / 2,
                                MinionAttackValue = fighter.AttackValue / 2
                            };
                            break;
                        case POISON:
                            fighter = new PoisonFighterDecorator(fighter) { PoisonStrength = 10 };
                            break;
                        case SHIELD:
                            fighter = new ShieldFighterDecorator(fighter) { ShieldDefends = 3 };
                            break;
                        case SHOTGUN:
                            fighter = new ShotgunFighterDecorator(fighter);
                            break;
                    }
                }
            }

            return fighter;
        }
    }
}
