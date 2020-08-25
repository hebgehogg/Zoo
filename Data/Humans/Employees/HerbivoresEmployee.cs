using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Data.Animals.Base;
using Data.Services;

namespace Data.Humans.Employees
{
    public sealed class HerbivoresEmployee: Employee<Herbivore>
    {
        public HerbivoresEmployee(ReadOnlyObservableCollection<Herbivore> animals, FoodFactory foodFactory) : base(animals, foodFactory)
        {
            if (animals == null) throw new ArgumentNullException(nameof(animals));
            
            Name = "HerbivoresEmployee";
            Salary = 250d;
        }   
    }
}