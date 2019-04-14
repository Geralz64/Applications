using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class ThrowAwayGradeBook : GradeBook
    {

        public override GradeStatistics ComputeStatistics()
        {

            float lowest = grades.Min();

            grades.Remove(lowest);

            return base.ComputeStatistics();
        }
    }
}
 