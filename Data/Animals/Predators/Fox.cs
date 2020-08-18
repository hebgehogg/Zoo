using System;
using Data.Animals.Base;
using Data.Animals.Herbivores;
using Data.FoodKinds.Base;
using Data.FoodKinds.PredatorsFood;
using NLog;

namespace Data.Animals.Predators
{
    public sealed class Fox: Predator
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        
        public Fox()
        {
            Name = "Fox";
            TimerInterval=8000;
        }
        public override void Eat(Food food)
        {
            Logger.Info("The fox ate");
            if(!(food is FoxFood))
                throw new ArgumentException();
            EatInternal(food);
        }
    }
}