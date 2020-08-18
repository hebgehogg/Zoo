using System;
using System.Reflection;
using NLog;

namespace Zoo
{
    internal sealed class Program
    {

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        
        static void Main(string[] args)
        {
            var zoo = Zoo.GetInstance;

            Console.ReadKey();
        }

        static Program()
        {
            ConfigurationLogin();   
        }
        
        
        private static void ConfigurationLogin()
        {
            var config = new NLog.Config.LoggingConfiguration();
            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = "log.txt" };
            var logconsole = new NLog.Targets.ConsoleTarget("logconsole");
            config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);
            NLog.LogManager.Configuration = config;
        }
    }
}