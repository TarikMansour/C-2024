using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria
{
    internal class Parallelepipedo : Rettangolo
    {
        double _profondità;
        List<Parallelepipedo> parallelepipedos = new List<Parallelepipedo>();
        public Parallelepipedo(Punto p, double altezza, double _base, double profondità) : base(p,altezza,_base) { 
            _profondità = profondità;
        }
        public double CalcoloVolume()
        {
            return _profondità*_altezza*_base;
        }
        public void Add(Parallelepipedo p)
        {
            parallelepipedos.Add(p);
        }
        public double AreaTotale()
        {
            return 2*(CalcolaArea() + _profondità * _base);
        }
        new public string Scrivi()
        {
            return ($"PARALLELIPIPEDO: Altezza: {_altezza}, Base: {_base}, Profondità: {_profondità}, Volume: {CalcoloVolume()}, Area: {AreaTotale()}");
        }
    }
}
