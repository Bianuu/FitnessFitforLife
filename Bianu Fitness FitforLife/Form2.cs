using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bianu_Fitness_FitforLife
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int verif = 0;
            int ok = 0;
            DataTable d = baze_de_date_atestatDataSet.UTILIZATOR;
            if (textBox1.Text == "")
            {
                MessageBox.Show("Va rugum sa va introduceti COD_Recuperare_Cont!");
                textBox1.Text = "";
                verif = 0;
                ok = 1;
            }
            else
            {
                for (int i = 1; i < d.Rows.Count; i++)
                {
                    if (d.Rows[i]["Recuperare_cont"].ToString().Trim(' ') == textBox1.Text)
                    {
                        verif = 1;
                        string s = "";
                        s = s + "Nume_Cont :" + d.Rows[i]["Nume_cont"].ToString().Trim(' ') + '\n' + "Parola :" + d.Rows[i]["Parola"].ToString().Trim(' ');
                        MessageBox.Show(s);
                    }
                }
            }
            if (verif == 0 && ok == 0)
            {
                MessageBox.Show("Acest COD_Recuperare_Cont nu corespunde niciunui client!Reintroduceti-l,iar daca aveti aceeasi problema,contactati developerul din meniu!");
                textBox1.Text = "";
            }
            if (verif == 1)
            {

                this.Hide();
                Form3 activate3 = new Form3();
                activate3.ShowDialog();
                this.Close();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'baze_de_date_atestatDataSet.UTILIZATOR' table. You can move, or remove it, as needed.
            this.uTILIZATORTableAdapter.Fill(this.baze_de_date_atestatDataSet.UTILIZATOR);
            baze_de_date_atestatDataSet.EnforceConstraints = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 activate3 = new Form3();
            activate3.ShowDialog();
            this.Close();
        }

    }
}