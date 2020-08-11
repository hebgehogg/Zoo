using System.Collections.Generic;
using Data.Animals.Base;
using Data.Animals.Herbivores;
using Data.Animals.Predators;
using Data.Humans;
using Data.Humans.Employees;

namespace Zoo
{
    public sealed class Zoo
    {
        private static Zoo _getInstance;
        
        
        public List<Predator> Predators { get; }

        public List<Herbivore> Herbivores { get; }

        public List<Human> Employees { get;}

        public static Zoo GetInstance
        {
            get
            {
                if(_getInstance==null)
                    _getInstance = new Zoo();
                
                return _getInstance;
            }
        }

        private Zoo()
        {
            Predators = new List<Predator>();
            Predators.Add(new Lion());
            Predators.Add(new Fox());

            Herbivores = new List<Herbivore>();
            Herbivores.Add(new Ram());
            Herbivores.Add(new Goat());
            
            Employees = new List<Human>();
            Employees.Add(new HerbivoresEmployee(Herbivores));
            Employees.Add(new PredatorEmployee(Predators));
        }
    }
}