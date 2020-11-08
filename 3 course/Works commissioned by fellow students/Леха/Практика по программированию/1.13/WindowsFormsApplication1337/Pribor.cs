using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1337
{
    class Pribor
    {
        public string diapozon;
        public string porog;
        public string chuvstvitelnost;
        public string tochnost;
        public string stabilnost;
        public Pribor(string diapozon, string porog, string chuvstvitelnost, string tochnost, string stabilnost)
        {
            this.diapozon = diapozon;
            this.porog = porog;
            this.chuvstvitelnost = chuvstvitelnost;
            this.tochnost = tochnost;
            this.stabilnost = stabilnost;
        }

        public string getDiapozon()
        {
            return this.diapozon;
        }

        public void setDiapozon(string diapozon)
        {
            this.diapozon = diapozon;
        }

        public string getPorog()
        {
            return this.porog;
        }

        public void setPorog(string porog)
        {
            this.porog = porog;
        }

        public string getChuvstvitelnost()
        {
            return this.chuvstvitelnost;
        }

        public void setChuvstvitelnost(string chuvstvitelnost)
        {
            this.chuvstvitelnost = chuvstvitelnost;
        }

        public string getTochnost()
        {
            return this.tochnost;
        }

        public void setTochnost(string tochnost)
        {
            this.tochnost = tochnost;
        }

        public string getStabilnost()
        {
            return this.stabilnost;
        }

        public void setStabilnost(string stabilnost)
        {
            this.stabilnost = stabilnost;
        }
    }
}
