using System;
using Data.Animals.Base;
using Data.FoodKinds.Base;
using Data.FoodKinds.PredatorsFood;
using log4net;

namespace Data.Animals.Predators
{
    public sealed class Lion : Predator
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(Lion));
        
        public Lion()
        {
            Name = "Lion";
            TimerInterval=34000;
        }

        public override void Eat(Food food)
        {
            _log.Info("The lion ate");
            if(!(food is LionFood))
                throw new ArgumentException();
            EatInternal(food);
        }
    }
}