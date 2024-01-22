using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace RipassoOgg
{
    internal class Program
    {
        
        static void Inserimento(Flotta macchine)
        {
            bool valido;
            int scelta;
            Console.WriteLine("Inserire marca");
            string marca = Console.ReadLine();
            Console.WriteLine("Inserire modello");
            string modello = Console.ReadLine();
            do
            {
                Console.WriteLine("Selezionare numero di posti");
                for (int i = 0; i <= (int)Veicolo.numeroPosti.Otto; i++)
                {
                    Console.WriteLine($"{i + 1} - {(Veicolo.numeroPosti)i}");
                }
                valido = int.TryParse(Console.ReadLine(), out scelta);
            } while (!valido || scelta <= 0 || scelta > 4);
            Veicolo veicolo = new Veicolo(marca, modello, (Veicolo.numeroPosti)scelta - 1);
            macchine.AggiungeMacchina(veicolo);
            Console.Clear();
        }
        static int Menu(string TITOLO, string[] menu, int x, int y)
        {

            int lunghMenu;
            bool sceltaValida;
            int sceltaMenu;



            lunghMenu = menu.Length;
            Console.SetCursorPosition(x, y - 1);


            Console.WriteLine(TITOLO);
            for (int j = 0; j < menu.Length; j++)
            {
                Console.SetCursorPosition(x, y + j);
                Console.WriteLine($"[{j + 1}] {menu[j]}");

            }


            do
            {

                Console.SetCursorPosition(0, 2 * y);
                Console.WriteLine("Inserire la scelta:");
                sceltaValida = int.TryParse(Console.ReadLine(), out sceltaMenu);


                if (!sceltaValida || (sceltaMenu < 1 || sceltaMenu > lunghMenu))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Errore, è stata selezionata un'opzione non valida. Riprova");
                    Console.ForegroundColor = ConsoleColor.White;
                }

            } while (!sceltaValida || (sceltaMenu < 1 || sceltaMenu > lunghMenu));

            return sceltaMenu;
        }

        static void Main(string[] args)
        {

            string[] menu = { "1.Aggiunge", "2.Identificazione flotta", "3.Elimina", "4.Ricerca per targa/codice", "5.Ricerca per posti", "6.Salva su file", "7.Visualizza inventario", "8.Esce dal programma" };
            string[] menu2 = { "1.Targa", "2.Codice", "3.Torna al menu principale" };
            int x = 10, y = 20;
            int sceltaMenu;
            Console.WriteLine("Inserire nome della flotta");
            string nome = Console.ReadLine();
            Flotta macchine = new Flotta(nome);
            do
            {
                sceltaMenu = Menu("MENU", menu, x, y);
                switch (sceltaMenu)
                {
                    case 1:
                        Console.Clear();
                        Inserimento(macchine);
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Nome della flotta:" + " " + macchine.GetNome());
                        Console.WriteLine("Autorizzazione della flotta:" + " " + macchine.Getautorizzazione());
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        do
                        {
                            sceltaMenu = Menu("MENU", menu2, x, y);
                            switch (sceltaMenu)
                            {
                                case 1:
                                    Console.Clear();
                                    macchine.GetTarghe();
                                    Console.WriteLine("Inserire targa");
                                    string targa1 = Console.ReadLine().ToUpper();
                                    try
                                    {
                                        macchine.Elimina(targa1);
                                    }
                                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                                    Console.ReadLine();
                                    Console.Clear();

                                    break;
                                case 2:
                                    Console.Clear();
                                    macchine.GetCodici();
                                    bool controllo;
                                    do
                                    {
                                        Console.WriteLine("Inserire codice");
                                        controllo = int.TryParse(Console.ReadLine(), out int codice);
                                        if (controllo) { macchine.EliminaCodice(codice); }
                                        else { Console.WriteLine("codice invalido!"); }
                                    } while (!controllo);
                                    Console.ReadLine();
                                    Console.Clear();

                                    break;
                                case 3:
                                    Console.Clear();
                                    break;

                            }
                        } while (sceltaMenu != 3);
                        break;
                    case 4:
                        Console.Clear();
                        do
                        {

                            sceltaMenu = Menu("MENU", menu2, x, y);
                            switch (sceltaMenu)
                            {
                                case 1:
                                    Console.Clear();
                                    macchine.GetTarghe();
                                    Console.WriteLine("Inserire targa");
                                    string targa1 = Console.ReadLine().ToUpper();
                                    try
                                    {
                                        macchine.Ricerca(targa1);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;
                                case 2:
                                    Console.Clear();
                                    macchine.GetCodici();
                                    bool controllo;
                                    do
                                    {
                                        Console.WriteLine("Inserire codice");
                                        controllo = int.TryParse(Console.ReadLine(), out int codice);
                                        if (controllo) { macchine.RicercaCodice(codice); }
                                        else { Console.WriteLine("codice invalido!"); }
                                    } while (!controllo);
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;
                                case 3:
                                    Console.Clear();
                                    break;

                            }
                        } while (sceltaMenu != 3);
                        break;
                    case 5:

                        bool valido;
                        int posti;
                        do
                        {
                            Console.WriteLine("Selezionare numero di posti");
                            for (int i = 0; i <= (int)Veicolo.numeroPosti.Otto; i++)
                            {
                                Console.WriteLine($"{i + 1} - {(Veicolo.numeroPosti)i}");
                            }
                            valido = int.TryParse(Console.ReadLine(), out posti);
                        } while (!valido || posti < 0 || posti > 4);
                        try
                        {
                            macchine.RicercaPosti(posti - 1);
                        }
                        catch(Exception ex) { Console.WriteLine(ex.Message); }
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 6:
                        try { 
                        macchine.Save();
                        }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 7:
                        Console.Clear();
                        Console.WriteLine("Inserire marca");
                        string marca = Console.ReadLine();
                        try { 
                        macchine.StampaFlotta(marca);
                        }catch(Exception ex) { Console.WriteLine(ex.Message); }
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 8:
                        Console.Clear();
                        Console.WriteLine("Fine programma. Premi enter per uscire");
                        break;

                }
            } while (sceltaMenu != 8);




            Console.ReadLine();
        }
    }
}