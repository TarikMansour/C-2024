using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Geometria
{
    public partial class Form1 : Form
    {
        //Punto p;
        public Form1()
        {
            InitializeComponent();
            
        }
        List<Rettangolo> rettangolos = new List<Rettangolo>();
        List<Parallelepipedo> parallelepipedos = new List<Parallelepipedo>();
        List<Quadrato> quadratos = new List<Quadrato>();
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void creaPuntoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Punto p1 = new Punto(Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox1.Text));
            listBox1.Items.Add(p1.Scrivi());
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            creaPuntoToolStripMenuItem.Enabled = textBox2.Text != "" && textBox1.Text != "";

        }

        private void creaRettangoloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Punto p1 = new Punto(Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox1.Text));
            Rettangolo r1 = new Rettangolo(p1, Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text));
            rettangolos.Add(r1);
            listBox1.Items.Add(r1.Scrivi());
        }

        private void creaQuadratoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Punto p1 = new Punto(Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox1.Text));
            Quadrato q1 = new Quadrato(p1, Convert.ToInt32(textBox5.Text));
            quadratos.Add(q1);
            listBox1.Items.Add(q1.Scrivi());
        }

        private void arToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Punto p1 = new Punto(Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox1.Text));
            Parallelepipedo para1 = new Parallelepipedo(p1, Convert.ToInt32(textBox6.Text), Convert.ToInt32(textBox7.Text), Convert.ToInt32(textBox8.Text));
            parallelepipedos.Add(para1);
            listBox1.Items.Add(para1.Scrivi());
        }

        private void caricaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(Rettangolo r in rettangolos)
            {
                listBox2.Items.Add(r.Scrivi());
            }
            foreach (Parallelepipedo p in parallelepipedos)
            {
                listBox2.Items.Add(p.Scrivi());
            }
            foreach (Quadrato q in quadratos)
            {
                listBox2.Items.Add(q.Scrivi());
            }

        }
    }
}
