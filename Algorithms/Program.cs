using System;
using Algorithms.DynamicDemo;
using Algorithms.EntityFrameworkPivot;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //DynamicMain.Instance.Run();

                //var extension = new ExtensionFieldHandler();
                //extension.Demo();

                //var s = new DatabaseQuery();
                //s.Query();

                //var source = @"\\nas\qa\UserContent\performance\EmployeePhotos";
                //var destination = @"\\neogov.net\files\qa\platform\performance\EmployeePhotos";

                //var comparer = new FolderComparer();
                //comparer.CopyTo(source, destination, time => DateTime.Now.AddDays(-10) < time);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.Out.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
