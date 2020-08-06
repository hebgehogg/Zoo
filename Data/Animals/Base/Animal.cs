using System.Drawing;

namespace Data.Animals.Base
{
    public abstract class Animal
    {
        public Point[] View { get; protected set; }
        public string Name { get; protected set; }

        public abstract void Eat(object food);
    }
}