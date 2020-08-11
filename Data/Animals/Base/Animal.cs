using System;
using System.Drawing;
using Data.FoodKinds.Base;

namespace Data.Animals.Base
{
    public abstract class Animal
    {
        public event EventHandler WantEatEvent;
        
        public Point[] View { get; protected set; }
        
        public string Name { get; protected set; }

        protected void EatInternal(Food food)
        {
            food.Dispose();
        }

        protected virtual void OnWantEatEvent()
        {
            WantEatEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}