using System.Collections.Generic;
using Data.Animals.Base;
using Data.Animals.Herbivores;
using Data.Animals.Predators;
using Data.Humans;
using Data.Humans.Employees;
using Data.Services;
using log4net;
using log4net.Config;
using log4net.Repository.Hierarchy;

namespace Zoo
{
    public sealed class Zoo
    {
        private static Zoo _getInstance;
        
        private static readonly ILog _log = LogManager.GetLogger(typeof(Zoo));
        public List<Predator> Predators { get; }

        public List<Herbivore> Herbivores { get; }

        public List<Human> Employees { get;}

        public FoodFactory FoodFactory { get; }

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
            BasicConfigurator.Configure(new Hierarchy());
            _log.Info("Our zoo is open!");
            
            Predators = new List<Predator>();
            Predators.Add(new Lion());
            Predators.Add(new Fox());

            Herbivores = new List<Herbivore>();
            Herbivores.Add(new Ram());
            Herbivores.Add(new Goat());
            
            FoodFactory = FoodFactory.Instance;
            
            Employees = new List<Human>();
            Employees.Add(new HerbivoresEmployee(Herbivores, FoodFactory));
            Employees.Add(new PredatorEmployee(Predators, FoodFactory));
        }
    }
}