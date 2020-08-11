using System;
using Data.Animals.Base;
using Data.FoodKinds.HerbivoresFood;

namespace Data.Animals.Herbivores
{
    public sealed class Ram: Herbivore
    {
        public Ram()
        {
            Name = "Ram";
        }
        public void Eat(RamFood food)
        {
            if (food == null) throw new ArgumentNullException(nameof(food));
            
            EatInternal(food);
        }
    }
}