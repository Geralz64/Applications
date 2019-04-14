using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeBook : GradeTracker
    {
        public GradeBook()
        {
            _name = "Empty";

            grades = new List<float>();

        }


        protected List<float> grades = new List<float>();

        public override IEnumerator GetEnumerator()
        {
            return grades.GetEnumerator();
            
        }

        public override void WriteGrades(TextWriter destination)
        {
            for (int i = 0; i < grades.Count; i++)
            {
                destination.WriteLine(grades[i]);

            }
        }


        public override void AddGrade(float grade)
        {

            grades.Add(grade);

        }

        public override GradeStatistics ComputeStatistics()
        {
            GradeStatistics stats = new GradeStatistics();

            float sum = 0;

            foreach (float grade in grades)
            {

                sum += grade;

            }

            stats.AverageGrade = sum / grades.Count();
            stats.LowestGrade = grades.Min();
            stats.HighestGrade = grades.Max();


            return stats;

        }


    }
}
