using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Algorithms.DynamicDemo;
using Algorithms.DynamicExpression;
using DataType = Algorithms.EntityFrameworkPivot.DataType;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                FileImportDemo.Run();
                //new LanguageParser().Run();
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

        public class Contact
        {
            [Required(AllowEmptyStrings = false, ErrorMessage = "First name is required")]
            [StringLength(20, MinimumLength = 5, ErrorMessage = "First name must be between 5 and 20 characters")]
            public string FirstName { get; set; }

            public string LastName { get; set; }
        }

        private void DoSomething()
        {
            Contact contact = new Contact { FirstName = "Armin", LastName = "Zia" };

            ValidationContext context = new ValidationContext(contact, null, null);
            IList<ValidationResult> errors = new List<ValidationResult>();

            if (!Validator.TryValidateObject(contact, context, errors, true))
            {
                //foreach (ValidationResult result in errors)
                //    MessageBox.Show(result.ErrorMessage);
            }
        }
    }

}
