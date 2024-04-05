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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Visible = true;
            chart2.Visible = true;
            chart3.Visible = true;
            int f = int.Parse(uTILIZATORTableAdapter.Sexfeminin().ToString());
            int b = int.Parse(uTILIZATORTableAdapter.Sexmasculin().ToString());
            int el = int.Parse(uTILIZATORTableAdapter.numarelevi().ToString());
            foreach (var series in this.chart1.Series)
            {
                series.Points.Clear();
            }
            this.chart1.Series["Persoane"].Points.AddXY("Barbati", b - 1);
            this.chart1.Series["Persoane"].Points.AddXY("Femei", f);
            this.chart1.Series["Persoane"].Points.AddXY("Elev/Studenti", el - 1);

            int fm = int.Parse(uTILIZATORTableAdapter.faramail().ToString());
            int cm = int.Parse(uTILIZATORTableAdapter.cumail().ToString());
            foreach (var series in this.chart2.Series)
            {
                series.Points.Clear();
            }
            this.chart2.Series["E_mail"].Points.AddXY("AU", cm - 1);
            this.chart2.Series["E_mail"].Points.AddXY("NU AU", fm);

            float ch = float.Parse(uTILIZATORTableAdapter.cashh().ToString());
            int cd = int.Parse(uTILIZATORTableAdapter.card().ToString());
            foreach (var series in this.chart3.Series)
            {
                series.Points.Clear();
            }

            this.chart3.Series["Tip_plata(in %)"].IsValueShownAsLabel = true;
            this.chart3.Series["Tip_plata(in %)"].Points.AddXY("CASH(in %)", Math.Round((ch * 100) / (ch + cd) * 1.0, 2));
            this.chart3.Series["Tip_plata(in %)"].Points.AddXY("CARD(in %)", Math.Round((cd * 100) / (ch + cd) * 1.0, 2));

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'baze_de_date_atestatDataSet.REZERVARE' table. You can move, or remove it, as needed.
            this.rEZERVARETableAdapter.Fill(this.baze_de_date_atestatDataSet.REZERVARE);
            // TODO: This line of code loads data into the 'baze_de_date_atestatDataSet3.ANGAJAT' table. You can move, or remove it, as needed.
            this.aNGAJATTableAdapter.Fill(this.baze_de_date_atestatDataSet3.ANGAJAT);
            // TODO: This line of code loads data into the 'baze_de_date_atestatDataSet2.TIPURI_ABONAMENTE' table. You can move, or remove it, as needed.
            this.tIPURI_ABONAMENTETableAdapter.Fill(this.baze_de_date_atestatDataSet2.TIPURI_ABONAMENTE);
            // TODO: This line of code loads data into the 'baze_de_date_atestatDataSet1.STATISTICA_GREUTATE' table. You can move, or remove it, as needed.
            this.sTATISTICA_GREUTATETableAdapter.Fill(this.baze_de_date_atestatDataSet1.STATISTICA_GREUTATE);
            // TODO: This line of code loads data into the 'baze_de_date_atestatDataSet.ANGAJAT' table. You can move, or remove it, as needed.
            this.aNGAJATTableAdapter.Fill(this.baze_de_date_atestatDataSet.ANGAJAT);
            // TODO: This line of code loads data into the 'baze_de_date_atestatDataSet.ABONAMENTELE_FIECARUIA' table. You can move, or remove it, as needed.
            this.aBONAMENTELE_FIECARUIATableAdapter.Fill(this.baze_de_date_atestatDataSet.ABONAMENTELE_FIECARUIA);
            // TODO: This line of code loads data into the 'baze_de_date_atestatDataSet.UTILIZATOR' table. You can move, or remove it, as needed.
            this.uTILIZATORTableAdapter.Fill(this.baze_de_date_atestatDataSet.UTILIZATOR);
            baze_de_date_atestatDataSet.EnforceConstraints = false;
        }

        private void totiClientiiCareAuUnAboanemtnValabilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox3.Text = "";
            tabControl1.SelectedTab = tabPage2;
            DataTable d = baze_de_date_atestatDataSet.STATISTICA_GREUTATE;

            sTATISTICA_GREUTATETableAdapter.progresregres(baze_de_date_atestatDataSet.STATISTICA_GREUTATE);

            for (int i = 0; i < d.Rows.Count; i++)
                richTextBox3.Text += "*  " + d.Rows[i]["Nume"].ToString() + d.Rows[i]["Prenume"] + d.Rows[i]["varsta"] + "    " + d.Rows[i]["Judet"] + d.Rows[i]["Localitatea"].ToString() + d.Rows[i]["Diferenta_dintre_masa_corporala_initiala_si_cea_actuala"] + "        " + d.Rows[i]["progres"] + '\n';

            richTextBox3.SelectAll();
            richTextBox3.SelectionAlignment = HorizontalAlignment.Left;
            richTextBox3.DeselectAll();
        }

        private void statisitcaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void nrpersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
            chart1.Visible = false;
            chart2.Visible = false;
            chart3.Visible = false;

        }

        private void abonamentulSolicitatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            richTextBox2.Text = "";
            richTextBox2.Visible = false;
            label2.Visible = false;
            label31.Visible = false;
            label32.Visible = false;
            DataTable d = baze_de_date_atestatDataSet.ABONAMENTELE_FIECARUIA;
            DataTable d1 = baze_de_date_atestatDataSet.ANGAJAT;
            DateTime todaysDate = DateTime.Today;
            int x = 0;
            int z = 0;
            int okan = 1;
            if (textBox1.Text == "")
            {
                MessageBox.Show("Nu ati introdus niciun An!");
                textBox3.Text = "";
                textBox4.Text = "";
            }
            else
            {
                for (int i = 0; i < textBox1.Text.Length; i++)
                {
                    if (!(textBox1.Text[i] >= '0' && textBox1.Text[i] <= '9')) okan = 0;
                }
                if (okan == 0)
                {
                    MessageBox.Show("Nu ati introdus un An valid!");
                    textBox3.Text = "";
                    textBox4.Text = "";
                }
                else
                {
                    z = int.Parse(textBox1.Text);
                    if (z < 2019)
                    {
                        MessageBox.Show("Nu a existat firma in acea perioada!");
                        textBox3.Text = "";
                        textBox4.Text = "";
                    }
                    else
                    {
                        if (z > int.Parse(todaysDate.Year.ToString()))
                        {
                            MessageBox.Show("Nu am ajuns inca in acel An!");
                            textBox3.Text = "";
                            textBox4.Text = "";
                        }
                        else
                        {
                            int okver = 1;
                            if (comboBox1.SelectedIndex > -1) x = comboBox1.SelectedIndex + 1;
                            else
                            {
                                MessageBox.Show("Nu ati selectat nicio Luna!");
                                textBox3.Text = "";
                                textBox4.Text = "";
                                okver = 0;
                            }

                            if (okver == 1)
                            {
                                if (x > int.Parse(todaysDate.Month.ToString()) && z == int.Parse(todaysDate.Year.ToString()))
                                {
                                    MessageBox.Show("Nu am ajuns inca in acea Luna!");
                                    textBox3.Text = "";
                                    textBox4.Text = "";
                                }
                                else
                                {
                                    textBox3.Text = x.ToString();
                                    textBox4.Text = z.ToString();
                                    int ok = 0;
                                    aBONAMENTELE_FIECARUIATableAdapter.abonamentxy(baze_de_date_atestatDataSet.ABONAMENTELE_FIECARUIA, x, z);

                                    for (int i = 0; i < d.Rows.Count; i++)
                                    {
                                        richTextBox2.Text += d.Rows[i]["Denumire"].ToString() + d.Rows[i]["Solicitari"] + '\n';
                                        ok = 1;
                                    }
                                    if (ok == 0) MessageBox.Show("Nimenui nu si-a creat vreun abonament in acea Luna!");
                                    else
                                    {
                                        richTextBox2.Visible = true;
                                        label2.Visible = true;
                                        label31.Visible = true;
                                        label32.Visible = true;
                                    }
                                    aNGAJATTableAdapter.salariipexy(baze_de_date_atestatDataSet.ANGAJAT, x, z);
                                    for (int i = 0; i < d1.Rows.Count; i++)
                                        richTextBox1.Text += d1.Rows[i]["Nume"].ToString() + d1.Rows[i]["Prenume"] + d1.Rows[i]["Profesie"] + d1.Rows[i]["Bani_incasati"].ToString() + '\n';

                                    richTextBox1.SelectAll();
                                    richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
                                    richTextBox1.DeselectAll();

                                }
                            }
                        }
                    }
                }
            }
            textBox1.Text = "";
            comboBox1.Text = "";
            comboBox1.SelectedIndex = -1;

        }

        private void ceaMaiProfitabilaLunaSiaNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage4;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox4.Text = "";

            DataTable d = baze_de_date_atestatDataSet.ABONAMENTELE_FIECARUIA;
            DateTime todaysDate = DateTime.Today;
            int z = 0;
            if (textBox2.Text == "")
            {
                MessageBox.Show("Nu ati introdus niciun An!");
                textBox5.Text = "";
            }
            else
            {
                int okan = 1;
                for (int i = 0; i < textBox2.Text.Length; i++)
                {
                    if (!(textBox2.Text[i] >= '0' && textBox2.Text[i] <= '9')) okan = 0;
                }
                if (okan == 0)
                {
                    MessageBox.Show("Nu ati introdus un An valid!");
                    textBox2.Text = "";
                    textBox5.Text = "";
                }
                else
                {
                    z = int.Parse(textBox2.Text);
                    if (z < 2019)
                    {
                        MessageBox.Show("Nu a existat firma in acel An!");
                        textBox5.Text = "";
                    }
                    else
                    {
                        if (z > int.Parse(todaysDate.Year.ToString()))
                        {
                            MessageBox.Show("Nu am ajuns inca in acel An!");
                            textBox5.Text = "";
                        }
                        else
                        {
                            textBox5.Text = z.ToString();
                            aBONAMENTELE_FIECARUIATableAdapter.abonanx(baze_de_date_atestatDataSet.ABONAMENTELE_FIECARUIA, z);
                            for (int i = 0; i < d.Rows.Count; i++)
                                richTextBox4.Text += d.Rows[i]["Denumire"].ToString() + d.Rows[i]["NR"] + '\n';
                            aBONAMENTELE_FIECARUIATableAdapter.restabonamente(baze_de_date_atestatDataSet.ABONAMENTELE_FIECARUIA, z);
                            for (int i = 0; i < d.Rows.Count; i++)
                                richTextBox4.Text += d.Rows[i]["Denumire"].ToString() + 0 + '\n';

                            richTextBox4.SelectAll();
                            richTextBox4.SelectionAlignment = HorizontalAlignment.Left;
                            richTextBox4.DeselectAll();
                        }

                    }
                }
            }
            textBox2.Text = "";
        }

        private void anulXAboanemtneDeFirecareTipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox5.Text = "";
            richTextBox6.Text = "";
            tabControl1.SelectedTab = tabPage5;
            DataTable d = baze_de_date_atestatDataSet.ABONAMENTELE_FIECARUIA;
            aBONAMENTELE_FIECARUIATableAdapter.persinvarsta(baze_de_date_atestatDataSet.ABONAMENTELE_FIECARUIA);
            for (int i = 0; i < d.Rows.Count; i++)
                richTextBox5.Text += d.Rows[i]["Nume"].ToString() + d.Rows[i]["Prenume"] + d.Rows[i]["varsta"] + "                  " + d.Rows[i]["Numar"].ToString() + '\n';
            DataTable d1 = baze_de_date_atestatDataSet.TIPURI_ABONAMENTE;
            tIPURI_ABONAMENTETableAdapter.lumamaxincasare(baze_de_date_atestatDataSet.TIPURI_ABONAMENTE);
            for (int i = 0; i < d1.Rows.Count; i++)
                richTextBox6.Text += d1.Rows[i]["Anul"].ToString() + "    " + d1.Rows[i]["Luna"].ToString() + "         " + d1.Rows[i]["Expr1"].ToString() + '\n';
            richTextBox5.SelectAll();
            richTextBox5.SelectionAlignment = HorizontalAlignment.Left;
            richTextBox5.DeselectAll();
            richTextBox6.SelectAll();
            richTextBox6.SelectionAlignment = HorizontalAlignment.Left;
            richTextBox6.DeselectAll();
        }

        private void angajatiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox8.Text = "";
            tabControl1.SelectedTab = tabPage6;
            DataTable d = baze_de_date_atestatDataSet.ANGAJAT;
            aNGAJATTableAdapter.angajatiii(baze_de_date_atestatDataSet.ANGAJAT);
            for (int i = 0; i < d.Rows.Count; i++)
                richTextBox8.Text += "*  " + d.Rows[i]["Nume"].ToString() + d.Rows[i]["Prenume"].ToString() + d.Rows[i]["Profesie"] + d.Rows[i]["Salariu"].ToString() + "    " + d.Rows[i]["Nr_telefon"].ToString() + "    " + d.Rows[i]["Program_incepere"].ToString() + "    " + d.Rows[i]["Program_sfarsit"].ToString() + '\n';

            richTextBox8.SelectAll();
            richTextBox8.SelectionAlignment = HorizontalAlignment.Left;
            richTextBox8.DeselectAll();
        }

        private void clientiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox7.Text = "";
            tabControl1.SelectedTab = tabPage7;
            DataTable d = baze_de_date_atestatDataSet.UTILIZATOR;
            uTILIZATORTableAdapter.clienti(baze_de_date_atestatDataSet.UTILIZATOR);
            for (int i = 0; i < d.Rows.Count; i++)
                richTextBox7.Text += "*  " + d.Rows[i]["Nume"].ToString() + d.Rows[i]["Prenume"].ToString() + d.Rows[i]["Data_nasterii"].ToString().Remove(10) + "    " + d.Rows[i]["Nr_telefon"].ToString() + "  " + d.Rows[i]["CNP"].ToString() + "  " + d.Rows[i]["Judet"].ToString() + d.Rows[i]["Localitatea"].ToString() + '\n' + d.Rows[i]["E_mail"].ToString() + d.Rows[i]["Greutate"].ToString() + "   " + d.Rows[i]["Inaltime"].ToString() + "   " + d.Rows[i]["Data_creare_cont"].ToString().Remove(10) + "    " + d.Rows[i]["Recuperare_cont"].ToString() + '\n';
            richTextBox7.ReadOnly = true;
            richTextBox7.SelectAll();
            richTextBox7.SelectionAlignment = HorizontalAlignment.Left;
            richTextBox7.DeselectAll();
        }

        private void rezervarilePtUnCangajatXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage8;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox9.Text = "";
            DataTable d = baze_de_date_atestatDataSet.REZERVARE;
            DateTime todaysDate = DateTime.Today;
            int x = 0;
            int oka = 0;
            if (checkedListBox1.SelectedIndex > -1)
            {
                x = checkedListBox1.SelectedIndex + 1;
                oka = 1;
            }
            if (oka == 0) MessageBox.Show("Nu ati selectat niciun Antrenor!");
            else
            {
                textBox6.Text = checkedListBox1.Items[x - 1].ToString();
                textBox7.Text = todaysDate.Month.ToString();
                textBox8.Text = todaysDate.Year.ToString();
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (checkedListBox1.GetItemCheckState(i) == CheckState.Checked) checkedListBox1.SetItemChecked(i, false);
                }
                rEZERVARETableAdapter.rezervarilealeluix(baze_de_date_atestatDataSet.REZERVARE, x);
                int ok = 0;
                for (int i = 0; i < d.Rows.Count; i++)
                {
                    richTextBox9.Text += d.Rows[i]["Nume"] + "  " + d.Rows[i]["Prenume"].ToString() + d.Rows[i]["Data_ora_rezervare"].ToString() + '\n';
                    ok = 1;
                }
                if (ok == 0)
                {
                    MessageBox.Show("Momentan acest antrenor nu are rezervari!");
                    richTextBox9.Visible = false;
                    label19.Visible = false;
                    label38.Visible = false;
                    textBox6.Visible = false;

                }
                else
                {
                    richTextBox9.Visible = true;
                    label19.Visible = true;
                    label38.Visible = true;
                    textBox6.Visible = true;

                }
            }
            checkedListBox1.SelectedIndex = -1;
            richTextBox9.SelectAll();
            richTextBox9.SelectionAlignment = HorizontalAlignment.Left;
            richTextBox9.DeselectAll();
        }

        private void menToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 activate1 = new Form1();
            activate1.ShowDialog();
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }
    }
}