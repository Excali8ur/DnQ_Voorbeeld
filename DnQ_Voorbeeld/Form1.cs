using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DnQ_Voorbeeld
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<int> test = new List<int> { 12, 10, 24, 53, 8, 54, 13 };
            test = DnQ(test, test.Count);
            textBox1.AppendText(string.Join(" ", test));
        }

        private List<int> DnQ(List<int> rij, int n)
        {
            //Startstap:
            if (n == 1) { return rij; }
            else {
                //Probleem verkleinen:
                int x = n - 1;
                int laatste = rij[n - 1];
                rij.RemoveAt(rij.Count - 1);
                textBox1.AppendText(string.Join(" ", rij));
                textBox1.AppendText("\n");
                rij = DnQ(rij, x);
                //Samenvoegen:
                bool inserted = false;
                for (int i = 0; i < rij.Count && !inserted; i++){
                    if (rij[i] > laatste){
                        rij.Insert(i, laatste);
                        inserted = true;
                    }
                }
                if (!inserted) { rij.Add(laatste); }
                textBox1.AppendText(string.Join(" ", rij));
                textBox1.AppendText("\n");
                return rij;

            }

        }
    }
}
