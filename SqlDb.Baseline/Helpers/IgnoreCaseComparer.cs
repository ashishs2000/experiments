using System;
using System.Collections.Generic;
using System.IO;

namespace SqlDb.Baseline.Helpers
{
    public class IgnoreCaseComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return x.Equals(y, StringComparison.CurrentCultureIgnoreCase);
        }

        public int GetHashCode(string obj)
        {
            return 0;
        }
    }

    public class FileWriter : IDisposable
    {
        private readonly StreamWriter _logger;
        public FileWriter(string fileName)
        {
            this._logger = new StreamWriter(fileName,false);
            _logger.AutoFlush = true;
        }

        public void WriteLine(string data)
        {
            _logger.WriteLine(data);
        }

        public void Write(string data)
        {
            _logger.Write(data);
        }

        public void NewLine()
        {
            _logger.WriteLine("");
        }

        public void Dispose()
        {
            _logger.Dispose();
        }
    }
}