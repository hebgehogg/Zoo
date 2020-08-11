using System;
using System.Collections.Generic;
using Data.Animals.Base;

namespace Data.Humans.Employees
{
    public sealed class HerbivoresEmployee: Employee<Herbivore>
    {
        public HerbivoresEmployee(IEnumerable<Herbivore> animals) : base(animals)
        {
            if (animals == null) throw new ArgumentNullException(nameof(animals));
            
            Name = "HerbivoresEmployee";
            Salary = 250d;
        }   
    }
}