using System;
using Data.Animals.Base;
using Data.FoodKinds.HerbivoresFood;

namespace Data.Animals.Herbivores
{
    public sealed class Goat: Herbivore
    {
        public Goat()
        {
            Name = "Goat";
        }
        public void Eat(GoatFood food)
        {
            if (food == null) throw new ArgumentNullException(nameof(food));
            
            EatInternal(food);
        }
    }
}