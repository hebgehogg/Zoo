using System;
using Data.Animals.Base;
using Data.FoodKinds.PredatorsFood;

namespace Data.Animals.Predators
{
    public sealed class Lion : Predator
    {
        public Lion()
        {
            Name = "Lion";
        }

        public void Eat(LionFood food)
        {
            if (food == null) throw new ArgumentNullException(nameof(food));
            
            EatInternal(food);
        }
    }
}