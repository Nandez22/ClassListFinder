using System.Text.RegularExpressions;
using TextCopy;

namespace GetAnator {
    public class Program {
        public static async Task Main(string[] args) {
            string pattern = @"^https://www\.mnsu\.edu/academics/academic-catalog/all-active-catalogs/.*#CourseList$";
            string address = "";
            bool copy = false;

            while(true) {
                try {
                    Console.WriteLine("Link: ");
                    address = Console.ReadLine();
                    Console.Clear();

                    if(!Regex.IsMatch(address, pattern)) { throw new Exception(); }

                    Console.WriteLine("Copy to clipboard Y/N?");
                    copy = Console.ReadKey().Key == ConsoleKey.Y;
                    Console.Clear();


                    break;
                }
                catch {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Link must be a valid mnsu.edu/academics/academic-catalog link ending in #CourseList");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"WORKING! :)");
            Console.ForegroundColor = ConsoleColor.White;
            if(copy) { Console.WriteLine("- The output will be copied to your clipboard."); }
            string output = await ClassGrabber.GetList(address, copy);

            Console.WriteLine(output);

            if(copy) {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Copied!");
                Console.ForegroundColor = ConsoleColor.White;

                ClipboardService.SetText(output);
            }

        }
    }
}