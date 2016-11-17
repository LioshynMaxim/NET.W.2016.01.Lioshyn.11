using NUnit.Framework;
using task2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2.Tests
{
    [TestFixture()]
    public class QueueTests
    {
        
        [Test()]
        public void Iterator_For_Test_Numbers()
        {
            string result = CollectionItemsToStringByIterator(new[] { 1, 2, 3, 4 });
            Assert.AreEqual(result, "1234");
        }

        [Test()]
        public void Iterator_For_Test_Strings()
        {
            string result = CollectionItemsToStringByIterator(new[] { "Dave", "Djo", "Peter", "Lazy" });
            Assert.AreEqual(result, "DaveDjoPeterLazy");
        }

        private string CollectionItemsToStringByIterator<T>(IEnumerable<T> collection)
        {
            var queue = new Queue<T>();

            foreach (var item in collection)
            {
                queue.Enqueue(item);
            }

            string result = "";
            Enumerator<T> iterator = queue.GetEnumerator();
            while (iterator.MoveNext())
            {
                result += iterator.Current;
            }

            return result;
        }

    }
}