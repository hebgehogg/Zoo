using System;
using System.Collections.Generic;
using Data.Animals.Base;

namespace Data.Humans.Employees
{
    public abstract class Employee<T>: Human
    where T:Animal
    {
        public List<T> Animals { get; }
        
        public double Salary { get; protected set; }

        public Employee(IEnumerable<T> animals)
        {
            if (animals == null) throw new ArgumentNullException(nameof(animals));
            
            Animals = new List<T>(animals);

            foreach (var animal in animals)
            {
                animal.WantEatEvent+=AnimalOnWantEatEvent;
            }
        }

        private void AnimalOnWantEatEvent(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}