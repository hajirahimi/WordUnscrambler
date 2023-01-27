using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordUnscrambler.Data;

namespace WordUnscrambler.Workers
{
    internal class WordMatcher
    {
        internal List<MatchedWord> Match(string[] scrambledWords, string[] wordslist)
        {
            var matchedWords = new List<MatchedWord>();
            foreach (var scrambledWord in scrambledWords)
            {
                foreach (var word in wordslist)
                {
                    if (scrambledWord.Equals(word,StringComparison.OrdinalIgnoreCase))
                    {
                        matchedWords.Add(BuildMatchedWord(scrambledWord, word));
                    }
                    else
                    {
                        var scrambledWordArray = scrambledWord.ToCharArray();
                        var wordArray=word.ToCharArray();
                        Array.Sort(wordArray); Array.Sort(scrambledWordArray);
                        var sortedScrambledWord = new string(scrambledWordArray);
                        var sortedWord = new string(wordArray);
                        if (sortedScrambledWord.Equals(sortedWord,StringComparison.OrdinalIgnoreCase))
                        {
                            matchedWords.Add(BuildMatchedWord(scrambledWord, word));
                        }
                    }
                }
            }
            return matchedWords;
        }
        private MatchedWord BuildMatchedWord(string scarmbledWord, string word)
        {
            var matchedWord = new MatchedWord
            {
               ScrambledWord = scarmbledWord,
               Word = word
            };
            return matchedWord;
        }
    }
}
