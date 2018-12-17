using EFCoreOptimizer.Commands;
using System;
using System.Text;

namespace EFCoreOptimizer
{
    internal static class Program
    {
        private static void Main()
        {
            PrintOptions();
        }

        private static void PrintOptions()
        {
            PrintIntroText();
            while (true)
            {
                Console.WriteLine();
                Console.Write(@"EF Core Tuto:\>");
                DbCommand command = null;
                var option = Console.ReadLine();

                switch (option.ToLower())
                {
                    case "cls":
                        Console.Clear();
                        break;
                    case "opt":
                        PrintIntroText();
                        break;
                    case "1":
                        command = new QueryToTuneCommand();
                        break;
                    case "x":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Unknown command.");
                        Console.WriteLine();
                        break;
                }
                command?.Run();
            }
        }

        private static void PrintIntroText()
        {
            var sb = new StringBuilder();
            sb.AppendLine()
                .AppendLine(" Options:")
                .AppendLine(" 1 -> Query to improve")
                .AppendLine(" opt -> List the options")
                .AppendLine(" cls -> Clean")
                .AppendLine(" x -> Exit")
                .AppendLine();
            Console.WriteLine(sb.ToString());
        }
    }
}
