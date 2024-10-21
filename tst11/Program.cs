
using System.Text.RegularExpressions;

class test11
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

       
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();

        
        Console.Write("Enter a date with the standard date format (dd/mm/yyyy: ");
        string date = Console.ReadLine();

        
        if (!Regex.IsMatch(date, @"^(0[1-9]|1[0-2])/(0[1-9]|[12][0-9]|3[01])/\d{4}$"))
        {
            Console.WriteLine("you have entered an invlaid date format....please try again later.");
            return;
        }

        if (DateTime.TryParse(date, out DateTime dateBrought))
        {
            DateTime today = DateTime.Now;
            int age = today.Year - dateBrought.Year;

            if (dateBrought > today.AddYears(-age))
            {
                age--;
            }

            Console.WriteLine($"Your age is: {age} years.");

            string file = "user_info.txt";
            using (StreamWriter sw = File.CreateText(file))
            {
                sw.WriteLine($"I am {age} years old.");
            }

            
            string content = File.ReadAllText(file);
            Console.WriteLine(content);
        }
        else
        {
            Console.WriteLine(" ");
        }

        
        Console.Write("Enter a directory: ");
        string dir = Console.ReadLine();

        if (Directory.Exists(dir))
        {
            Console.WriteLine("The fsles in the directory are: ");
            List<string> files = new List<string>(Directory.EnumerateFiles(dir));
            foreach (string file in files)
            {
                Console.WriteLine(file);
            }
        }
        else
        {
            Console.WriteLine("Directory does not exist.");
        }

       
        Console.Write("Enter any string: ");
        string lastString = Console.ReadLine();
        Console.WriteLine(lastString.ToUpper());

        
        GC.Collect();
    }
}
