using System;
using Data.Animals.Base;
using Data.FoodKinds.Base;
using Data.FoodKinds.PredatorsFood;
using NLog;

namespace Data.Animals.Predators
{
    public sealed class Lion : Predator
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        
        public Lion()
        {
            Name = "Lion";
            TimerInterval=8000;
        }

        public override void Eat(Food food)
        {
            Logger.Info("The lion ate");
            if(!(food is LionFood))
                throw new ArgumentException();
            EatInternal(food);
        }
    }
}