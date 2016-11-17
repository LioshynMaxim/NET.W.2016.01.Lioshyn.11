using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    public class Queue<T>
    {
        private T[] collection;
        public int Count { get; set; }

        public T this[int index]
        {
            get
            {
                if (index >= Count && index < 0)
                    throw new IndexOutOfRangeException();
                return collection[index];
            }
        }

        #region .ctor

        /// <summary>
        /// .ctor
        /// </summary>

        public Queue() : this(0)
        {
        }

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="capacity">Number of elements.</param>

        public Queue(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentException();
            collection = new T[capacity];
            Count = 0;
        }

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="elements">Elements of T type</param>

        public Queue(IEnumerable<T> elements)
        {
            if (elements == null)
                throw new ArgumentNullException(); // ???

            int index = 0;
            var enumerable = elements as IList<T> ?? elements.ToList();

            collection = new T[enumerable.Count()];
            foreach (T element in enumerable)
                collection[index++] = element;
            Count = enumerable.Count();
        }

        #endregion

        #region Main methods

        /// <summary>
        /// Adds an object to the end of the Queue.
        /// </summary>
        /// <param name="item">Adds an object to the end.</param>

        public void Enqueue(T item)
        {
            if (Count == collection.Length)
                ToExpandArray();
            collection[Count++] = item;
        }

        /// <summary>
        /// Removes and returns the object at the beginning of the Queue.
        /// </summary>
        /// <returns>Object at the beginning</returns>

        public T Dequeue()
        {
            if (Count == 0)
                throw new InvalidOperationException(); //???

            T temp = collection[0];
            Array.Copy(collection, 1, collection, 0, collection.Length - 1);
            Count--;
            return temp;
        }

        /// <summary>
        /// Returns the object at the beginning of the Queue without removing it.
        /// </summary>
        /// <returns>Object</returns>

        public T Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException(); //???

            return collection[0];
        }
        #endregion


        #region Other methods

        /// <summary>
        /// Expand collection to through array.
        /// </summary>

        private void ToExpandArray()
        {
            int newSize = collection.Length == 0 ? 5 : collection.Length << 1;
            T[] temp = new T[newSize];
            collection.CopyTo(temp, 0);
            collection = temp;
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>Iterates</returns>
        public Enumerator<T> GetEnumerator() => new Enumerator<T>(this);

        #endregion
    }

    public class Enumerator<T>
    {
        #region Fields

        private readonly Queue<T> queue;
        private int position;

        public T Current
        {
            get
            {
                if ((position == queue.Count ) || (position == -1))
                    throw new InvalidOperationException();
            return queue[position];
            }
        }

        #endregion

        #region .ctor

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="queue">Queue</param>

        public Enumerator(Queue<T> queue)
        {
            this.queue = queue;
            position = -1;
        }

        #endregion

        #region Main function

        /// <summary>
        /// Advances the enumerator to the next element of the collection.
        /// </summary>
        /// <returns>Next element.</returns>

        public bool MoveNext() => ++position < queue.Count;

        /// <summary>
        /// Sets the enumerator to its initial position, which is before the first element in the collection.
        /// </summary>

        public void Reset() => position = -1;

        /// <summary>
        /// Dispose of unmanaged resources.
        /// </summary>

        public void Dispose() { }

        #endregion

    }

}
