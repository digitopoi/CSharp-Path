using System;
using System.IO;
using System.Speech.Synthesis;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            //SpeechSynthesizer synth = new SpeechSynthesizer();
            //synth.Speak("Hello! This is the grade book program!");
            //book.NameChanged = OnNameChanged;
            //book.Name = "Scott's Grade Book";
            //Console.WriteLine(book.Name);

            GradeBook book = new GradeBook();
            GetBookName(book);
            AddGrades(book);
            SaveGrades(book);
            WriteResults(book);
        }

        private static void WriteResults(GradeBook book)
        {
            GradeStatistics stats = book.ComputeStatistics();
            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest", (int)stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);
            WriteResult(stats.Description, stats.LetterGrade);
        }

        private static void SaveGrades(GradeBook book)
        {
            using (StreamWriter outputFile = File.CreateText("grades.txt"))
            {
                book.WriteGrades(outputFile);
            }
        }

        private static void AddGrades(GradeBook book)
        {
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);
        }

        private static void GetBookName(GradeBook book)
        {
            try
            {
                Console.WriteLine("Enter a name");
                book.Name = Console.ReadLine();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Something went wrong.");
            }
        }

        //static void OnNameChanged(object sender, NameChangedEventArgs args) => Console.WriteLine($"Grade book changing name from {args.ExistingName} to {args.NewName}");

        static void WriteResult(string description, int result) => Console.WriteLine($"{description}: {result}");
        static void WriteResult(string description, string result) => Console.WriteLine($"{description}: {result}");
        static void WriteResult(string description, float result) => Console.WriteLine($"{description}: {result:F2}");
    }
}
