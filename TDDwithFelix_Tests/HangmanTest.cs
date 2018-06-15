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
        string expectedWord = "Hello";
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

        [TestMethod]
        public void TestWordCase()
        {
            h.Word = "Cat";

            h.Word = h.CaseInsensitive(h.Word);

            // Asserts - that it's the word we set
            Assert.IsTrue(h.Word == "cat");
        }

        // 2) Is character in the word? 
        [TestMethod]
        public void TestIfInWord()
        {
            // Asserts:
            Assert.IsTrue(h.IsInWord('l'));
        }

        // 3) Limit on the number of guesses 
        [TestMethod]
        public void TestIfGuess6ReachedLimit()
        {
            h.Count = 6;

            // Asserts:
            Assert.IsFalse(h.GuessLimitReached());
        }


        // 3) Limit on the number of guesses
        //     increment "Wrong" guess count
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
            h.Count = 7;

            // Asserts:
            Assert.IsTrue(h.GuessLimitReached());
        }

        // 
    }
}
