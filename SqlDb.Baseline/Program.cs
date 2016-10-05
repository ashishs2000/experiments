using System;
using SqlDb.Baseline.Configurations;

namespace SqlDb.Baseline
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var configurations = new AppConfiguration();
                foreach (var database in configurations.Databases)
                {
                    using (var runner = new DatabaseRunner(configurations, database))
                        runner.Execute();
                }
            }
            catch(Exception ex)
            {
                Console.Out.WriteLine(ex.Message);
            }
        }
    }
}
