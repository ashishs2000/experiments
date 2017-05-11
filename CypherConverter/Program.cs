using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using CypherConverter.Generated;
using CypherConverter.ImportTool;
using Neogov.Common;

namespace CypherConverter
{
    
    class Program
    {
        private const string PLAIN_IDS_FILE_NAME = "PlainIDs.txt";
        private const string ENCRYPTED_IDS_FILE_NAME = "EncryptedIDs.txt";

        static void Main(string[] args)
        {
            var test = new Tester();
            test.Start();

            return;
            if (File.Exists(PLAIN_IDS_FILE_NAME))
            {
                var encryptedIds = new StringBuilder();
                var lines = File.ReadAllLines(PLAIN_IDS_FILE_NAME);
                foreach (var line in lines)
                {
                    if(string.IsNullOrEmpty(line))
                        continue;

                    int id;
                    if(Int32.TryParse(line,out id))
                        encryptedIds.AppendLine(EncryptionUtility.EncryptForURL(id));
                }

                if (lines.Length > 1)
                {
                    if(File.Exists(ENCRYPTED_IDS_FILE_NAME))
                        File.Delete(ENCRYPTED_IDS_FILE_NAME);

                    var output = File.Create(ENCRYPTED_IDS_FILE_NAME);
                    using (var writer = new StreamWriter(output))
                    {
                        writer.WriteLine(encryptedIds.ToString());
                    }                    
                }
            }
            else
            {
                Console.Out.WriteLine("Input file {0} doesn't exists", PLAIN_IDS_FILE_NAME);
            }
        }
    }
}
