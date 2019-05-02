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
    public class RepositoryCSV<T> : IDataFileRepository<T> //Make it the read class

    {
        private static string FileLocation { get; set; }
        private static bool HasHeader { get; set; }
        private static string Delimiter { get; set; }
        //private List<T> Items { get; set; }


        public RepositoryCSV(string _fileName, string _fileLocation, bool _hasHeader, string _delimiter, List<T> _items)
        {
            FileLocation = _fileLocation;
            HasHeader = _hasHeader;
            Delimiter = _delimiter;
            //Items = _items;
        }

        public IEnumerable<T> ReadFile()
        {

            using (var reader = new StreamReader(FileLocation + FileName))
            {
                using (var csv = new CsvReader(reader))
                {

                    csv.Configuration.HasHeaderRecord = HasHeader;
                    var member = csv.GetRecords<T>();

                    return member;
                }

            }

        }

        //public void CreateFile()
        //{
        //    string fileFullPath = FileLocation + FileName;

        //    using (var writer = new StreamWriter(fileFullPath))
        //    {
        //        using (var csv = new CsvWriter(writer))
        //        {
        //            csv.Configuration.HasHeaderRecord = HasHeader;
        //            csv.Configuration.Delimiter = Delimiter;

        //            csv.WriteRecords(Items);
        //        }
        //    }
        //}

        public bool ValidateFile(string filePath)
        {

            /*
             What do I want to validate?

            -The fields are in the correct format as the ones in the layout
            -No special characters in the lines
            -Dates for example are in the correct format
            -If its a txtfile that the record has the correct length
                       
             */



            return true;


        }

        public List<FileInfo> FilesWithInfo(string filePath, string fileExtension)
        {

            var filesToProcess = Utilities.Utilities.FilesToProcess(filePath, fileExtension);

            var filesWithInfo = new List<FileInfo>();


            foreach (var file in filesToProcess)
            {
                var fileWithInfo = new FileInfo();

                fileWithInfo.FileName = file;
                fileWithInfo.FileCount = ReadFile().Count();

                filesWithInfo.Add(fileWithInfo);

            }

            return filesWithInfo;


        }

        public IEnumerable<string> FileWithInfo(IEnumerable<string> files)
        {
            throw new NotImplementedException();
        }


        private static int RecordCoundInFile()
        {






            return 0;
        }
    }


    public class FileInfo
    {

        public string FileName { get; set; }

        public int FileCount { get; set; }
    }


}
