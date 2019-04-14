using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeStatistics
    {
        public float AverageGrade;
         
        public float HighestGrade;
         
        public float LowestGrade;

        public string LetterGrade
        {
            get
            {

                string result;

                if (AverageGrade >= 90)
                {
                    result = "A";

                }
                else if(AverageGrade >= 80)
                {
                    result = "B";

                }
                else if (AverageGrade >= 70)
                {

                    result = "C";
                }
                else if (AverageGrade >= 60)
                {
                    result = "D";

                }
                else
                {
                    result = "F";

                }

                return result;
            }

        }


        public string Description
        {

            get
            {
                string result;

                switch (LetterGrade)
                {
                    case "A":
                        result = "Excellent grade";
                        break;
                    case "B":
                        result = "Good grade";
                        break;
                    case "C":
                        result = "Average grade";
                        break;
                    case "D":
                        result = "Underaverage grade";
                        break;
                    default:
                        result = "Failing grade";
                        break;

                }

                return result;

            }
        }
    }
}
