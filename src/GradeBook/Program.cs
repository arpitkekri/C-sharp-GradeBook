using System;
namespace GradeBook
{
    class Program 
    {
        static void Main(string[] args)
        {
            // var p = new Program();
            // p.Main(); -> Gives error because static // Program.Main(args); -> right

            IBook book = new DiskBook("Arpit's Grade Book");
            book.GradeAdded += OnGradeAdded;
            // book.GradeAdded -= OnGradeAdded;
            // book.GradeAdded = null; // error because it is event
            // Console.WriteLine(typeof(string).Assembly.ImageRuntimeVersion);
            EnterGrades(book);
            var stats = book.GetStatistics();
            Console.WriteLine($"For the book named {book.Name}");
            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The average grade is {stats.Average}");
            Console.WriteLine($"The letter grade is {stats.Letter}");
        }
        
        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                    // book.AddGrade('A'); 
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added");
        }
    }
}
