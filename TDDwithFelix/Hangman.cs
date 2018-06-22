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
        private string word { get; set; }
        private char[] lettersGuessed { get; set; }
        private char[] letterPlacement { get; set; }
        private int limit { get; set; }

        public int GuessCount { get; set; } // Seems vague?
        public int WrongGuessCount { get; set; }

        Boolean [] guessedCorrectly = null;

        private void ResetGuessedArray()
        {
            for (int i = 0; i < word.Length; i++)
                guessedCorrectly[i] = false;
        }

        public string Word
        {
            get
            {
                return word;
            }
            set
            {
                word = CaseInsensitive(value);
                guessedCorrectly = new Boolean[word.Length];
                ResetGuessedArray();
            }
        }

        public int Limit
        {
            get
            {
                if (limit == 0)
                {
                    limit = Word.Length;
                }
                return limit;
            }
            set
            {
                limit = value;
            }
        }

        public bool Foo()
        {
            return false;
        }

        private string CaseInsensitive(string word)
        {
            return word.ToLower();
        }

        public bool IsValidGuess(char character)
        {
            if (Word.Contains(character))
            {
                return true;
            }

            return false;
        }

        public bool GuessLimitReached()
        {
            if (GuessCount >= Limit)
            {
                return true;
            }
            return false;
        }

        public int IncrementWrongGuessCount()
        {
            return WrongGuessCount++;
        }

        /// <summary>
        /// This method is setting up a string builder that will either
        /// show the correct letter in the proper place when it's been
        /// correctly guessed, or an '_' if it has not.
        /// </summary>
        /// <returns></returns>
        public string Guessed()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < this.Word.Length; i++)
            {
                if (this.guessedCorrectly[i])
                    sb.Append(this.Word[i]);
                else
                    sb.Append('_');
            }
            return sb.ToString();
        }

        /// <summary>
        /// This method returns a true (and sets the character in Word's 
        /// corresponding array to true for having been guessed)
        /// </summary>
        /// <param name="guess"></param>
        /// <returns></returns>
        public bool MakeGuess(char guess)
        {
            guess = Char.ToLower(guess);
            bool result = false;

            for (int i = 0; i < word.Length; i++)
            {
                if (this.Word[i] == guess )
                {
                    guessedCorrectly[i] = true;
                    result = true;
                }
            }
            return result;
        }

    }
}
