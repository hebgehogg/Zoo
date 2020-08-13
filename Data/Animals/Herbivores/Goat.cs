using System;
using Data.Animals.Base;
using Data.FoodKinds.Base;
using Data.FoodKinds.HerbivoresFood;
using log4net;

namespace Data.Animals.Herbivores
{
    public sealed class Goat: Herbivore
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(Goat));
        public Goat()
        {
            Name = "Goat";
            TimerInterval=1500;
        }

        public override void Eat(Food food)
        {
            _log.Info("The goat ate");
            if(!(food is GoatFood))
                throw new ArgumentException();
            EatInternal(food);
        }
    }
}