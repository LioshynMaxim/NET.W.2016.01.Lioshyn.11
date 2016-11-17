using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public static class Fibonacci
    {
        /// <summary>
        /// Sum Fibonacci numbers
        /// </summary>
        /// <param name="amount">Amount members of sequence</param>
        /// <returns>Sum Fibonacci amount members of sequence</returns>

        public static int SumFibonacci(int amount)
        {
            if (amount == 0)
                return 0;

            int sum = 0;
            IEnumerator<int> sequence = SequenceFibonacci(amount);
            bool next = sequence.MoveNext();
            while (next)
            {
                sum += sequence.Current;
                next = sequence.MoveNext();
            }

            return sum;
        }

        /// <summary>
        /// Sequence Fibonacci
        /// </summary>
        /// <param name="n">Number member in sequence</param>
        /// <returns>Number in sequence</returns>

        private static IEnumerator<int> SequenceFibonacci(int n)
        {
            int number1 = 0;
            int number2 = 1;
            yield return number1;
            yield return number2;
            for (int i = 2; i < n; i++)
            {
                yield return FibonacciRecursion(i);
            }
        }

        /// <summary>
        /// Recursion function
        /// </summary>
        /// <param name="n">Number member in sequence</param>
        /// <returns>Number in sequence</returns>
        public static int FibonacciRecursion(int n)
        {
            return n > 1 ? FibonacciRecursion(n - 1) + FibonacciRecursion(n - 2) : n;
        }
        
    }
}
