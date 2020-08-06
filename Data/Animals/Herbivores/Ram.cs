using Data.Animals.Base;

namespace Data.Animals.Herbivores
{
    public sealed class Ram: Herbivore
    {
        public Ram()
        {
            Name = "Ram";
        }
        public override void Eat(object food)
        {
            throw new System.NotImplementedException();
        }
    }
}