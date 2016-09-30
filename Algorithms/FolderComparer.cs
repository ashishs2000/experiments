using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Algorithms.EntityFrameworkPivot;

namespace Algorithms
{
    public class FolderComparer
    {
        private readonly string _outputFile;
        public FolderComparer(string outputFile = null)
        {
            _outputFile = outputFile ?? "MissingFiles.txt";
        }

        public List<FileInfo> GetMissingFiles(string sourceFolder, string destinationFolder, Func<DateTime, bool> modified = null)
        {
            if (modified == null)
                modified = time => true;

            Console.Out.Write("Getting source and destination information...");
            var sourceFiles = new DirectoryInfo(sourceFolder).GetFiles("*",SearchOption.AllDirectories).Where(e=>modified(e.CreationTime)).OrderBy(p=>p.CreationTime);
            var destinationFiles = new DirectoryInfo(destinationFolder).GetFiles("*", SearchOption.AllDirectories).Where(e => modified(e.CreationTime));
            Console.Out.WriteLine("[Done]\n");

            var missingFiles = new List<FileInfo>();
            foreach (var sourceFile in sourceFiles)
            {
                var destinationFileExists = destinationFiles.Any(p => p.Name == sourceFile.Name);
                if (destinationFileExists)
                    continue;
                missingFiles.Add(sourceFile);
            }

            using (var writer = new StreamWriter(_outputFile,true))
            {
                writer.Write("### Missing Files ###\n");
                foreach (var sourceFile in missingFiles.OrderBy(p => p.CreationTime))
                {
                    writer.Write($"{sourceFile.FullName} - {sourceFile.CreationTime}\n");
                }
            }
            return missingFiles;
        }

        public void CopyTo(string sourceFolder, string destinationFolder, Func<DateTime, bool> modified = null)
        {
            var files = GetMissingFiles(sourceFolder, destinationFolder, modified);
            if (files == null || !files.Any())
            {
                Console.Out.WriteLine("No files to copy");
                return;
            }

            var totalFiles = files.Count;
            var counter = 1;

            Console.Out.WriteLine($"Start copying files to {destinationFolder}");
            foreach (var fileInfo in files)
            {
                Console.Out.Write($"[{counter}/{totalFiles}] Copying file {fileInfo.FullName} ...");

                var destination = Path.Combine(destinationFolder, fileInfo.Directory.Name);
                if (!Directory.Exists(destination))
                    Directory.CreateDirectory(destination);

                var destinationFile = Path.Combine(destination, fileInfo.Name);
                if (File.Exists(destinationFile))
                {
                    Console.Out.WriteLine("[Skipped]");
                    continue;
                }
                try
                {
                    File.Copy(fileInfo.FullName, destinationFile, false);
                    Console.Out.WriteLine("[Copied]");
                }
                catch (Exception ex)
                {
                    Console.Out.WriteLine("[Failed]");
                    Console.Out.WriteLine($"Error - {ex.Message}");
                }
                counter = counter + 1;
            }
        }
    }
}