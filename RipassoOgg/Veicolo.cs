using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RipassoOgg.Veicolo;

namespace RipassoOgg
{
    internal class Veicolo
    {
        public enum numeroPosti
        {
          Due,
          Quattro,
          Cinque,
          Otto
        }

        public Veicolo(string marca, string modello,numeroPosti posti)
        {
            Marca = marca;
            Modello = modello;
            Posti = posti;
        }
        public void SetTarga()
        {
            Random random = new Random();
            int[] numeri = new int[3];
            for (int i = 0; i < 3; i++)
            {
                int valore = random.Next(0, 10);
                numeri[i] = valore;
            }
            char[] lettere = new char[5];

            for (int i = 0; i < 5; i++)
            {
                int codiceAscii = random.Next(65, 91);
                lettere[i] = (char)codiceAscii;
            }

            string targa = $"{lettere[0]}{lettere[1]}{numeri[0]}{numeri[1]}{numeri[2]}{lettere[3]}{lettere[4]}";
            Targa = targa;
        }
        //auto properties
        public int Codice {get;  set; }
        public string Marca {  get; }
        public string Modello { get; }
        public numeroPosti Posti { get; }
        public string Targa { get; private set; }
        public int CodiceVeicolo { get; set; }

        public override string ToString()
        {
            return string.Format($"MARCA:{Marca} MODELLO:{Modello} TARGA:{Targa} NUM.POSTI:{Posti} CODICE:{Codice}");
        }
    }
}
