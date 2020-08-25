using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Data.Animals.Base;
using Data.Services;

namespace Data.Humans.Employees
{
    public sealed class PredatorEmployee: Employee<Predator>
    {
        public PredatorEmployee(ReadOnlyObservableCollection<Predator> animals, FoodFactory foodFactory) : base(animals, foodFactory)
        {
            if (animals == null) throw new ArgumentNullException(nameof(animals));
            
            Name = "PredatorEmployee";
            Salary = 300d;
        }
    }
}