using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Cset<T>
    {
        //Конструктор коллекции множества
        private List<T> _list;
        Cset()
        {
            _list = new List<T>();
        }
        public Cset(params T[] args)
            : this()
        {
            _list.AddRange(args);
        } 
        //Конструктор множества, состоящий из заданных элементов коллекции
        public Cset(IEnumerable<T> mas)
            : this()
        {
            _list.AddRange(mas);
        }

        //Добавление элемента в множество
        public void Add(T elem)
        {
            _list.Add(elem);
        }
        //Удаление элемента из множества
        public void Delete(T elem)
        {
            _list.Remove(elem);
        }

        //Объединение множеств
        public static Cset<T> operator +(Cset<T> Source1, Cset<T> Source2)
        {
            return new Cset<T>(Source2._list.Union(Source1._list));
        }

        //Мощность множества
        public int Power()
        {
            return _list.Count;             
        }        

        public static bool operator <=(Cset<T> Source1, Cset<T> Source2)
        {
            if (Source1.Power() <= Source2.Power())
            {
                Console.WriteLine("Мощность множества 1 равна или меньше мощности множества 2");
                return true;
            }
            else
            {
                Console.WriteLine("Мощность множества 1 больше мощности множества 2");
                return false;
            }
        }

        public static bool operator >=(Cset<T> Source1, Cset<T> Source2)
        {
            if (Source1.Power() >= Source2.Power())
            {
                Console.WriteLine("Мощность множества 1 равна или больше мощности множества 2");
                return true;
            }
            else
            {
                Console.WriteLine("Мощность множества 1 меньше мощности множества 2");
                return false;
            }
        }

        public void Elem(int a)
        {
            Console.WriteLine("Элемент {0} равен {1}", a, _list[a]);
        }

        public void Elem(double a)
        {
            Console.WriteLine("Элемент {0} равен {1}", a, _list[Convert.ToInt32(a)]);
        }

        public override string ToString()
        {
            return string.Join(",", _list);
        }        
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*
             Создать заданный в варианте класс. Определить в классе конструкторы, деструктор, 
             необходимые функции и заданные перегруженные операции. Написать программу тестирования, 
             в которой проверяется использование всех перегруженных операций. Класс – множество Сset. 
             Дополнительно перегрузить следующие операции: () – конструктор множества 
             (в стиле конструктора для множественного типа); + – объединение множеств; 
             <= – сравнение множеств; int()– мощность множества; [] – доступ к элементу в заданной позиции.
             */
            Cset<int> _mt1 = new Cset<int>(1, 2, 3, 4, 5);
            _mt1.Add(6);
            Console.WriteLine("Множество 1: {0}", _mt1);
            Cset<int> _mt2 = new Cset<int>(4, 5, 6, 7, 8);
            Console.WriteLine("Множество 2: {0}", _mt2);
            Console.WriteLine("Мощность множества 1: {0}", _mt1.Power());
            Console.WriteLine("Мощность множества 2: {0}", _mt2.Power());
            if (_mt1 <= _mt2)
                Console.WriteLine("<=");
            else
                Console.WriteLine(">"); 
            Console.WriteLine("Объединение множеств: {0}", _mt1 += _mt2);
            Console.Write("Введите номер элемента множества 2: ");
            back1: int a = int.Parse(Console.ReadLine());
            if (a > _mt2.Power() - 1)
            {
                Console.WriteLine("Превышает количество элементов множества, повторите ввод");
                goto back1;
            }
            _mt2.Elem(a);            
            Console.ReadKey();
        }
    }
}
