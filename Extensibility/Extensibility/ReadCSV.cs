using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Interface;
using Utilities;

namespace Extensibility
{
    public class ReadCSV<T> : IReadFileRepository<T> //Make it the read class

    {
        private static string FileLocation { get; set; }
        private static bool HasHeader { get; set; }
        private static string Delimiter { get; set; }
        public int RecordCount { get; set; }


        public ReadCSV(
           string _fileLocation, bool _hasHeader , string _delimiter

            )
        {
            FileLocation = _fileLocation;
            HasHeader = _hasHeader;
            Delimiter = _delimiter;

        }


        
        public IEnumerable<T> ReadFile()
        {

            using (var reader = new StreamReader(FileLocation))
            {
                using (var csv = new CsvReader(reader))
                {
                    csv.Configuration.HasHeaderRecord = HasHeader;

                    var records = csv.GetRecords<T>().ToList();

                    return records;
                }

            }

        }

        public string RemoveSpecialCharacters(string item)
        {

            item = item.Replace("ñ", "n");
            item = item.Replace("Ñ", "N");
            item = item.Replace("'", "");
            item = item.Replace(",", "");
            return item;


        }

        public IEnumerable<string> FilesToProcess(string filePath)
        {

            var filesToProcess = Utilities.Utilities.FilesToProcess(filePath, "*.csv");

            return filesToProcess;

        }
        



        public void ShowFilesWithInfo(List<FileInfo> files)
        {

            foreach (var file in files)
            {
                Console.Write($"Name: {file.FileName} Count: {file.FileCount}");
            }

        }


        public int GetFileRecordCount(IEnumerable<T> file)
        {

            int recordCount = file.Count();


            return recordCount;
        }



    }


    public class FileInfo
    {

        public string FileName { get; set; }

        public int FileCount { get; set; }
    }


}
