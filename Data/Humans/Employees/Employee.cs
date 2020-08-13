using System;
using System.Collections.Generic;
using Data.Animals.Base;
using Data.Services;

namespace Data.Humans.Employees
{
    public abstract class Employee<T>: Human
    where T:Animal
    {
        protected FoodFactory FoodFactory { get; }
        
        public List<T> Animals { get; }
        
        public double Salary { get; protected set; }

        public Employee(IEnumerable<T> animals, FoodFactory foodFactory)
        {
            if (animals == null) throw new ArgumentNullException(nameof(animals));
            if (foodFactory == null) throw new ArgumentNullException(nameof(foodFactory));
            
            FoodFactory = foodFactory;

            Animals = new List<T>(animals);

            foreach (var animal in animals)
            {
                animal.WantEatEvent+=AnimalOnWantEatEvent;
            }
        }

        private void AnimalOnWantEatEvent(object? sender, EventArgs e)
        {
            var animal = (Animal)sender;
            var food = FoodFactory.GetFood(animal);
            animal.Eat(food);
        }
    }
}