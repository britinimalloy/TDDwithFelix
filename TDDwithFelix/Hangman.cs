using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDwithFelix
{
    public class Hangman
    {
        // Add some comments here
        public string Word { get; set; }
        public int Limit { get; set; }
        public int Count { get; set; } // Seems vague?
        public int WrongGuessCount { get; set; }

        public bool Foo()
        {
            return false;
        }

        // Why is this a public?
        public string CaseInsensitive(string word)
        {
            return word.ToLower();
        }

        // I like that you are using the "Guess" in your code, perhaps IsValidGuess, rather than IsInWord?
        public bool IsInWord(char character)
        {
            if (Word.Contains(character))
            {
                return true;
            }

            return false;
        }

        public bool GuessLimitReached()
        {
            if (Count >= Limit)
            {
                return true;
            }
            return false;
        }

        public int IncrementWrongGuessCount()
        {
            return WrongGuessCount++;
        }
    }
}
