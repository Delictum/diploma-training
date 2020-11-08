using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ConsoleApp1
{
    class Program
    {
        class MyInt : IEnumerable, IEnumerator
        {
            int[] ints = { 1, 2, 4, 3 };
            int index = -1;

            public IEnumerator GetEnumerator()
            {
                return this;
            }

            public ICollection<int> IC { get; set; }
            public IDictionary<string, int> ID { get; set; }
            public IList<int> IL { get; set; }

            public MyInt()
            {
                IC = new List<int>();
                IL = new List<int>();
                ID = new Dictionary<string, int>();
                Queue<int> Q = new Queue<int>();
            }

            public bool MoveNext()
            {
                if (index == ints.Length - 1)
                {
                    Reset();
                    return false;
                }

                index++;
                return true;
            }

            public void Reset()
            {
                index = -1;
            }

            public object Current
            {
                get
                {
                    return ints[index];
                }
            }
        }

        static void Main(string[] args)
        {
            MyInt mi = new MyInt();

            foreach (int i in mi)
                Console.Write(i + "\t");

            Console.ReadLine();
        }
    }
}
