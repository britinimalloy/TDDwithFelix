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
        public void AtoITestNull()
        {
            Assert.AreEqual(TDDwithFelix.Program.AtoI(null), 0);
            Assert.AreEqual(TDDwithFelix.Program.AtoI(""), 0);
            Assert.AreEqual(TDDwithFelix.Program.AtoI("     "), 0);
        }


        [TestMethod()]
        public void AtoITestSingleDigit()
        {
            Assert.AreEqual(TDDwithFelix.Program.AtoI("5"),5);
            Assert.AreEqual(TDDwithFelix.Program.AtoI("6"), 6);
            Assert.AreEqual(TDDwithFelix.Program.AtoI("1"), 1);
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
    } 
} 