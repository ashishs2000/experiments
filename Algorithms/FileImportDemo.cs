using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;

namespace Algorithms
{
    public class FileImportDemo
    {
        public static void Run()
        {
            try
            {
                //https://joshclose.github.io/CsvHelper/#getting-started
                var file = @"C:\temp\test.txt";
                // Write(file);


                var textReader = new FileStream(file, FileMode.Open);
                var csvConfiguration = new CsvConfiguration();
                csvConfiguration.HasHeaderRecord = true;

                //csvConfiguration.AutoMap<EmployeeCsvMap>();
                csvConfiguration.RegisterClassMap(new EmployeeCsvMap(1,2,3,4,0));

                var csv = new CsvReader(new StreamReader(textReader), csvConfiguration);
                var employees = csv.GetRecords<EmployeeCsv>().ToList();

                //Console.Out.WriteLine(employees.Count());
                //while (csv.Read())
                //{
                //    var employee = csv.GetRecord<EmployeeCsv>();

                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static void Write(string file)
        {
            var employees = new  List<EmployeeCsv>();
            for (int i = 0; i < 100000; i++)
            {
                employees.Add(new EmployeeCsv
                {
                    Id = $"{i}",
                    EmployeeNumber = $"EN-{i + 1}",
                    FirstName = $"FN{i}",
                    LastName = $"LN{i}",
                    Age = $"{i}",
                });
            }

            var stream = new FileStream(file, FileMode.OpenOrCreate);
            using (var csvWriter = new CsvWriter(new StreamWriter(stream)))
                csvWriter.WriteRecords(employees);

        }
    }

    public sealed class EmployeeCsvMap : CsvClassMap<EmployeeCsv>
    {
        public EmployeeCsvMap(params string[] fieldNames)
        {
            Map(m => m.EmployeeNumber).Name(fieldNames[0]);
            Map(m => m.FirstName).Name(fieldNames[1]);
            Map(m => m.LastName).Name(fieldNames[2]);
            Map(m => m.Age).Name(fieldNames[3]);
            Map(m => m.Id).Name(fieldNames[4]);
        }

        public EmployeeCsvMap(params int[] fieldIndex)
        {
            Map(m => m.EmployeeNumber).Index(fieldIndex[0]);
            Map(m => m.FirstName).Index(fieldIndex[1]);
            Map(m => m.LastName).Index(fieldIndex[2]);
            Map(m => m.Age).Index(fieldIndex[3]);
            Map(m => m.Id).Index(fieldIndex[4]);
        }
    }


    public class EmployeeCsv
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string EmployeeNumber { get; set; }

        //public int Idd => Convert.ToInt32(Id);

    }
}