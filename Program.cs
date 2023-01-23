using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool continueWordUnscrambled = true;
            do
            {
                Console.WriteLine("Enter M for manal or F for a file:");
                var userInput = Console.ReadLine() ?? string.Empty;
                switch (userInput.ToLower())
                {
                    case "m":
                        Console.WriteLine("Enter words comma separated:");
                        UnscramblerTyped();
                        break;
                    case "f":
                        Console.WriteLine("Enter file name:");
                        UnscramblerFile();
                        break;
                    default:
                        Console.WriteLine("User input is not recognized!");
                        break;
                }
                var continueProgram = string.Empty;
                do
                {
                    Console.WriteLine("Enter Y to continue the program or N to stop the program.");
                    continueProgram = Console.ReadLine() ?? string.Empty;
                } while (!continueProgram.ToLower().Equals("y") && !continueProgram.ToLower().Equals("n"));
                if (continueProgram.ToLower().Equals("n"))
                {continueWordUnscrambled = false;}
            } while (continueWordUnscrambled);
        }

        static void UnscramblerFile()
        {
            //throw new NotImplementedException();
        }
        static void UnscramblerTyped()
        {
            //throw new NotImplementedException();
        }
    }
}
