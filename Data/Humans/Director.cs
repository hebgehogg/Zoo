using Data.Animals.Base;
using System.Collections.Generic;
using Data.Humans.Employees;
using NLog;
using System.Timers;
using System;

namespace Data.Humans
{
    public sealed class Director: Human
    {
        private readonly Timer _salaryTimer = new Timer();

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public Employee<Animal>[] HerbivoresEmployees { get; }

        public Employee<Animal>[] PredatorsEmployees { get; }

        public Director(PredatorEmployee[] predatorEmployee, HerbivoresEmployee[] herbivoresEmployee)
        {
            if (predatorEmployee == null)
                throw new ArgumentNullException(nameof(predatorEmployee));
            if (herbivoresEmployee == null)
                throw new ArgumentNullException(nameof(herbivoresEmployee));

            Name = "Director";
            _salaryTimer.Interval = 10000;
            _salaryTimer.Elapsed += SalaryTimerOnElapsed;

            HerbivoresEmployees = herbivoresEmployees;

            PredatorsEmployees = predatorEmployee;

            _salaryTimer.Start();
        }

        private void SalaryTimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            foreach(var employee in Employees)
            {
                Logger.Info($"Salary paid to {employee.Name}");
                employee.TakeMoney(employee.Salary);
            }
        }
    }
}