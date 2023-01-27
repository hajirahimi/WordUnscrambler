using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using WordUnscrambler.Workers;
using WordUnscrambler.Data;

namespace WordUnscrambler
{
    class Program
    {
        private static readonly FileReader _fileReader = new FileReader();
        private static readonly WordMatcher _wordMatcher = new WordMatcher();
        private const string WordslistFileName = "wordsLists.txt";

        static void Main(string[] args)
        {
            bool continueWordUnscrambled = true;
            do
            {
                Console.WriteLine("Enter M for manual entry or F for a file name: ");
                var userInput = Console.ReadLine() ?? string.Empty;
                switch (userInput.ToLower())
                {
                    case "m":
                        Console.WriteLine("Enter words comma separated: ");
                        UnscramblerTyped();
                        break;
                    case "f":
                        Console.WriteLine("Enter file name: ");
                        UnscramblerFile();
                        break;
                    default:
                        Console.WriteLine("User input is not recognized!");
                        break;
                }
                var continueProgram = string.Empty;
                do
                {
                    Console.WriteLine("Continue the program? Y/N");
                    continueProgram = Console.ReadLine() ?? string.Empty;
                } while (!continueProgram.ToLower().Equals("y") && !continueProgram.ToLower().Equals("n"));
                if (continueProgram.ToLower().Equals("n"))
                { continueWordUnscrambled = false; }
            } while (continueWordUnscrambled);
        }

        private static void UnscramblerTyped ()
        {
            string manualInput = Console.ReadLine() ?? string.Empty;
            string[] scrabledWords = manualInput.Split(',');
            DisplayMatched(scrabledWords);
        }

        private static void UnscramblerFile()
        {
            string fileName = Console.ReadLine() ?? string.Empty;
            string[] scrabledWords = _fileReader.Read(fileName);
            DisplayMatched(scrabledWords);
        }
        private static void DisplayMatched(string[] scrabledWords)
        {
            string[] wordslist = _fileReader.Read(WordslistFileName);
            List<MatchedWord> matchedWords = _wordMatcher.Match(scrabledWords, wordslist);
            if (matchedWords.Any())
            {
                foreach (var matchedWord in matchedWords)
                {
                    Console.WriteLine("{0}is matched with {1}", matchedWord.ScrambledWord, matchedWord.Word);
                }
            }
            else
            {
                Console.WriteLine("there is no matched");
            }
        }
    }
}
