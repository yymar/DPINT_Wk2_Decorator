using FighterWithConsoleApplication.Model;
using FighterWithConsoleApplication.View;
using System;
using System.Collections.Generic;

namespace FighterWithConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            
            FighterFactory fighterFactory = new FighterFactory();
            BattleGround battleGround = new BattleGround(fighterFactory);

            List<FighterView> fighterViews = new List<FighterView>();
            battleGround.FighterAdded += (sender, fighter) => fighterViews.Add(new FighterView($"Fighter {fighterViews.Count + 1}", fighter));
            battleGround.FighterRebuilt += (sender, idWithFighter) => fighterViews[idWithFighter.Item1 - 1].Fighter = idWithFighter.Item2;

            var battleGroundView = new BattleGroundView(battleGround);

            InputView inputView = new InputView(battleGround, fighterFactory.FighterOptions.Keys);

            while (!inputView.Quit)
            {
                foreach (var view in fighterViews)
                {
                    view.Draw();
                }

                inputView.AskForInput();
            }
        }
    }
}
