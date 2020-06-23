using System;
using System.Collections.Generic;
using MaxSumInLine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaxSumInLineTests
{
    [TestClass]
    public class MaxSumInLineMethodsTest
    {
        [TestMethod]
        public void NumLineWithMaxSum__GetNumStringWithMaxSum_inputValidData_2return()
        {
            int expected = 2;

            string[] inputData = { "1,2,3", "7.5,8.1", "4,3.5"};
            InMemoryLinesSource testSource = new InMemoryLinesSource(inputData);            
            NumLineWithMaxSum test = new NumLineWithMaxSum(testSource);

            int actual = test.NumLineWithMaxSumValue;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NumLineWithMaxSum_GetNumStringWithMaxSum_inputValidDataAllNegative_4return()
        {
            int expected = 4;

            string[] inputData = { "-5", "-1,-5.5,-7", "-3,-7", "-1,-0.5" };
            InMemoryLinesSource testSource = new InMemoryLinesSource(inputData);
            NumLineWithMaxSum test = new NumLineWithMaxSum(testSource);

            int actual = test.NumLineWithMaxSumValue;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NumLineWithMaxSum_GetNumStringWithMaxSum_withInvalidData_1return()
        {
            int expected = 1;

            string[] inputData = { "-100,150", "Qwe", "100,,500", "1000..6" };
            InMemoryLinesSource testSource = new InMemoryLinesSource(inputData);
            NumLineWithMaxSum test = new NumLineWithMaxSum(testSource);

            int actual = test.NumLineWithMaxSumValue;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NumLineWithMaxSum_GetNumStringWithMaxSum_noValidData_0NumLines_4InvalidStrings()
        {
            int expectedNumLine = 0;
            int expectedInvalidStringsCount = 4;

            string[] inputData = { "-100,,150", "Qwe", "100,,500", "1000..6" };
            InMemoryLinesSource testSource = new InMemoryLinesSource(inputData);
            NumLineWithMaxSum test = new NumLineWithMaxSum(testSource);

            int actualNumLineWithMaxSum = test.NumLineWithMaxSumValue;
            int actualInvalidStringsCount = test.InvalidStrings.Count;

            Assert.AreEqual(expectedNumLine, actualNumLineWithMaxSum);
            Assert.AreEqual(expectedInvalidStringsCount, actualInvalidStringsCount);
        }

        [TestMethod]
        public void NumLineWithMaxSum_GetInvalidStrings_noValidData_4return()
        {
            int expected = 4;

            string[] inputData = { "-100,,150", "Qwe", "100,,500", "1000..6" };
            InMemoryLinesSource testSource = new InMemoryLinesSource(inputData);
            NumLineWithMaxSum test = new NumLineWithMaxSum(testSource);

            int actual = test.InvalidStrings.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NumLineWithMaxSum_NumLineWithMaxSumValue_ZeroAndNegativeSum_1Return()
        {
            int expected = 1;

            string[] inputData = { "-1,1", "-1,-1" };
            InMemoryLinesSource testSource = new InMemoryLinesSource(inputData);
            NumLineWithMaxSum test = new NumLineWithMaxSum(testSource);

            int actual = test.NumLineWithMaxSumValue;

            Assert.AreEqual(expected, actual);
        }
    }
}
