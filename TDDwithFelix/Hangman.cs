using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDwithFelix
{
    public class Hangman
    {
        /* 
         * Set some variables that will be used to play the hangman game and 
         * allow for testing of the various methods.
         */
        private readonly int guessedAlreadyLength = 26;
        private string word { get; set; }
        private int limit { get; set; }
        private bool alreadyGuessed { get; set; }
        private Boolean[] _alreadyGuessed { get; set; }

        public int GuessCount { get; set; }
        public int WrongGuessCount { get; set; }
        
        Boolean [] letterGuessed = null;

        private void ResetGuessedArray()
        {
            for (int i = 0; i < word.Length; i++)
                letterGuessed[i] = false;
            for (int ii = 0; ii < guessedAlreadyLength; ii++)
            {
                _alreadyGuessed[ii] = false;
            }
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
                letterGuessed = new Boolean[word.Length];
                _alreadyGuessed = new Boolean[guessedAlreadyLength];
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

        public bool AlreadyGuessed
        {
            get
            {
                return alreadyGuessed;
            }
            set
            {
                alreadyGuessed = value;
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
            WrongGuessCount++;
            return WrongGuessCount;
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
                if (this.letterGuessed[i])
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
        /// <param name="letterToGuess"></param>
        /// <returns></returns>
        public bool MakeGuess(char letterToGuess)
        {
            letterToGuess = Char.ToLower(letterToGuess);
            bool result = false;

            if (IsValidGuess(letterToGuess))
            {
                for (int characterInWord = 0; characterInWord < word.Length; characterInWord++)
                {
                    if (this.Word[characterInWord] == letterToGuess)
                    {  // find where the letter correctly guessed is in the word
                        letterGuessed[characterInWord] = true;
                        
                        result = true;
                        //return true;
                    }
                    result = false;
                }
            }

            return result;
        }

        public bool MakeAnotherGuess(char letterToGuess)
        {
            letterToGuess = Char.ToLower(letterToGuess);
            bool result = false;
            alreadyGuessed = false;

            if (IsValidGuess(letterToGuess))
            {
                for (int characterInWord = 0; characterInWord < word.Length; characterInWord++)
                {
                    if (this.Word[characterInWord] == letterToGuess)
                    {  // if the letter guessed is correct
                        if (letterGuessed[characterInWord] == true)
                        {
                            alreadyGuessed = true;
                            WrongGuessCount = IncrementWrongGuessCount();
                            return false;
                        }
                        else
                        {
                            letterGuessed[characterInWord] = true;
                            result = true;
                        }
                    }
                }
            }
            return result;
        }

        public int AtoI(char letter)
        {
            int number = letter - 'a';
            return number;
        }
    }
}
