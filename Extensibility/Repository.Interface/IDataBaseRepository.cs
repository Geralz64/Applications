using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IDataBaseRepository
    {
        void UpdateRecord();

        void InsertData();

        IEnumerable<object> GetData();

    }
}
