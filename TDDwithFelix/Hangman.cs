using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDwithFelix
{
    public class Hangman
    {
        public string Word { get; set; }
        public int Limit { get; set; }
        public int Count { get; set; }
        public int WrongGuessCount { get; set; }

        public bool Foo()
        {
            return false;
        }

        public string CaseInsensitive(string word)
        {
            return word.ToLower();
        }

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
