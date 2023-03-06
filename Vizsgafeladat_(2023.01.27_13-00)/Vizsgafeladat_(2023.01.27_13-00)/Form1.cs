using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vizsgafeladat__2023._01._27_13_00_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private int feherek_szama = 0;
        private string[] szin = {"Black", "White"};
        private Random rnd = new Random();
        private int meret = 75;
        private Button[,] b = new Button[5, 5];
        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    b[i, j] = new Button();
                    this.Controls.Add(b[i,j]);
                    b[i, j].Size = new Size(meret,meret);
                    b[i, j].Location = new Point(10+j*meret+j,10+i*meret+i);
                    b[i, j].Click += new EventHandler(Kattintas);
                }
            }
            KockakKeverese();
        }
        private void KockakKeverese() 
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    b[i, j].BackColor = Color.FromName(szin[rnd.Next(2)]);
                }
            }
            timer1.Enabled = true;
        }

        private void Kattintas(object sender, EventArgs e) 
        {
            Button btn = (Button)sender;
            if (btn.BackColor == Color.Black)
            {
                btn.BackColor = Color.White;
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (b[i, j].BackColor == Color.White)
                        {
                            feherek_szama++;
                        }
                        if (feherek_szama == 25)
                        {
                            timer1.Enabled = false;
                            DialogResult valasz = MessageBox.Show("Hurrá, sikerült kifehéríteni! Szeretnél megint játszani?", "Gratulálunk!", MessageBoxButtons.OK);
                            if (valasz == DialogResult.OK)
                            {
                                KockakKeverese();
                            }
                        }
                    }
                }
                feherek_szama = 0;
            }
            else 
            {
                KockakKeverese();
                feherek_szama = 0;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            KockakKeverese();
            feherek_szama = 0;
        }
    }
}
