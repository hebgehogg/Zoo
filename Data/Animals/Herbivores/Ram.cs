using System;
using Data.Animals.Base;
using Data.FoodKinds.Base;
using Data.FoodKinds.HerbivoresFood;
using NLog;

namespace Data.Animals.Herbivores
{
    public sealed class Ram: Herbivore
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        
        public Ram()
        {
            Name = "Ram";
            TimerInterval=4000;
        }

        public override void Eat(Food food)
        {
            Logger.Info("The ram ate");
            if(!(food is RamFood))
                throw new ArgumentException();
            EatInternal(food);
        }
    }
}