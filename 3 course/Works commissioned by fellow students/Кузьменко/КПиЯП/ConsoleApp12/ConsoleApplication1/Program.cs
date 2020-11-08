using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    delegate void Deleg1();
    delegate void Deleg2();
    delegate string Deleg3(string s);

    class Events
    {
        public event Deleg1 Ev1;
        public void OnEv1()
        {            
            Ev1();
            Console.WriteLine("Общее событие!");
        }

        public event Deleg2 Ev2;
        public void OnEv2()
        {
            Ev2();
            Console.WriteLine("Событие произошло.");
        }

        public event Deleg3 Ev3;
        public string OnEv3(string s)
        {
            s += " ";
            return Ev3(s);
        }
    }

    class Program
    {
        class Produkt
        {
            protected int page = 0;

            public void setPage(int page)
            {
                if (page > 0 && page < 500)
                {
                    this.page = page;
                }
                else
                    this.page = 0;
            }

            public int getAge()
            {
                return page;
            }

            protected string name = "";
            public void setName(string name)
            {
                this.name = name;
            }

            public string getName()
            {
                return name;
            }
        }

        class Tovar : Produkt
        {
            protected int Price = 0;

            public void setPrice(int price)
            {
                if (price > 0 && price < 200)
                {
                    this.Price = price;
                }
                else
                    this.Price = 0;
            }

            public int getPrice()
            {                
                return Price;                
            }

            public void print()
            {
                Console.WriteLine("Items");
                Deleg2 del2 = delegate ()
                {
                    Console.WriteLine("Анонимный метод товара.");
                };
                del2();
            }
        }

        class Igrushka : Tovar
        {
            protected int year = 0;

            public void setYear(int year)
            {
                if (1990 > 0 && year < 2017)
                    this.year = year;
                else
                    this.year = 0;
            }

            public int getYear()
            {                
                return year;
            }

            internal void setPrice(int p)
            {
                throw new NotImplementedException();
            }

            public void print()
            {
                Console.WriteLine("Toys");
                Deleg1 del1 = delegate ()
                {
                    Console.WriteLine("Анонимный метод игрушки");
                };
                del1();
            }
        }

        class Milkproduct : Tovar
        {
            protected int kolvo_statej = 0;

            public void setStatya(int kolvo_statej)
            {
                this.kolvo_statej = kolvo_statej;
            }

            public int getStatya()
            {
                return kolvo_statej;
            }
        }

        static Deleg3 D(string sss)
        {
            string ss = "Начало ";
            Deleg3 del3 = delegate (string s)
            {
                ss += s + "конец.";
                return ss;
            };
            return del3;
        }

        static void Main(string[] args)
        {
            {
                Events evt = new Events();
                string sss = " середина ";                               
                evt.Ev3 += D(sss);
                Console.WriteLine("Событие: {0}", evt.OnEv3(sss));
                Console.WriteLine();

                

                Produkt produkt = new Produkt();
                Tovar tovar = new Tovar();
                Igrushka igrushka = new Igrushka();
                Milkproduct milkproduct = new Milkproduct();

                evt.Ev2 += igrushka.print;
                evt.OnEv2();

                evt.Ev1 += tovar.print;
                evt.OnEv1();
                Console.WriteLine();

                Console.WriteLine("введите название продукта");
                produkt.setName(Convert.ToString(Console.ReadLine()));
                Console.WriteLine("_________________________________");
                Console.WriteLine("введите название товара");
                tovar.setName(Convert.ToString(Console.ReadLine()));
                Console.WriteLine("введите цену товара");
                tovar.setPrice(Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine("_________________________________");
                Console.WriteLine("введите кол-во игрушек");
                tovar.setPage(Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine("введите название игрушки");
                tovar.setName(Convert.ToString(Console.ReadLine()));
                Console.WriteLine("введите цену игрушки");
                tovar.setPrice(Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine("_________________________________");
                Console.WriteLine("введите срок годности молочного продукта");
                tovar.setPage(Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine("введите название молочного продукта");
                tovar.setName(Convert.ToString(Console.ReadLine()));
                Console.WriteLine("введите цену молочного продукта");
                tovar.setPrice(Convert.ToInt32(Console.ReadLine()));                

                Console.ReadKey();
            }

        }
    }
}
