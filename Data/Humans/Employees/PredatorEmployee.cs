using System;
using System.Collections.Generic;
using Data.Animals.Base;

namespace Data.Humans.Employees
{
    public sealed class PredatorEmployee: Employee<Predator>
    {
        public PredatorEmployee(IEnumerable<Predator> animals) : base(animals)
        {
            if (animals == null) throw new ArgumentNullException(nameof(animals));
            
            Name = "PredatorEmployee";
            Salary = 300d;
        }
    }
}