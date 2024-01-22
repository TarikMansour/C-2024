using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RipassoOgg
{
    internal class Flotta
    {
        List<Veicolo> macchine;
        int nmacchine = 0;
        string _autorizzazione;
        string _nome;
        public static int codice;

        public Flotta(string nome)
        {
            macchine = new List<Veicolo>(nmacchine);
            _autorizzazione = Setautorizzazione();
            _nome = nome;

        }
        public void AggiungeMacchina(Veicolo auto)
        {
            auto.SetTarga();
            nmacchine++;
            codice++;
            auto.Codice = codice;
            macchine.Add(auto);
        }

        public string GetNome()
        {
            return _nome;
        }

        public string Setautorizzazione()
        {
            Random random = new Random();
            int[] numeri = new int[5];
            char[] vocali = { 'A', 'E', 'I', 'O', 'U' };
            for (int i = 0; i < 5; i++)
            {
                int valore = random.Next(0, 10);
                numeri[i] = valore;
            }
            int index = random.Next(0, 5);
            string autorizzazione = $"{numeri[0]}{numeri[1]}{numeri[2]}{numeri[3]}{numeri[4]}{vocali[index]}";

            return autorizzazione;
        }
        public string Getautorizzazione()
        {
            return _autorizzazione;
        }
        public void StampaFlotta(string marca)
        {
            int counter = 0;
          
                if (RitornaLista().Count > 0)
                {
                    List<Veicolo> veicoli;
                    veicoli = RitornaLista().FindAll(p => p.Marca == marca);
                    if(veicoli.Count > 0) 
                    {
                        counter = veicoli.Count;
                        foreach (Veicolo v in veicoli)
                        {
                            Console.WriteLine(v.ToString());
                        }
                        Console.WriteLine($"Ci sono {counter} macchine appartenenti a questa marca");
                    }
                    else
                    {
                        throw new Exception("Nessun veicolo di questa marca trovato");
                    }

                   
                }
                else
                {
                    throw new Exception("Non ci sono macchine");
                }
            
          
        }
        public void Ricerca(string targa)
        {
            if (RitornaLista().Count > 0)
            {
                Veicolo veicolo = RitornaLista().Find(v => v.Targa == targa);
                if (veicolo != null)
                {
                    Console.WriteLine(veicolo.ToString());
                }
                else
                {
                    throw new Exception("Nessun veicolo trovato");
                }
            }
            else
            {
                throw new Exception("Non ci sono macchine");
            }
        }
        //Tutte le modifiche vengono fatte alla copia e non sulla lista originale -> incapsulamento 
        public List<Veicolo> RitornaLista()
        {
            List<Veicolo> copia;
            copia = macchine;
            return copia;
        }
        public void RicercaPosti(int num)
        {


            if (RitornaLista().Count > 0)
            {
                List<Veicolo> veicoli = RitornaLista().FindAll(v => v.Posti == (Veicolo.numeroPosti)num);
                if (veicoli.Count > 0)
                {
                    foreach (Veicolo veicolo in veicoli)
                    {
                        Console.WriteLine(veicolo.ToString());
                    }
                }
                else
                {
                    throw new Exception("Nessuna macchina trovata");
                }

            }
            else
            {
                throw new Exception("Non ci sono macchine");
            }


        }
        public void RicercaCodice(int num)
        {

            try
            {
                if (RitornaLista().Count > 0)
                {

                    Veicolo veicolo = RitornaLista().Find(v => v.Codice == num);
                    if (veicolo != null)
                    {
                        Console.WriteLine(veicolo.ToString());
                    }
                    else
                    {
                        throw new Exception();
                    }

                }

                else
                {
                    throw new Exception("Nessun veicolo trovato");
                }
            }
            catch (Exception) { Console.WriteLine("Non ci sono macchine"); }
        }
        public void GetTarghe()
        {
            try
            {
                if (RitornaLista().Count > 0)
                {
                    Console.WriteLine("Targhe di tutte le macchine:");
                    for (int i = 0; i < RitornaLista().Count; i++)
                    {
                        Console.WriteLine($"{i + 1} - {RitornaLista()[i].Targa}");
                    }
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception) { Console.WriteLine("Non ci sono macchine"); }
        }
        public void GetCodici()
        {
            try
            {
                if (RitornaLista().Count > 0)
                {
                    Console.WriteLine("Codice di tutte le macchine:");
                    for (int i = 0; i < RitornaLista().Count; i++)
                    {
                        Console.WriteLine($"{i + 1} - {RitornaLista()[i].Codice}");
                    }
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception) { Console.WriteLine("Non ci sono macchine"); }
        }
        public void Elimina(string targa)
        {
            if (macchine.Count > 0)
            {
                Veicolo veicolo = RitornaLista().Find(v => v.Targa == targa);
                if (veicolo != null)
                {

                    RitornaLista().Remove(veicolo);
                    Console.WriteLine("Il seguente veicolo è stato eliminato: " + veicolo.ToString());
                }
                else
                {
                    throw new Exception("Nessun veicolo trovato");
                }
            }
            else
            {
                throw new Exception("Nessuna macchina inserita");
            }

        }
        public void EliminaCodice(int num) 
        {
            List<Veicolo> veicoli = RitornaLista();
                if (veicoli.Count > 0)
                {
                int index = veicoli.FindIndex(p => p.Codice == num);
                    if (index != -1)
                    {
                    Console.WriteLine("Il veicolo: " + veicoli.ElementAt(index).ToString());
                    veicoli.RemoveAt(index);
                    
                    }
                    else
                    {
                        throw new Exception("Non ci sono macchine");
                    }
                       
                }
              
        }
        public void Save()
        {
            string fileName = "output.txt";
            string filePath = Path.Combine(Environment.CurrentDirectory, fileName);
            StreamWriter file = new StreamWriter(filePath);
         
                if (RitornaLista().Count > 0)
                {

                    foreach (Veicolo auto in RitornaLista())
                    {
                        file.WriteLine(auto.ToString());

                    }
                    file.Close();
                    Console.WriteLine("Output saved to: " + fileName);


                }
                else
                {
                    throw new Exception("Non ci sono macchine");
                }
            
           
        }

    }


}