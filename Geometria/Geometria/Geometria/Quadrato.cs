using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria
{
    internal class Quadrato : Rettangolo
    {
        List<Quadrato> quadratos = new List<Quadrato>();
        public Quadrato(Punto p, double lato) : base(p, lato, lato)
        {

        }
        public void Add(Quadrato p)
        {
            quadratos.Add(p);
        }
        new public double CalcolaArea()
        {
            return _altezza * _altezza;
        }
        public double CalcolaArea(double val)
        {
            return base.CalcolaArea()*val;
        }
        new public string Scrivi()
        {
            return ($"QUADRATO: Lato: {_base}, Perimetro: {CalcoloPerimetro()}, Area: {CalcolaArea()}");
        }
    }
}
