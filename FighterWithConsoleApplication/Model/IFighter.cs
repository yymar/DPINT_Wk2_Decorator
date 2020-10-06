using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterWithConsoleApplication.Model
{
    public interface IFighter
    {
        int Lives { get; set; }
        int AttackValue { get; set; }
        int DefenseValue { get; set; }

        void Defend(Attack attack);

        Attack Attack();

        IEnumerable<string> Descriptives { get; }
    }
}
