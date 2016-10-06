using System;
using System.IO;
using System.Text.RegularExpressions;
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
                    Console.Out.Write($"Creating migration scripts for {database}.......");
                    using (var runner = new DatabaseRunner(configurations, database))
                        runner.Execute();

                    Console.Out.WriteLine("[OK]");
                }
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.Message);
            }
            finally
            {
                Console.Out.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }
    }
}
