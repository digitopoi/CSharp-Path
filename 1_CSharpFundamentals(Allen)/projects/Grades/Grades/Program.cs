using System;
using System.Speech.Synthesis;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            //SpeechSynthesizer synth = new SpeechSynthesizer();
            //synth.Speak("Hello! This is the grade book program!");

            GradeBook book = new GradeBook();

            book.NameChanged = OnNameChanged;

            book.Name = "Scott's Grade Book";
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);

            GradeStatistics stats = book.ComputeStatistics();
            Console.WriteLine(book.Name);
            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest", (int)stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);
        }

        static void OnNameChanged(object sender, NameChangedEventArgs args) => Console.WriteLine($"Grade book changing name from {args.ExistingName} to {args.NewName}");

        static void WriteResult(string description, int result) => Console.WriteLine($"{description}: {result}");

        static void WriteResult(string description, float result) => Console.WriteLine($"{description}: {result:F2}");
    }
}
