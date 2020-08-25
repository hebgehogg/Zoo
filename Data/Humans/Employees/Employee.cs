using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Data.Animals.Base;
using Data.Humans.Employees.Exeptions;
using Data.Services;
using NLog;

namespace Data.Humans.Employees
{
    public abstract class Employee<T>: Human
    where T:Animal
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        protected FoodFactory FoodFactory { get; }
        
        public ReadOnlyObservableCollection<T> Animals { get; }
        
        public double Salary { get; protected set; }

        public Employee(ReadOnlyObservableCollection<T> animals, FoodFactory foodFactory) 
        {
            FoodFactory = foodFactory ?? throw new ArgumentNullException(nameof(foodFactory));
            Animals = animals ?? throw new ArgumentNullException(nameof(animals));

            foreach (var animal in animals)
                animal.WantEatEvent+=AnimalOnWantEatEvent;

            ((INotifyCollectionChanged)animals).CollectionChanged += Animals_CollectionChanged;
        }

        private void AnimalOnWantEatEvent(object? sender, EventArgs e)
        {
            var animal = (Animal)sender;
            Logger.Info($"The {Name} has fed the {animal.Name}");
            var food = FoodFactory.GetFood(animal);
            animal.Eat(food);
        }

        private void Animals_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach(Animal animal in e.NewItems)
                            animal.WantEatEvent += AnimalOnWantEatEvent;
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (Animal animal in e.OldItems)
                        animal.WantEatEvent -= AnimalOnWantEatEvent;
                    break;
            }
        }

        public void TakeMoney(double money)
        {
            if (Salary != money)
                throw new InvalidSalaryException("Wrong salary amount");
        }
    }
}