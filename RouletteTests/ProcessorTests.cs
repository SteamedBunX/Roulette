using Microsoft.VisualStudio.TestTools.UnitTesting;
using Roulette;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Tests
{
    [TestClass()]
    public class ProcessorTests
    {
        Random r;

        [TestInitialize]
        public void TestIni()
        {
            r = new Random();
        }

        [TestMethod()]
        public void NumberResultTest()
        {
            Assert.AreEqual("00", Processor.NumberResult(37));
            Assert.AreEqual("0", Processor.NumberResult(0));
            Assert.AreEqual("1", Processor.NumberResult(1));
            Assert.AreEqual("10", Processor.NumberResult(10));
        }

        [TestMethod()]
        public void ColorTest()
        {
            List<int> blacks = new List<int> { 0, 1, 2, 3, 4 };
            Assert.AreEqual(NumberSet.Black, Processor.Color(1, ref blacks));
            Assert.AreEqual(NumberSet.Red, Processor.Color(5, ref blacks));
        }

        [TestMethod()]
        public void OddOrEvenTest()
        {
            Assert.AreEqual(NumberSet.Even, Processor.OddOrEven(2));
            Assert.AreEqual(NumberSet.Odd, Processor.OddOrEven(1));
        }

        [TestMethod()]
        public void LowHighTest()
        {
            int testCase = r.Next(18) + 1;
            Assert.AreEqual(NumberSet.Low, Processor.LowHigh(testCase));
            testCase += 18;
            Assert.AreEqual(NumberSet.High, Processor.LowHigh(testCase));
        }

        [TestMethod()]
        public void DozenTest()
        {
            int testCase = r.Next(12) + 1;
            Assert.AreEqual(NumberSet.First, Processor.Dozen(testCase));
            testCase += 12;
            Assert.AreEqual(NumberSet.Second, Processor.Dozen(testCase));
            testCase += 12;
            Assert.AreEqual(NumberSet.Third, Processor.Dozen(testCase));
        }

        [TestMethod()]
        public void ColumnTest()
        {
            int testCase = (r.Next(12) + 1) * 3;
            Assert.AreEqual(NumberSet.Third, Processor.Column(testCase));
            testCase -= 1;
            Assert.AreEqual(NumberSet.Second, Processor.Column(testCase));
            testCase -= 1;
            Assert.AreEqual(NumberSet.First, Processor.Column(testCase));
        }

        [TestMethod()]
        public void StreetTest()
        {
            int testCase = r.Next(3) + 1;
            Assert.AreEqual(1, Processor.Street(testCase));
            testCase += 3 * 5;
            Assert.AreEqual(6, Processor.Street(testCase));
        }

        [TestMethod()]
        public void CornerTest()
        {
            List<List<int>> expectedResult = new List<List<int>> { new List<int>{ 16, 17, 19, 20 } ,new List<int>{ 17, 18, 20, 21 },
                new List<int>{ 19, 20, 22, 23 }, new List<int>{ 20, 21, 23, 24 } };
            List<List<int>> actualResult = Processor.Corner(20);
            Assert.IsTrue(compareListListInt(expectedResult, actualResult));
            expectedResult = new List<List<int>> { new List<int> { 31, 32, 34, 35 } };
            actualResult = Processor.Corner(34);
            Assert.IsTrue(compareListListInt(expectedResult, actualResult));
        }

        [TestMethod()]
        public void SplitTest()
        {
            List<List<int>> expectedResult = new List<List<int>> { new List<int>{ 17, 20 } ,new List<int>{ 19, 20 },
                new List<int>{ 20, 21 }, new List<int>{ 20, 23 } };
            List<List<int>> actualResult = Processor.Split(20);
            Assert.IsTrue(compareListListInt(expectedResult, actualResult));
            expectedResult = new List<List<int>> { new List<int> { 31, 34 }, new List<int> { 34, 35 } };
            actualResult = Processor.Split(34);
            Assert.IsTrue(compareListListInt(expectedResult, actualResult));
        }

        [TestMethod()]
        public void Six_NumbersTest()
        {
            List<List<int>> expectedResult = new List<List<int>> { new List<int>{ 1, 2, 3, 4, 5, 6 } ,
                new List<int>{ 4, 5, 6, 7, 8, 9 } };
            List<List<int>> actualResult = new List<List<int>>();
            for(int i = 4; i <= 6; i++)
            {
                actualResult = Processor.Six_Numbers(i);
            }
            Assert.IsTrue(compareListListInt(expectedResult, actualResult));
            expectedResult = new List<List<int>> { new List<int> { 31, 32, 33, 34, 35, 36 } };
            for (int i = 34; i <= 36; i++)
            {
                actualResult = Processor.Six_Numbers(i);
            }
            Assert.IsTrue(compareListListInt(expectedResult, actualResult));
        }

        public bool compareListListInt(List<List<int>> expectedResult, List<List<int>> actualResult)
        {
            if (expectedResult.Count != actualResult.Count)
            {
                return false;
            }
            for (int i = 0; i < expectedResult.Count; i++)
            {
                for (int j = 0; j < expectedResult[i].Count; j++)
                {
                    if (expectedResult[i][j] != actualResult[i][j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}