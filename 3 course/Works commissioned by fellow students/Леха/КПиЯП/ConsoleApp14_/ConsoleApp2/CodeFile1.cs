using System;
namespace Person
{
    public class Person
    {
        private string _name;
        private string _surname;
        private int _age;

        public Person()
        {
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }
    }
}