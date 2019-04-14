using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeBook
    {
        public GradeBook()
        {
            _name = "Empty";

            grades = new List<float>();

        }



        List<float> grades = new List<float>();

        private string _name;

        public void WriteGrades(TextWriter destination)
        {
            for (int i = 0; i < grades.Count; i++)
            {
                destination.WriteLine(grades[i]);

            }
        }

        public NameChangedDelegate NameChanged;

        public string Name
        {
            get
            {

                return _name;
            }

            set
            {

                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty");

                }

                if (_name != value)
                {
                    NameChangedEventArgs args = new NameChangedEventArgs();

                    args.ExistingName = _name;
                    args.NewName = value;

                    NameChanged(this, args);
                }

                _name = value;


            }
        }

        public void AddGrade(float grade)
        {

            grades.Add(grade);

        }

        public GradeStatistics ComputeStatistics()
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
