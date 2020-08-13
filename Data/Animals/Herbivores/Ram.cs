using System;
using Data.Animals.Base;
using Data.FoodKinds.Base;
using Data.FoodKinds.HerbivoresFood;
using log4net;

namespace Data.Animals.Herbivores
{
    public sealed class Ram: Herbivore
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(Ram));
        
        public Ram()
        {
            Name = "Ram";
            TimerInterval=14000;
        }

        public override void Eat(Food food)
        {
            _log.Info("The ram ate");
            if(!(food is RamFood))
                throw new ArgumentException();
            EatInternal(food);
        }
    }
}