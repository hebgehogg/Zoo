using System;
using Data.Animals.Base;

namespace Data.Services
{
    public class AnimalFactory
    {
        public static AnimalFactory _instance;

        public static AnimalFactory Instance
        {
            get
            {
                if(_instance==null)
                    _instance = new AnimalFactory();
                return _instance;
            }
        }

        private AnimalFactory()
        {
            GetAnimal<Animal>();
        }
        
        public T GetAnimal<T>() where T:Animal
        {
            return Activator.CreateInstance<T>();
        }
    }
}