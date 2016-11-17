using NUnit.Framework;
using static Task1.Fibonacci;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Tests
{
    [TestFixture()]
    public class FibonacciTests
    {
        public IEnumerable<TestCaseData> DatasCaseForSumFibonacci
        {
            get
            {
                yield return new TestCaseData(6).Returns(12);
                yield return new TestCaseData(11).Returns(143);
                yield return new TestCaseData(0).Returns(0);
            }
        }

        [Test, TestCaseSource(nameof(DatasCaseForSumFibonacci))]
        public int FibonacciNumbers_Test(int number)
        {
            return SumFibonacci(number);
        }
    }
}