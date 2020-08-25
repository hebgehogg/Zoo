using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlTypes;
using System.Linq;
using Data.Animals.Base;
using Data.Animals.Herbivores;
using Data.Animals.Predators;
using Data.Humans;
using Data.Humans.Employees;
using Data.Services;
using NLog;

namespace Zoo
{
    public sealed class Zoo
    {
        private static Zoo _getInstance;
        
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public IEnumerable<Animal> AllAnimals => Predators.Cast<Animal>().Concat(Herbivores);

        public ObservableCollection<Predator> Predators { get; }

        public ObservableCollection<Herbivore> Herbivores { get; }

        public Director Director { get; }

        public List<Human> Employees { get;}

        public FoodFactory FoodFactory { get; }

        public AnimalFactory AnimalFactory { get; }

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
            Logger.Info("Our zoo is open!");
            
            Predators = new ObservableCollection<Predator>();
            Predators.Add(new Lion());
            Predators.Add(new Fox());

            Herbivores = new ObservableCollection<Herbivore>();
            Herbivores.Add(new Ram());
            Herbivores.Add(new Goat());
            
            FoodFactory = FoodFactory.Instance;
            
            Employees = new List<Human>();

            var readOnlyCollectionHerbivores = new ReadOnlyObservableCollection<Herbivore>(Herbivores);
            var readOnlyCollectionPredators = new ReadOnlyObservableCollection<Predator>(Predators);

            var herbivoreEmployee = new HerbivoresEmployee(readOnlyCollectionHerbivores, FoodFactory);
            var predatorEmployee = new PredatorEmployee(readOnlyCollectionPredators, FoodFactory);



            foreach (var animal in AllAnimals)
                animal.DeadEvent += Animal_DeadEvent;

            AnimalFactory = AnimalFactory.Instance;

            Director = new Director(Employees.Cast<Employee<Animal>>());
        }

        private void Animal_DeadEvent(object sender, System.EventArgs e)
        {
            var animal = (Animal)sender;
            animal.DeadEvent -= Animal_DeadEvent;
            if (animal is Predator predator)
            {
                Logger.Info($"The {animal.Name} died");
                Predators.Remove(predator);
                if(animal is Lion lion)
                    Predators.Add(AnimalFactory.GetAnimal<Lion>());
                if (animal is Fox fox)
                    Predators.Add(AnimalFactory.GetAnimal<Fox>());
            }
            if (animal is Herbivore herbivore)
            {
                Logger.Info($"The {animal.Name} died");
                Herbivores.Remove(herbivore);
                if (animal is Goat goat)
                    Herbivores.Add(AnimalFactory.GetAnimal<Goat>());
                if (animal is Ram ram)
                    Herbivores.Add(AnimalFactory.GetAnimal<Ram>());
            }

            Logger.Info("The " + animal.Name + " born");
        }
    }
}