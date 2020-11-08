using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL1
{
    public class BD
    {
        public BD(int d, int m, int y)
        {
            this.d = d;
            this.m = m;
            this.y = y;
        }

        public virtual void BDW()
        {
            Console.WriteLine("Дата рождения:\n {0} {1} {2}", d, m, y);
        }

        public int D
        {
            get { return d; }
            set
            {
                if (value > 0)
                    d = value;
                else
                    d = 0;
            }
        }

        public int M
        {
            get { return m; }
            set
            {
                if (value > 0)
                    m = value;
                else
                    m = 0;
            }
        }

        public int Y
        {
            get { return y; }
            set
            {
                if (value > 0)
                    y = value;
                else
                    y = 0;
            }
        }

        int d, m, y;
    }

    public class FIO
    {        
        public FIO(string f, string i, string o)
        {
            this.f = f;
            this.i = i;
            this.o = o;
        }

        public virtual void FIOW()
        { 
            Console.WriteLine("ФИО:\n {0} {1} {2}", f, i, o); 
        }

        public string F
        {
            get {return f;}
            set 
            {
                if (value != null)
                    f = value;
                else
                    f = "";
            }
        }

         public string I
        {
            get {return i;}
            set
            {
                if (value != null)
                    i = value;
                else
                    i = "";
            }
        }

        public string O
        {
            get {return o;}
            set 
            {
                if (value != null)
                    o = value;
                else
                    o = "";
            }
        }

        string f, i, o;
    }

    public class Monster
    {            
        public Monster(int streng, int skill, string name)
        {
            this.streng = streng;
            this.skill = skill;
            this.name = name;
        }

        public virtual void Passport()
        { 
            Console.WriteLine("Монстр {0} \t сила = {1} умение= {2}", name, streng, skill); 
        }

        public int Streng
        {
            get { return streng; }
            set
            {
                if (value > 0)
                    streng = value;
                else 
                    streng = 0;
            }
        }

        public int Skill
        {
            get { return skill; }
            set
            {
                if (value > 0) 
                    skill = value;
                else 
                    skill = 0;
            }
        }

        public string Name
        {
            get { return name; }
        }

        string name;
        int streng, skill;
    }

    //производный класс от монстра – демон, умеющий “думать”
    public class Daemon : Monster
    {
        public Daemon(int streng, int skill, string name, int brain)
            : base(streng, skill, name)
        { 
            this.brain = brain; 
        }

        public override void Passport()
        {
            Console.WriteLine("Демон {0} сила = {1} умение {2} ум = {3}", Name, Streng, Skill, brain);
        }

        public void Think()
        {
            Console.Write(Name + "это ");
            for (int i = 0; i < brain; i++) 
                Console.Write(" думает ");
            Console.WriteLine("...");
        }

        int brain;
    }
}