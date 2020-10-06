using FighterWithConsoleApplication.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FighterWithConsoleApplication.View
{
    class FighterView
    {
        public string Name { get; private set; }
        public IFighter Fighter { get; set; }

        public FighterView(string name, IFighter fighter)
        {
            this.Name = name;
            this.Fighter = fighter;
        }

        internal void Draw()
        {
            var oldFgColor = Console.ForegroundColor;
            var oldBgColor = Console.BackgroundColor;

            Console.WriteLine(new String('-', Console.WindowWidth)); 
            Console.WriteLine(Name);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Description: {0}", String.Join(", ",Fighter.Descriptives));
            Console.WriteLine("Lives: {0}", Fighter.Lives);

            Console.ForegroundColor = oldFgColor;
            Console.BackgroundColor = oldBgColor;
            Console.WriteLine(new String('-', Console.WindowWidth));
        }
    }
}
