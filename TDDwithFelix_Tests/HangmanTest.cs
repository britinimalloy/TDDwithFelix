using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDwithFelix;

namespace TDDwithFelix_Tests
{
    [TestClass]
    public class HangmanTest
    {
        [TestMethod]
        public void TestMethod()
        {
            Hangman h = new Hangman();
            Assert.IsFalse(h.Foo());
        }

        Hangman h = new Hangman();
        // Create:
        string expectedWord = "hello";
        int expectedWrongCount = 4;

        [TestInitialize]
        public void SetupSimpleWord()
        {
            h.Word = this.expectedWord;
            h.Limit = 7;
        }

        // 1) need to be able to set a word 
        [TestMethod]
        public void TestWord()
        {
            // Asserts - that it's the word we set
            Assert.IsTrue(this.expectedWord == h.Word);
        }

        [TestMethod]
        public void TestWordNot()
        {
            // Asserts - that it's the word we set
            Assert.IsFalse(h.Word == "cat");
        }

        /// <summary>
        /// Testing to make sure the word set can be recognized
        /// as the correct word, regardless of case.
        /// </summary>
        [TestMethod]
        public void TestWordCase()
        {
            h.Word = "Cat";

            // Asserts - that it's the word we set
            Assert.IsTrue(h.Word == "cat");
        }

        /// <summary>
        /// Testing to make sure a correct letter guess is 
        /// returned as a correct guess.
        /// </summary>
        [TestMethod]
        public void TestIfInWord()
        {
            // Asserts:
            Assert.IsTrue(h.IsValidGuess('l'));
        }

        /// <summary>
        /// Testing to ensure the limit of guesses has not 
        /// gone over the expected count.
        /// </summary>
        [TestMethod]
        public void TestIfGuess6ReachedLimit()
        {
            h.GuessCount = 6;

            // Asserts:
            Assert.IsFalse(h.GuessLimitReached());
        }

        /// <summary>
        /// Testing to make sure that when we have 3 wrong 
        /// guesses already, and guess incorrectly again, that
        /// the count of incorrect guesses increments by 1.
        /// </summary>
        [TestMethod]
        public void TestWrongGuessCountIncremented()
        {
            h.WrongGuessCount = 3;

            h.IncrementWrongGuessCount();

            // Asserts:
            Assert.IsTrue(expectedWrongCount == h.WrongGuessCount);
        }

        // 3) Limit on the number of guesses
        //     has user guessed them all
        [TestMethod]
        public void TestIfGuess7ReachedLimit()
        {
            h.GuessCount = 7;

            // Asserts:
            Assert.IsTrue(h.GuessLimitReached());
        }

        // How about a method which returns '_' for an unguessed location in the word, and the letter for a guessed one?
        [TestMethod]
        public void TestUnderscores()
        {
            String result = h.Guessed();

            Assert.AreEqual(String.CompareOrdinal(result, "_____"),0);
        }

        /// <summary>
        /// Testing to see if a correct letter guess shows the 
        /// expected correct visual representation of the word
        /// </summary>
        [TestMethod]
        public void TestGuess()
        {
            h.MakeGuess('l');

            String result = h.Guessed();

            Assert.AreEqual(String.CompareOrdinal(result, "__ll_"), 0);
        }

        /// <summary>
        /// Testing to make sure a wrong letter guess shows all
        /// underscores for the visual representation of the 
        /// word
        /// </summary>
        [TestMethod]
        public void TestWrongGuess()
        {
            h.MakeGuess('q');

            String result = h.Guessed();

            Assert.AreEqual(String.CompareOrdinal(result, "_____"), 0);
        }

        /// <summary>
        /// Test whether or not a capital letter is recognized
        /// as a correct guess
        /// </summary>
        [TestMethod]
        public void TestCapitalGuess()
        {
            h.MakeGuess('L');

            String result = h.Guessed();

            Assert.AreEqual(String.CompareOrdinal(result, "__ll_"), 0);
        }

        /// <summary>
        /// This method tests to make sure that when we guess
        /// a correct letter, we get the expected true result.
        /// </summary>
        [TestMethod]
        public void TestMakeGuessTrue()
        {
            Assert.IsTrue(h.MakeGuess('L'));
        }

        /// <summary>
        /// This test method tests whether we get the expected
        /// false when we guess a letter that is not contained
        /// </summary>
        [TestMethod]
        public void TestMakeGuessFalse()
        {
            Assert.IsFalse(h.MakeGuess('Q'));
        }

        /// <summary>
        /// Test if for a given word, we can get the length,
        /// set that as the guess count limit
        /// </summary>
        [TestMethod]
        public void TestGetLimit()
        {
            h.Limit = 0;
            h.Word = "hello";

            Assert.AreEqual(h.Word.Length, h.Limit);
        }
    }
}
