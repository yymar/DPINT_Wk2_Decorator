using FighterWithConsoleApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FighterWithConsoleApplication.View
{
    public class InputView
    {
        public Action<int> AttackWithFighter { get; private set; }
        public Action AddNewFighter { get; private set; }
        public Action<int, IEnumerable<string>> RebuildFighter { get; private set; }
        public IEnumerable<string> FighterOptions { get; }
        public bool Quit { get; internal set; }

        public InputView(IFighterContext context, IEnumerable<string> fighterOptions)
        {
            FighterOptions = fighterOptions;
            AttackWithFighter = context.AttackWithFighter;
            RebuildFighter = context.RebuildFighter;
            AddNewFighter = context.AddNewFighter;
        }

        internal void AskForInput()
        {
            Console.WriteLine("Please select one of the following actions:");
            Console.WriteLine("\tcreate");
            Console.WriteLine("\t<fighter number> attack"); 
            Console.WriteLine("\t<fighter number> rebuild <options, space separated>");
            Console.WriteLine($"\t\tOptions: {String.Join(" ", FighterOptions) }");


            string[] commands = Console.ReadLine().Split(' ');

            int fighterId;
            if (int.TryParse(commands[0], out fighterId))
            {
                if (commands[1].Equals("attack", StringComparison.InvariantCultureIgnoreCase))
                {
                    AttackWithFighter(fighterId);
                }
                else if (commands[1].Equals("rebuild", StringComparison.InvariantCultureIgnoreCase))
                {
                    RebuildFighter(fighterId, commands.Skip(2));
                }
            }
            else if (commands[0].Equals("quit", StringComparison.InvariantCultureIgnoreCase))
            {
                Quit = true;
            }
            else if(commands[0].Equals("create", StringComparison.InvariantCultureIgnoreCase))
            {
                AddNewFighter();
            }
            else
            {
                Console.WriteLine("Fighter number must be integer. Please retry");
            }
        }
    }
}
