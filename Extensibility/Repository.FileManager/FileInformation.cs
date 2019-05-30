using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensibility
{
    public class FileInformation<T>
    {
        public string FileLocation { get; set; }
        public string FileName { get; set; }
        public bool HasHeader { get; set; }
        public string Delimiter { get; set; }

        public int RecordCount { get; set; }

        public IEnumerable<T> Records { get; set; }


    }
}
