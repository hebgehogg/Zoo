using System;
using Data.Animals.Base;
using Data.FoodKinds.PredatorsFood;

namespace Data.Animals.Predators
{
    public sealed class Fox: Predator
    {
        public Fox()
        {
            Name = "Fox";
        }
        public void Eat(FoxFood food)
        {
            if (food == null) throw new ArgumentNullException(nameof(food));
            
            EatInternal(food);
        }
    }
}