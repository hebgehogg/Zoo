using Data.Animals.Base;

namespace Data.Animals.Predators
{
    public sealed class Fox: Predator
    {
        public Fox()
        {
            Name = "Fox";
        }
        public override void Eat(object food)
        {
            throw new System.NotImplementedException();
        }
    }
}