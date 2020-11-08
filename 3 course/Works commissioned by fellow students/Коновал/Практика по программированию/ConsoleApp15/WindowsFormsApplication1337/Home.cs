using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1337
{
    class Home
    {
        public string number;
        public string type;
        public string floor;
        public string street;
        public string city;
        public Home(string number, string type, string floor, string street, string city)
        {
            this.number = number;
            this.type = type;
            this.floor = floor;
            this.street = street;
            this.city = city;
        }

        public string getNumber()
        {
            return this.number;
        }

        public void setNumber(string number)
        {
            this.number = number;
        }

        public string getType()
        {
            return this.type;
        }

        public void setType(string type)
        {
            this.type = type;
        }

        public string getFloor()
        {
            return this.floor;
        }

        public void setFloor(string floor)
        {
            this.floor = floor;
        }

        public string getStreet()
        {
            return this.street;
        }

        public void setStreet(string street)
        {
            this.street = street;
        }

        public string getCity()
        {
            return this.city;
        }

        public void setCity(string city)
        {
            this.city = city;
        }
    }
}