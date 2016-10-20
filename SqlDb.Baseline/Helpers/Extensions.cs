using System;
using System.Collections.Generic;
using System.Data.Entity.Design.PluralizationServices;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;

namespace SqlDb.Baseline.Helpers
{
    public static class Extensions
    {
        private static readonly PluralizationService EnglishService = PluralizationService.CreateService(CultureInfo.GetCultureInfo("en-us"));

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

        public static string AddHeader(this FileWriter writer, string heading)
        {
            var builder = new StringBuilder();
            builder.AppendLine("--".PadRight(50, '#'));
            builder.AppendLine($"-- {heading}");
            builder.AppendLine("--".PadRight(50, '#'));

            var header = builder.ToString();
            writer.Write(header);
            return header;
        }

        public static void LogInfo(this string data)
        {
            LogFile.Info(data);
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