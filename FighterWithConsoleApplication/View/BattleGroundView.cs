using FighterWithConsoleApplication.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FighterWithConsoleApplication.View
{
    public class BattleGroundView
    {
        public BattleGroundView(IBattleGroundActions actions)
        {
            actions.FighterAttacked += Actions_FighterAttacked;
            actions.FighterDefended += Actions_FighterDefended;
        }

        private void Actions_FighterDefended(object sender, Tuple<int, Attack> e)
        {
            Console.WriteLine($"Fighter {e.Item1} defended.");
            foreach (var message in e.Item2.Messages)
            {
                Console.WriteLine($"\t{message}");
            }
        }

        private void Actions_FighterAttacked(object sender, Tuple<int, Attack> e)
        {
            Console.WriteLine($"Fighter {e.Item1} attacked.");
            foreach (var message in e.Item2.Messages)
            {
                Console.WriteLine($"\t{message}");
            }
        }
    }
}
