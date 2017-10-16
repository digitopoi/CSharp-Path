using System;
using System.Collections.Generic;
namespace Grades
{
    public class GradeBook
    {
        //  Fields
        private List<float> grades;
        public string Name;

        //  Constructors
        public GradeBook()
        {
            grades = new List<float>();
        }

        //  Methods
        public void AddGrade(float grade)
        {
            grades.Add(grade);
        }

        public GradeStatistics ComputeStatistics()
        {
            GradeStatistics stats = new GradeStatistics();

            float sum = 0;

            foreach(float grade in grades)
            {
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;
            }

            stats.AverageGrade = sum / grades.Count;

            return stats;
        }
    }
}
