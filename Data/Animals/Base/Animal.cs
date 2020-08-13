using System;
using System.Drawing;
using System.Timers;
using Data.FoodKinds.Base;
using log4net;

namespace Data.Animals.Base
{
    public abstract class Animal
    {
        
        private Timer  _timer = new Timer();
        
        private double _timerInterval;

        private static readonly ILog _log = LogManager.GetLogger(typeof(Animal));
        
        public event EventHandler WantEatEvent;

        public Point[] View { get; protected set; }
        
        public string Name { get; protected set; }

        public double TimerInterval
        {
            get => _timerInterval;
            protected set
            {
                _timerInterval = value;
                _timer.Interval = _timerInterval;
                _timer.Start();
            }
        }

        protected Animal()
        {
            _log.Info("The animal start behave");
            _timer.Elapsed+= TimerOnElapsed;
        }

        private void TimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            _log.Info("The "+Name+" wants to eat");
            OnWantEatEvent();
        }

        public abstract void Eat(Food food);

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