using System;
using Data.Animals.Base;
using Data.Animals.Herbivores;
using Data.FoodKinds.Base;
using Data.FoodKinds.PredatorsFood;
using log4net;

namespace Data.Animals.Predators
{
    public sealed class Fox: Predator
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(Fox));
        
        public Fox()
        {
            Name = "Fox";
            TimerInterval=30000;
        }
        public override void Eat(Food food)
        {
            _log.Info("The fox ate");
            if(!(food is FoxFood))
                throw new ArgumentException();
            EatInternal(food);
        }
    }
}