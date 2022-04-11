using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logika
{
    internal class Plansza
    {
        private int _a = 400;
        private List<Kula> _kule = new List<Kula>(); 

        public Plansza() { }

        public int A
        {
            get => _a;
        }

        public void DodajKuleNaPlansze(Kula kula)
        {
            _kule.Add(kula);
        }

        public void UsunKuleZPlanszy(Kula kula)
        {
            _kule.Remove(kula);
        }

        public void WyswietlKule()
        {
            for (int i = 0; i < _kule.Count; i++)
            {
                Console.Write(" "+_kule[i].X);
                Console.Write(" "+_kule[i].Y);
                Console.Write(" "+_kule[i].Radius);
                
            }
        }

    }
}
