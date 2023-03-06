using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vizsgafeladat__2023._02._02_13_00_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Random rnd = new Random();
        private Button[] btn = new Button[10];
        private int meret = 75;
        private int[] sargaalakpoz = new int[5];
        private int[] kekalakpoz = new int[5];
        private void Form1_Load(object sender, EventArgs e)
        {
            Alakokgeneralasa();
            Kockakgeneralasa();
        }
        private void Alakokgeneralasa() 
        {
            int szamlalo=0;
            for (int i = 0; i < 5; i++)
            {
                sargaalakpoz[i] = rnd.Next(2);
                kekalakpoz[i] = rnd.Next(2, 4);
                if (3-kekalakpoz[i] == sargaalakpoz[i]) 
                {
                    szamlalo++;
                }
            }
            int tomb=0;
            while (szamlalo == 5)
            {
                kekalakpoz[tomb] = rnd.Next(2,4);
                tomb++;
                if (sargaalakpoz[tomb] != kekalakpoz[tomb])
                {
                    szamlalo = 0;
                }
                else 
                {
                    tomb = 0;
                }
            }
        }
        private void Kattintas(object sender, EventArgs e) 
        {
            Button b = (Button)sender;
            int szamlalo = 0;
            if (kekalakpoz[Convert.ToInt32((b.Name).ToString())-5] == 2)
            {
                kekalakpoz[Convert.ToInt32((b.Name).ToString())-5] = 3;
                b.Location = new Point(20 + kekalakpoz[Convert.ToInt32((b.Name).ToString())-5] * meret, 25 + ((Convert.ToInt32((b.Name).ToString()) - 5) * meret));
            }
            else if (kekalakpoz[Convert.ToInt32((b.Name).ToString())-5] == 3) 
            {
                kekalakpoz[Convert.ToInt32((b.Name).ToString())-5] = 2;
                b.Location = new Point(20 + kekalakpoz[Convert.ToInt32((b.Name).ToString())-5] * meret, 25 + ((Convert.ToInt32((b.Name).ToString()) - 5) * meret));
            }
            for (int i = 0; i < 5; i++)
            {
                if (sargaalakpoz[i] == 3 - kekalakpoz[i])
                {
                    szamlalo++;
                }
                if (sargaalakpoz[i] != 3 - kekalakpoz[i])
                {
                    szamlalo--;
                }
            }
            if (szamlalo == 5)
            {
                MessageBox.Show("Sikerült kirakni!", "Gratulálok!", MessageBoxButtons.OK);
                Alakokgeneralasa();
                this.Controls.Clear();
                Kockakgeneralasa();
            }
        }
        private void Kockakgeneralasa() 
        {
            for (int i = 0; i < 10; i++)
            {
                btn[i] = new Button();
                this.Controls.Add(btn[i]);
                btn[i].Name = Convert.ToString(i);
                btn[i].Size = new Size(meret, meret);
                btn[i].Click += new EventHandler(Kattintas);
                if (i > 4)
                {
                    btn[i].Location = new Point(20 + (kekalakpoz[i-5] * meret), 25 + ((i-5) * meret));
                    btn[i].BackColor = Color.Blue;
                }
                else
                {
                    btn[i].Enabled = false;
                    btn[i].Location = new Point(20 + (sargaalakpoz[i] * meret), 25 + (i * meret));
                    btn[i].BackColor = Color.Orange;
                }
            }
        }
    }
}
