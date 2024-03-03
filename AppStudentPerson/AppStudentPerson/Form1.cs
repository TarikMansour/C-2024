using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppStudentPerson
{
    public partial class Form1 : Form
    {
        //DICHIARA LISTE
        List<Persona> list;
        List<Studente> list2;

        //INIZIALIZZAZIONE LISTE
        public Form1()
        {
            InitializeComponent();
            list = new List<Persona>();
            list2 = new List<Studente>();
        }
        //CONTROLLO STRINGHE VUOTE
        public bool Controllo()
        {
            return (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text));  
        }
        private void creaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //CREA PERSONE 
            if (Controllo())
            {
                MessageBox.Show("Errore di inserimento dei dati!", "Segnalazione");
                return;
            }
            Persona p = new Persona(textBox1.Text, textBox2.Text, textBox3.Text, Convert.ToInt32(textBox4.Text));
            //CONTROLLO DUPLICATI
            if (p.Controllo(list))
            {
                MessageBox.Show("Non sono permessi dati duplicati!", "Segnalazione");
            }
            else
            {
                list.Add(p);
            }
        }

        private void matricolaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //CREA STUDENTE
            if (Controllo())
            {
                MessageBox.Show("Errore di inserimento dei dati!", "Segnalazione");
                return;
            }
            Studente s = new Studente(textBox1.Text, textBox2.Text, textBox3.Text, Convert.ToInt32(textBox4.Text), textBox5.Text);
            //CONTROLLO DUPLICATI
            if (s.Controllo(list2))
            {
                MessageBox.Show("Non sono permessi dati duplicati!", "Segnalazione");
            }
            else
            {
                list2.Add(s);
            }
            
        }

        private void visualizzaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //VISUALIZZA SENZA RIPETERE GLI STESSI DATI
           foreach(Persona p in list)
           {
                if (!listBox1.Items.Contains(p.Scrivi()))
                {
                    listBox1.Items.Add(p.Scrivi());
                }
              
           }
           foreach (Studente s in list2)
           {
                if (!listBox1.Items.Contains(s.Scrivi()))
                {
                    listBox1.Items.Add(s.Scrivi());
                }
            }
           
        }
    }
}
