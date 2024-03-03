using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStudentPerson
{
    internal class Persona
    {
        //ATTRIBUTI CHE FANNO PARTE DELLA GERARCHIA 
       protected string _nome, _cognome, _genere;
        protected int _eta;
       
        //COSTRUTTORE
        public Persona(string nome, string cognome, string genere, int eta ) {
            _nome = nome;
            _cognome = cognome;
            _genere = genere;
            _eta = eta;
           
        }
        //METODO CONTROLLA DUPLICATI
        public bool Controllo(List<Persona> list)
        {
           return list.Any(p => p._nome.Equals(_nome, StringComparison.OrdinalIgnoreCase) && p._cognome.Equals(_cognome, StringComparison.OrdinalIgnoreCase));
        }
        //METODO RITORNA SCRITTURA DATI DI PERSONA
        public string Scrivi()
        {
            return $"PERSONA Nome:{_nome}, Cognome:{_cognome}, Genere:{_genere}, Eta:{_eta}";
        }

    }
}
