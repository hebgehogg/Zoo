using Data.Animals.Base;

namespace Data.Animals.Predators
{
    public sealed class Lion : Predator
    {
        public Lion()
        {
            Name = "Lion";
        }

        public override void Eat(object food)
        {
            throw new System.NotImplementedException();
        }
    }
}