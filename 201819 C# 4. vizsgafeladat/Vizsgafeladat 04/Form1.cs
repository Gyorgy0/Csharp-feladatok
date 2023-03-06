using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Vizsgafeladat_04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private int sor = 0;
        private int oszlop = 0;
        private int meret = 50;
        private int helyes = 0;
        private int kiszam;
        private int helytelen = 0;
        Random rnd = new Random();

        private void Form1_Load(object sender, EventArgs e)
        {
            Kitalalas();
            GombokGeneralasa();
        }
        private void GombokGeneralasa()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Button b = new Button();
                    this.Controls.Add(b);
                    b.Click += new EventHandler(Kattintas);
                    b.Text = Convert.ToString((i+1) * (j + 1));
                    b.Size = new Size(meret, meret);
                    b.Name = (i) + "_" + (j);
                    b.Location = new Point(10 + (j * meret) + j, 75 + (i * meret) + i);
                    b.BackColor = Color.White;
                }
            }
        }
        private void Kitalalas()
        {
            sor = rnd.Next(1, 11);
            oszlop = rnd.Next(1, 11);
            kiszam = sor * oszlop;
            label1.Text = "Mennyi " + sor + " x " + oszlop + " ?";
        }

        private void Kattintas(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            sor = Convert.ToInt32(btn.Name[0].ToString());
            oszlop = Convert.ToInt32(btn.Name[2].ToString());
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    this.Controls.Find(Convert.ToString(i) + "_" + Convert.ToString(j), true).FirstOrDefault().BackColor = Color.White;
                }
            }
            if (Convert.ToInt32(btn.Text) == kiszam)
            {
                for (int i = 0; i < sor+1; i++)
                {
                    for (int j = 0; j < oszlop+1; j++)
                    {
                        this.Controls.Find(Convert.ToString(i) + "_" + Convert.ToString(j), true).FirstOrDefault().BackColor = Color.Orange;
                    }
                }
                helyes++;
                label2.Text = "Helyes válaszok száma: " + helyes;
                Kitalalas();
            }
            else if (Convert.ToInt32(btn.Text) != kiszam)
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        this.Controls.Find(Convert.ToString(i) + "_" + Convert.ToString(j), true).FirstOrDefault().BackColor = Color.White;
                    }
                }
                helytelen++;
                label3.Text = "Helytelen válaszok száma: " + helytelen;
            }
            if (helyes == 10) 
            {
                DialogResult valasz = MessageBox.Show("Hurrá, sikerült 10 feladatot helyesen megoldanod! Szeretnél játszani még egyet?", "Vége", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (valasz == DialogResult.Yes)
                {
                    Kitalalas();
                    helyes = 0;
                    helytelen = 0;
                    label2.Text = "Helyes válaszok száma: 0";
                    label3.Text = "Helytelen válaszok száma: 0";
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            this.Controls.Find(Convert.ToString(i) + "_" + Convert.ToString(j), true).FirstOrDefault().BackColor = Color.White;
                        }
                    }
                }
                else 
                {
                    Application.Exit();
                }
            }
        }
    }
}
