using Microsoft.VisualStudio.TestTools.UnitTesting; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.Threading.Tasks; 
using TDDwithFelix;

namespace TDDwithFelix_Tests
{
    [TestClass()] 
    public class ProgramTests
    { 
        [TestMethod()]
        public void TestMain()
        {
            Program.Main(null);
        }


        [TestMethod()]
        public void AtoITestWeirdCharacters()
        {
            Assert.AreEqual(TDDwithFelix.Program.AtoI("12a"), 0);
            Assert.AreEqual(TDDwithFelix.Program.AtoI("a+b=c"), 0);
            Assert.AreEqual(TDDwithFelix.Program.AtoI("$3.99"), 0);
            Assert.AreEqual(TDDwithFelix.Program.AtoI("79,800"), 79800);
        }
        [TestMethod()]
        public void AtoITestNegatives()
        {
            Assert.AreEqual(TDDwithFelix.Program.AtoI("-78"), -78);
            Assert.AreEqual(TDDwithFelix.Program.AtoI("-78-10"), 0);
            Assert.AreEqual(TDDwithFelix.Program.AtoI("10-5"), 0);
        }

        [TestMethod()]
        public void AtoITestNull()
        {
            Assert.AreEqual(TDDwithFelix.Program.AtoI(null), 0);
            Assert.AreEqual(TDDwithFelix.Program.AtoI(""), 0);
            Assert.AreEqual(TDDwithFelix.Program.AtoI("     "), 0);
        }


        [TestMethod()]
        public void AtoITestNiceDoubleDigit()
        {
            Assert.AreEqual(TDDwithFelix.Program.AtoI("84"), 84);
        }
        
        [TestMethod()]
        public void AtoITestSpaces()
        {
            Assert.AreEqual(TDDwithFelix.Program.AtoI("   25"), 25);
        }

        [TestMethod()]
        public void AtoITestTripleDigit()
        {
            Assert.AreEqual(TDDwithFelix.Program.AtoI("840"), 840);
        }

        [TestMethod()]
        public void AtoITestMultipleDigit()
        {
            Assert.AreEqual(TDDwithFelix.Program.AtoI("94273"), 94273);
        }

        [TestMethod()]
        public void AtoITestSingleDigit()
        {
            Assert.AreEqual(TDDwithFelix.Program.AtoI("5"), 5);
            Assert.AreEqual(TDDwithFelix.Program.AtoI("6"), 6);
            Assert.AreEqual(TDDwithFelix.Program.AtoI("1"), 1);
        }

        [TestMethod()]
        public void IsNumberTestNumber()
        {
            Assert.IsTrue(TDDwithFelix.Program.IsNumber("1"));
            Assert.IsTrue(TDDwithFelix.Program.IsNumber("-1"));
            Assert.IsTrue(TDDwithFelix.Program.IsNumber("65461"));
            Assert.IsTrue(TDDwithFelix.Program.IsNumber("   25"));
        }

        [TestMethod()]
        public void IsNumberTestLetter()
        {
            Assert.IsFalse(TDDwithFelix.Program.IsNumber("a"));
        }

        [TestMethod()]
        public void IsNumberTestOther()
        {
            Assert.IsFalse(TDDwithFelix.Program.IsNumber("1.0"));
            Assert.IsFalse(TDDwithFelix.Program.IsNumber("-15-2"));
        }

        [TestMethod()]
        public void IsNumberProblem()
        {
            Assert.IsTrue(TDDwithFelix.Program.IsNumber("0"));
        }

        [TestMethod()]
        public void IsNumberProblem2()
        {
            Assert.IsTrue(TDDwithFelix.Program.IsNumber("0000"));
        }
    } 
} 