using Data.Animals.Base;

namespace Data.Animals.Herbivores
{
    public sealed class Goat: Herbivore
    {
        public Goat()
        {
            Name = "Goat";
        }
        public override void Eat(object food)
        {
            throw new System.NotImplementedException();
        }
    }
}