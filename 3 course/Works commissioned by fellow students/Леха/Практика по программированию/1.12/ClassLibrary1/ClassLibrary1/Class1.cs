using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Document
    {
        public string soderz, face;
        private int number;
        public Document(string soderz, string face)
        {
            this.soderz = soderz;
            this.face = face;
        }
        public Document()
        {
            soderz = "Декларация о доходах";
            face = "Колковский.А";
        }
        public string Soderz
        {
            get { return soderz; }
            set { soderz = value; }
        }
        public string Face
        {
            get { return face; }
            set { face = value; }
        }
        public int Number
        {
            get { return number; }
            set { number = value; }
        }
        public void Print()
        {
            Console.WriteLine($"содержимое документа:\n{soderz}\nОтветственное лицо:{face}\nНомер:{number}");
        }
        public static Document operator ++(Document obj1)
        {
            obj1.number += 1;
            return obj1;
        }

    }
}
