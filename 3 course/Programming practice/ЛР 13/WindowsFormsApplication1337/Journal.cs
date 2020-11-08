using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1337
{
    class Journal
    {
        public string number;
        public string name;
        public string redaction;
        public string author;
        public string price;
        public Journal(string number, string name, string redaction, string author, string price)
        {
            this.number = number;
            this.name = name;
            this.redaction = redaction;
            this.author = author;
            this.price = price;
        }

        public string getNumber()
        {
            return this.number;
        }

        public void setNumber(string number)
        {
            this.number = number;
        }

        public string getName()
        {
            return this.name;
        }        

        public void setName(string name)
        {
            this.name = name;
        }

        public string getRedaction()
        {
            return this.redaction;
        }

        public void setRedaction(string redaction)
        {
            this.redaction = redaction;
        }

        public string getAuthor()
        {
            return this.author;
        }

        public void setAuthor(string author)
        {
            this.author = author;
        }

        public string getPrice()
        {
            return this.price;
        }

        public void setPrice(string price)
        {
            this.price = price;
        }                         
    }
}
