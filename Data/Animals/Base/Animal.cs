using System;
using System.Drawing;
using System.Reflection;
using System.Timers;
using Data.FoodKinds.Base;
using NLog;

namespace Data.Animals.Base
{
    public abstract class Animal
    {
        private readonly Timer  _eatTimer = new Timer();
        
        private readonly Timer _deadTimer = new Timer();
        
        private double _timerInterval;
        
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public event EventHandler WantEatEvent;
        
        public event EventHandler DeadEvent;

        public Point[] View { get; protected set; }
        
        public string Name { get; protected set; }

        public double TimerInterval
        {
            get => _timerInterval;
            protected set
            {
                _timerInterval = value;
                _eatTimer.Interval = _timerInterval;
                _eatTimer.Start();
            }
        }

        protected Animal()
        {
            var rnd = new Random();
            _deadTimer.Interval= rnd.Next(30000, 60000);
            _deadTimer.Elapsed += DeadTimerOnElapsed;
            
            Logger.Info("The animal start behave");
            _eatTimer.Elapsed += EatTimerOnElapsed;
        }

        private void EatTimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            Logger.Info("The "+Name+" wants to eat");
            OnWantEatEvent();
        }
        
        private void DeadTimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            Logger.Info("The " + Name + " died");
            OnDeadEvent();
        }
        
        protected virtual void OnDeadEvent()
        {
            DeadEvent?.Invoke(this, EventArgs.Empty);
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