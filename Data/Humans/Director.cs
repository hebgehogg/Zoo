using Data.Animals.Base;
using System.Collections.Generic;
using Data.Humans.Employees;
using NLog;
using System.Timers;
using System;
using Data.Humans.Employees.Exeptions;

namespace Data.Humans
{
    public sealed class Director: Human
    {
        private readonly Timer _salaryTimer = new Timer();

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public HerbivoresEmployee[] HerbivoresEmployees { get; }

        public PredatorEmployee[] PredatorsEmployees { get; }

        public Director(PredatorEmployee[] predatorEmployee, HerbivoresEmployee[] herbivoresEmployee)
        {
            HerbivoresEmployees = herbivoresEmployee ?? throw new ArgumentNullException(nameof(herbivoresEmployee));
            PredatorsEmployees = predatorEmployee ?? throw new ArgumentNullException(nameof(predatorEmployee));
            
            Name = "Director";
            _salaryTimer.Interval = 10000;
            _salaryTimer.Elapsed += SalaryTimerOnElapsed;

            _salaryTimer.Start();
        }

        private void SalaryTimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                foreach(var employee in HerbivoresEmployees)
                {
                    Logger.Info($"Salary paid to {employee.Name}");
                    employee.TakeMoney(employee.Salary);
                }
                foreach(var employee in PredatorsEmployees)
                {
                    Logger.Info($"Salary paid to {employee.Name}");
                    employee.TakeMoney(employee.Salary);
                }
            }
            catch (InvalidSalaryException exception)
            {
                Logger.Error(exception);
            }
            catch (Exception exception)
            {
                Logger.Fatal(exception);
                throw;
            }
        }
    }
}