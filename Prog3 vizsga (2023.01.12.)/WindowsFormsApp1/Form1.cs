using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string CsButton = "5";
        private int gy = 0;
        private int lepesszam = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            GombokGeneralasa();
        }
        private void GombokGeneralasa()
        {
            for(int i = 0; i < 9; i++)
            {
                Button b = new Button();
                this.Controls.Add(b);
                b.Name = ""+(i + 1);
                b.Text = "";
                b.Location = new Point(50 + i * 75 + i, 50);
                b.Size = new Size(75, 75);
                b.Click += new EventHandler(Kattintas);
            }
            Ujrakezdes();
        }
        private void Ujrakezdes()
        {
            CsButton = "5";
            lepesszam = 0;
            label1.Text = "Lépések száma: " + lepesszam;
            gy = 0;
            for (int i = 0; i < 9; i++)
            {
                if (i < 4)
                {
                    this.Controls.Find((i + 1).ToString(), true).FirstOrDefault().BackColor = Color.Red;
                }
                else if (i > 4)
                {
                    this.Controls.Find((i + 1).ToString(), true).FirstOrDefault().BackColor = Color.Lime;
                }
                else
                {
                    this.Controls.Find((i + 1).ToString(), true).FirstOrDefault().BackColor = Color.White;
                }
            }
        }
        private void Kattintas(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if ((Int32.Parse(b.Name)) < (Int32.Parse(CsButton)+3) && (Int32.Parse(b.Name)) > (Int32.Parse(CsButton) - 3) &&( Int32.Parse(b.Name)) != (Int32.Parse(CsButton)))
            {
                this.Controls.Find(CsButton, true).FirstOrDefault().BackColor = b.BackColor;
                b.BackColor = Color.White;
                CsButton = b.Name;
                for (int i = 0; i < 9; i++)
                {
                    if (i < 4 && this.Controls.Find((i + 1).ToString(), true).FirstOrDefault().BackColor == Color.Lime)
                    {
                        gy++;
                    }
                    else if (i > 4 && this.Controls.Find((i + 1).ToString(), true).FirstOrDefault().BackColor == Color.Red)
                    {
                        gy++;
                    }
                    else if (i == 5 && this.Controls.Find((i + 1).ToString(), true).FirstOrDefault().BackColor == Color.White)
                    {
                        gy++;
                    }
                }
                lepesszam++;
                label1.Text = "Lépések száma: " + lepesszam;
                if (gy == 8)
                {
                    DialogResult valasz = MessageBox.Show("Nyertél, felcserélted a színeket! Szeretnél mégegyszer játszani?","Játék vége", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (valasz == DialogResult.Yes)
                    {
                        Ujrakezdes();
                        
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
                gy = 0;
            }
        }
    }
}
