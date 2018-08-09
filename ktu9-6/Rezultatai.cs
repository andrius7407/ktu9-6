using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ktu9_6
{
    class Rezultatai
    {
        public int valPerSav;
        public int kiekDaugiau;
        public int kiekMaziau;

        public Rezultatai(int valPerSav, int kiekDaugiau, int kiekMaziau)
        {
            this.valPerSav = valPerSav;
            this.kiekDaugiau = kiekDaugiau;
            this.kiekMaziau = kiekMaziau;
        }
    }
}
