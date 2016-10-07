using System;
using System.Collections.Generic;
using System.Data.Entity.Design.PluralizationServices;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;

namespace SqlDb.Baseline.Helpers
{
    public static class Extensions
    {
        private static readonly PluralizationService EnglishService = System.Data.Entity.Design.PluralizationServices.PluralizationService.CreateService(CultureInfo.GetCultureInfo("en-us"));

        public static void Execute(this SqlConnection connection, string query, Action<SqlDataReader> extract)
        {
            using (connection)
            {
                var command = new SqlCommand(query, connection);
                connection.Open();

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    extract(reader);
                }
            }
        }

        public static void AddHeader(this FileWriter writer, string heading)
        {
            writer.WriteLine("".PadRight(50, '-'));
            writer.WriteLine($"-- {heading}");
            writer.WriteLine("".PadRight(50, '-'));
        }

        public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (var item in items)
                action(item);
        }

        public static bool IsPlural(this string word)
        {
            return EnglishService.IsPlural(word);
        }

        public static string Singularize(this string word)
        {
            return EnglishService.Singularize(word);
        }
    }
}