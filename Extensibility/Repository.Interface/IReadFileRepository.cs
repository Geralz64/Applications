using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IReadFileRepository<T>
    {
        //void ReadFile();
        //bool ValidateFile(string filePath);
        //IEnumerable<string> FilesToProcess(string filePath);
        string RemoveSpecialCharacters(string item);

        //IEnumerable<string> FilesWithRecordCount(string filePath, string fileExtension);
        //Going to present each file plus the amount 
        //of records for each file to help keep track of the amount of records processed

        //Record in each file and present it
        /*
         * 
         * Count each record in each file
         * Present the above information
         * Make a list of the files
         * Validate if file was already processed
         * Delete the file 
         * 
         */



    }
}
