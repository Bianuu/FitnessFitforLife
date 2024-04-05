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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'baze_de_date_atestatDataSet.UTILIZATOR' table. You can move, or remove it, as needed.
            this.uTILIZATORTableAdapter.Fill(this.baze_de_date_atestatDataSet.UTILIZATOR);
            baze_de_date_atestatDataSet.EnforceConstraints = false;
        }
        public static int ID_curent;
        private void button1_Click(object sender, EventArgs e)
        {
            DataTable d = baze_de_date_atestatDataSet.UTILIZATOR;
            int verif = 0;
            if (textBox1.Text == "")
            {
                MessageBox.Show("Nu ati introdus Nume_Cont!");
                textBox1.Text = "";

                verif = 0;
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Nu ati introdus Parola!");
                textBox2.Text = "";

                verif = 0;
            }
            else if (d.Rows[0]["Nume_cont"].ToString().Trim(' ') == textBox1.Text && d.Rows[0]["Parola"].ToString().Trim(' ') == textBox2.Text)
            {
                this.Hide();
                Form5 activate5 = new Form5();
                activate5.ShowDialog();
                this.Close();
            }
            else
            {
                for (int i = 1; i < d.Rows.Count; i++)
                {
                    int okverif1 = 0;
                    if (d.Rows[i]["Nume_cont"].ToString().Trim(' ') == textBox1.Text)
                    {
                        okverif1 = 1;
                    }

                    if (okverif1 == 1)
                    {
                        int okverif2 = 0;
                        if (d.Rows[i]["Parola"].ToString().Trim(' ') == textBox2.Text)
                        {
                            okverif2 = 1;
                        }

                        if (okverif1 == 1 && okverif2 == 1)
                        {
                            verif = 1;
                            ID_curent = i + 1;
                        }
                    }
                }

                if (verif == 0)
                {
                    MessageBox.Show("Ati introdus Parola sau Nume_Cont gresit!");
                    textBox2.Text = "";
                    textBox1.Text = "";
                }
                else
                {
                    this.Hide();
                    Form4 activate4 = new Form4();
                    activate4.ShowDialog();
                    this.Close();

                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 activate2 = new Form2();
            activate2.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 activate1 = new Form1();
            activate1.ShowDialog();
            this.Close();
        }
    }

}