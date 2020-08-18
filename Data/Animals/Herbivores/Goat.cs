using System;
using Data.Animals.Base;
using Data.FoodKinds.Base;
using Data.FoodKinds.HerbivoresFood;
using NLog;

namespace Data.Animals.Herbivores
{
    public sealed class Goat: Herbivore
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public Goat()
        {
            Name = "Goat";
            TimerInterval=4000;
        }

        public override void Eat(Food food)
        {
            Logger.Info("The goat ate");
            if(!(food is GoatFood))
                throw new ArgumentException();
            EatInternal(food);
        }
    }
}