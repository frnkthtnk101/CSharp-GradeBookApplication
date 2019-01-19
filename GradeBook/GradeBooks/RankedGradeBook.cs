using System;
using System.Collections.Generic;
using System.Text;
using GradeBook.Enums;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook: BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException("Rank Grading requires a minimum of 5 students to work.");
            int threshold = (int) Math.Ceiling(Students.Count * .02);
            var GradesInDecendingOrder = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();
            if (GradesInDecendingOrder[threshold - 1] <= averageGrade)
                return 'A';
            else if (GradesInDecendingOrder[(threshold * 2) - 1] <= averageGrade)
                return 'B';
            else if (GradesInDecendingOrder[(threshold * 3) - 1] <= averageGrade)
                return 'C';
            else if (GradesInDecendingOrder[(threshold * 4) - 1] <= averageGrade)
                return 'D';
            return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.Write("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.Write("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
    }
}
