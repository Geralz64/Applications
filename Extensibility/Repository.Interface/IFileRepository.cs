using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace Repository.Interface
{
    public interface IFileRepository<T>
    {
   
       IEnumerable<T> ReadFile();
       void CreateFile();

        bool ValidateFile(string filePath);

        void BackupFile(string fromPath, string toPath);

    }
}
