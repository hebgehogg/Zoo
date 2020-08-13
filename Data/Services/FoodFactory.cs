using System;
using Data.Animals.Base;
using Data.Animals.Herbivores;
using Data.Animals.Predators;
using Data.FoodKinds.Base;
using Data.FoodKinds.HerbivoresFood;
using Data.FoodKinds.PredatorsFood;

namespace Data.Services
{
    public sealed class FoodFactory
    {
        private static FoodFactory _instance;
        
        public static FoodFactory Instance
        {
            get
            {
                if(_instance==null)
                    _instance = new FoodFactory();
                
                return _instance;
            }
        }

        private FoodFactory()
        {
            
        }

        public Food GetFood(Animal animal)
        {
            if (animal == null) throw new ArgumentNullException(nameof(animal));
            switch (animal)
            {
                case Goat _:
                    return new GoatFood();
                case Ram _:
                    return new RamFood();
                case Fox _:
                    return new FoxFood();
                case Lion _:
                    return new LionFood();
                default:
                    throw new ArgumentOutOfRangeException(nameof(animal));
            }
            
        }
    }
}