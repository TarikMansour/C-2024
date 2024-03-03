﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria
{
    internal class Rettangolo
    {
        protected double _altezza, _base;
        Punto P;
        int _x, _y;
        List<Rettangolo> rettangolos = new List<Rettangolo>();
       
        public Rettangolo(Punto p, double altezza, double lunghezza)
        {
            _altezza = altezza;
            _base = lunghezza;
        }
        public Rettangolo(int x, int y, double altezza, double lunghezza) : this(new Punto(x, y), altezza, lunghezza)
        {

        }
        public void Add(Rettangolo rettangolo)
        {
            rettangolos.Add(rettangolo);
        }
        public double CalcolaArea()
        {
            return (_altezza * _base);
        }
        public double CalcoloPerimetro()
        {
            return (_base * 2) + (_altezza * 2);
        }
        public string Scrivi()
        {
            return ($"RETTANGOLO: Base: {_base}, Altezza: {_altezza}, Perimetro: {CalcoloPerimetro()}, Area: {CalcolaArea()}");
        }
    }
}
