using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStudentPerson
{
    //CLASSE DERIVATA DA PERSONA
    internal class Studente : Persona
    {
        //ATTRIBUTI
        string _scuola;
        string _matricola;
       
        //COSTRUTTORE
        public Studente(string nome, string cognome, string genere, int eta, string scuola) : base (nome,cognome,genere,eta) {
            _scuola = scuola;
            _matricola = GetMatricola();
        }
        //GENERA MATRICOLA 
        public string GetMatricola()
        {
            Random random= new Random();
            int[] numeri = new int[4];
            for (int i = 0; i < 4; i++)
            {
                numeri[i] = random.Next(0, 101);
               
            }
           return $"{numeri[0]}{numeri[1]}{numeri[2]}{numeri[3]}";

        }
        //METODO CONTROLLO PER DUPLICATI
        public bool Controllo(List<Studente> list)
        {
            return list.Any(p => p._nome.Equals(_nome, StringComparison.OrdinalIgnoreCase) && p._cognome.Equals(_cognome, StringComparison.OrdinalIgnoreCase));
        }
        //METODO OVERWRITE RITORNA SCRITTURA DATI DI STUDENTE
        new public string Scrivi()
        {
            return $"STUDENTE Nome:{_nome}, Cognome:{_cognome}, Genere:{_genere}, Eta:{_eta}, Scuola: {_scuola}, Matricola: {_matricola}";
        }
    }
}
