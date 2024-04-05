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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            tabControl1.SelectedTab = tabPage10;
        }

        private void alegeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (okactualizaredate == 0) MessageBox.Show("Trebuie sa va actualizati datele!");
            else tabControl1.SelectedTab = tabPage1;
        }
        public static int idabon = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            DataTable d = baze_de_date_atestatDataSet.ABONAMENTELE_FIECARUIA;
            DataTable d1 = baze_de_date_atestatDataSet.TIPURI_ABONAMENTE;
            int z = int.Parse(rEZERVARETableAdapter.nrrezervari(Form3.ID_curent).ToString());
            DateTime todaysDate = DateTime.Today;
            int q = d.Rows.Count;
            q++;
            int verif = 0;
            int verif1 = 0;
            if (dateTimePicker1.Text.Contains("duminică"))
            {
                MessageBox.Show("Nu se pot crea abonamente duminica.Va rugam alegeti alta zi!");
            }
            else if (dateTimePicker1.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Nu se pot crea abonamente,cu o data anterioara datei actuale!");
            }
            else if (comboBox1.Text != "")
            {

                if (comboBox1.Text[1] == '.') idabon = comboBox1.Text[0] - '0';
                else
                {
                    idabon = (comboBox1.Text[0] - '0') * 10 + (comboBox1.Text[1] - '0');
                }
                int ok = 0;
                for (int i = d.Rows.Count - 1; i >= 0 && ok == 0; i--)
                {
                    string text = d.Rows[i]["ID"].ToString();

                    if (string.Compare(text, Form3.ID_curent.ToString()) == 0)
                    {
                        ok = 1;
                        int a = int.Parse(d.Rows[i]["ID_tip_abonament"].ToString().Trim(' '));
                        if (DateTime.Compare(DateTime.Parse(d.Rows[i]["Data_inceperii"].ToString()), todaysDate) > 0)
                        {
                            verif = 0;
                        }
                        else if (DateTime.Compare(DateTime.Parse(d.Rows[i]["Data_inceperii"].ToString()).AddDays(int.Parse(d1.Rows[a - 1]["Valabilitate"].ToString().Trim(' '))), todaysDate) < 0)
                        {
                            verif = 1;
                        }
                        if (int.Parse(d.Rows[i]["ID_tip_abonament"].ToString().Trim(' ')) == 1 || int.Parse(d.Rows[i]["ID_tip_abonament"].ToString().Trim(' ')) == 2 || int.Parse(d.Rows[i]["ID_tip_abonament"].ToString().Trim(' ')) == 3 || int.Parse(d.Rows[i]["ID_tip_abonament"].ToString().Trim(' ')) == 9) verif1 = 1;
                        else if (z == int.Parse(d1.Rows[int.Parse(d.Rows[i]["ID_tip_abonament"].ToString().Trim(' ')) - 1]["Nr_sedinte"].ToString().Trim(' ')))
                        {

                            if (string.Compare(todaysDate.Year.ToString(), rEZERVARETableAdapter.Anul_ultimei_rezervari(Form3.ID_curent).ToString()) > 0) verif1 = 1;
                            else if (string.Compare(todaysDate.Year.ToString(), rEZERVARETableAdapter.Anul_ultimei_rezervari(Form3.ID_curent).ToString()) == 0)
                            {

                                if (string.Compare(todaysDate.Month.ToString(), rEZERVARETableAdapter.Luna_ultimei_rezervari(Form3.ID_curent).ToString()) > 0) verif1 = 1;
                                else if (string.Compare(todaysDate.Month.ToString(), rEZERVARETableAdapter.Luna_ultimei_rezervari(Form3.ID_curent).ToString()) == 0)
                                {
                                    if (string.Compare(todaysDate.Day.ToString(), rEZERVARETableAdapter.Ziua_ultimei_rezervari(Form3.ID_curent).ToString()) > 0) verif1 = 1;
                                    else verif1 = 0;
                                }
                            }
                        }
                        else if (z < int.Parse(d1.Rows[int.Parse(d.Rows[i]["ID_tip_abonament"].ToString().Trim(' ')) - 1]["Nr_sedinte"].ToString().Trim(' '))) verif1 = 1;

                    }

                }
                if (ok == 0)
                {
                    verif = 1;
                    verif1 = 1;
                }
                if (verif == 0 || verif1 == 0)
                {
                    MessageBox.Show("Nu va puteti crea alt abonament deoarece aveti deja unul valabil!");
                }
                else if (verif == 1 && verif1 == 1)
                {
                    string t = "";
                    string dt = dateTimePicker1.Value.ToString();
                    for (int i = 0; i < 10; i++)
                        t = t + dt[i];

                    aBONAMENTELE_FIECARUIATableAdapter.inserareabon(q, Form3.ID_curent, idabon, t);
                    aBONAMENTELE_FIECARUIATableAdapter.Update(this.baze_de_date_atestatDataSet.ABONAMENTELE_FIECARUIA);
                    this.aBONAMENTELE_FIECARUIATableAdapter.Fill(this.baze_de_date_atestatDataSet.ABONAMENTELE_FIECARUIA);
                    aBONAMENTELE_FIECARUIATableAdapter.Update(this.baze_de_date_atestatDataSet.ABONAMENTELE_FIECARUIA);
                    tabControl1.SelectedTab = tabPage5;
                    okactualizaredate = 0;
                }

            }
            else MessageBox.Show("Nu ati selectat nici un abonament.Va rugam alegeti unu!");

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'baze_de_date_atestatDataSet.ANGAJAT' table. You can move, or remove it, as needed.
            this.aNGAJATTableAdapter.Fill(this.baze_de_date_atestatDataSet.ANGAJAT);
            // TODO: This line of code loads data into the 'baze_de_date_atestatDataSet.UTILIZATOR' table. You can move, or remove it, as needed.
            this.uTILIZATORTableAdapter.Fill(this.baze_de_date_atestatDataSet.UTILIZATOR);
            // TODO: This line of code loads data into the 'baze_de_date_atestatDataSet.STATISTICA_GREUTATE' table. You can move, or remove it, as needed.
            this.sTATISTICA_GREUTATETableAdapter.Fill(this.baze_de_date_atestatDataSet.STATISTICA_GREUTATE);
            // TODO: This line of code loads data into the 'baze_de_date_atestatDataSet.REZERVARE' table. You can move, or remove it, as needed.
            this.rEZERVARETableAdapter.Fill(this.baze_de_date_atestatDataSet.REZERVARE);
            // TODO: This line of code loads data into the 'baze_de_date_atestatDataSet.TIPURI_ABONAMENTE' table. You can move, or remove it, as needed.
            this.tIPURI_ABONAMENTETableAdapter.Fill(this.baze_de_date_atestatDataSet.TIPURI_ABONAMENTE);
            // TODO: This line of code loads data into the 'baze_de_date_atestatDataSet.ABONAMENTELE_FIECARUIA' table. You can move, or remove it, as needed.
            this.aBONAMENTELE_FIECARUIATableAdapter.Fill(this.baze_de_date_atestatDataSet.ABONAMENTELE_FIECARUIA);
            baze_de_date_atestatDataSet.EnforceConstraints = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true && checkBox1.Checked == true) checkBox2.Checked = false;

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true && checkBox2.Checked == true)

                checkBox1.Checked = false;

        }
        public static int okactualizaredate = 1;
        private void button7_Click(object sender, EventArgs e)
        {
            int okg = 1,
            okgv = 0,
            okgol = 1,
            verif = 1;
            int okgc = 0;
            if (textBox1.Text == "") okgol = 0;
            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                if (i > 0 && i < textBox1.Text.Length && textBox1.Text[i] == ',') okgv++;
                else if (!(textBox1.Text[i] >= '0' && textBox1.Text[i] <= '9')) okg = 0;
                else okgc = 1;

            }

            if (okgol == 1)
            {
                if (textBox1.Text.Length > 1) if (textBox1.Text[0] == '0' && textBox1.Text[1] != ',') okg = 0;
            }
            if (okgol == 0) MessageBox.Show("Nu ati introdus valori pentru Greutate!");
            else if (!(okgv <= 1 && okg == 1 && okgc == 1 && double.Parse(textBox1.Text) != 0))
            {

                MessageBox.Show("Nu ati introdus valori valide pentru Greutate!");
                textBox1.Text = "";
                verif = 0;
            }
            else if (verif == 1)
            {

                int okh = 1,
                okhv = 0,
                okhh = 1;
                if (textBox2.Text == "")
                {
                    okhh = 0;
                    okh = 0;
                }
                if (textBox2.Text.Length > 4) okh = 0;
                int okhc = 0;
                for (int i = 0; i < textBox2.Text.Length; i++)
                {
                    if (textBox2.Text[i] == ',') okhv++;

                    else if (!(textBox2.Text[i] >= '0' && textBox2.Text[i] <= '9')) okh = 0;
                    else okhc = 1;

                }
                if (okhh == 1)
                {
                    if (textBox2.Text.Length > 1) if (textBox2.Text[0] == '0' && textBox2.Text[1] != ',') okh = 0;
                }
                if (textBox2.Text.Length > 4) if (!(textBox2.Text[1] == ',' && okhv == 1)) okh = 0;
                if (okhh == 0) MessageBox.Show("Nu ati introdus valori pentru Inaltime!");
                else if (!(okhv <= 1 && okh == 1 && okhc == 1 && double.Parse(textBox2.Text) <= 3 && double.Parse(textBox2.Text) != 0))
                {
                    MessageBox.Show("Nu ati introdus valori valide pentru Inaltime!");
                    textBox2.Text = "";
                    verif = 0;
                }
                else
                {
                    int p = 0;
                    int okplata = 1;
                    if (checkBox1.Checked == false && checkBox2.Checked == false) okplata = 0;
                    if (okplata == 0)
                    {
                        MessageBox.Show("Nu ati selectat cum efectuati Plata!");
                        verif = 0;
                    }
                    else
                    {
                        if (checkBox1.Checked == true) p = 1;
                        else if (checkBox2.Checked == true) p = 2;
                    }
                    if (verif == 1)
                    {
                        okactualizaredate = 1;
                        double a = double.Parse(textBox1.Text);
                        double b = double.Parse(textBox2.Text);
                        DataTable d3 = baze_de_date_atestatDataSet.UTILIZATOR;
                        double x = double.Parse(d3.Rows[Form3.ID_curent - 1]["Greutate"].ToString());
                        x = a - x;

                        sTATISTICA_GREUTATETableAdapter.actualizaredatestatisticagreutate(Math.Round((a / (b * b)), 2), x, Form3.ID_curent);
                        sTATISTICA_GREUTATETableAdapter.Update(this.baze_de_date_atestatDataSet.STATISTICA_GREUTATE);
                        this.sTATISTICA_GREUTATETableAdapter.Fill(this.baze_de_date_atestatDataSet.STATISTICA_GREUTATE);

                        uTILIZATORTableAdapter.actualizaredateutilizator(a, b, Math.Round((a / (b * b)), 2), p, Form3.ID_curent);
                        uTILIZATORTableAdapter.Update(this.baze_de_date_atestatDataSet.UTILIZATOR);
                        this.uTILIZATORTableAdapter.Fill(this.baze_de_date_atestatDataSet.UTILIZATOR);
                        tabControl1.SelectedTab = tabPage10;

                    }
                }
            }
        }
        public int idtipabonamentcurent = 0;
        public int idabonamentcurent = 0;
        private void faOProgramareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (okactualizaredate == 0) MessageBox.Show("Trebuie sa va actualizati datele!");
            else
            {
                DataTable d = baze_de_date_atestatDataSet.ABONAMENTELE_FIECARUIA;
                DataTable d1 = baze_de_date_atestatDataSet.TIPURI_ABONAMENTE;
                int z = int.Parse(rEZERVARETableAdapter.nrrezervari(Form3.ID_curent).ToString());
                int verif = 1;
                int verif1 = 1;
                DateTime todaysDate = DateTime.Today;
                int ok = 0;
                for (int i = d.Rows.Count - 1; i >= 0 && ok == 0; i--)
                {
                    string text = d.Rows[i]["ID"].ToString();

                    if (string.Compare(text, Form3.ID_curent.ToString()) == 0)
                    {
                        ok = 1;
                        int a = int.Parse(d.Rows[i]["ID_tip_abonament"].ToString().Trim(' '));

                        if (DateTime.Compare(DateTime.Parse(d.Rows[i]["Data_inceperii"].ToString()), todaysDate) > 0)
                        {
                            verif = 0;
                        }
                        else if (DateTime.Compare(DateTime.Parse(d.Rows[i]["Data_inceperii"].ToString()).AddDays(int.Parse(d1.Rows[a - 1]["Valabilitate"].ToString().Trim(' '))), todaysDate) < 0)
                        {
                            verif1 = 0;
                        }
                    }
                }

                if (ok == 0) MessageBox.Show("Trebuie sa va faceti abonament!");
                else
                {
                    if (verif1 == 0) MessageBox.Show("Abonamentul va expirat!");
                    else
                    {
                        if (verif == 0) MessageBox.Show("Aveti un abonament valid,dar data inceperii nu este data actuala!");
                        else
                        {
                            int verif3 = 1;
                            int ok3 = 0;
                            for (int i = d.Rows.Count - 1; i >= 0 && verif == 1 && ok3 == 0; i--)
                                if (int.Parse(d.Rows[i]["ID"].ToString()) == Form3.ID_curent)
                                {
                                    ok3 = 1;
                                    if (int.Parse(d.Rows[i]["ID_tip_abonament"].ToString()) == 1 || int.Parse(d.Rows[i]["ID_tip_abonament"].ToString()) == 2 || int.Parse(d.Rows[i]["ID_tip_abonament"].ToString()) == 4 || int.Parse(d.Rows[i]["ID_tip_abonament"].ToString()) == 9) verif3 = 0;
                                    else
                                    {
                                        idtipabonamentcurent = int.Parse(d.Rows[i]["ID_tip_abonament"].ToString());
                                        idabonamentcurent = int.Parse(d.Rows[i]["ID_abonament"].ToString());
                                    }
                                }

                            if (verif3 == 0) MessageBox.Show("Abonamentul dumneavoastra nu necesita rezervare!");

                            else tabControl1.SelectedTab = tabPage6;

                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage4;
        }

        private void generalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (okactualizaredate == 0) MessageBox.Show("Trebuie sa va actualizati datele!");
            else tabControl1.SelectedTab = tabPage10;
        }
        public static int iddangajat;
        private void button9_Click(object sender, EventArgs e)
        {
            DataTable d = baze_de_date_atestatDataSet.ABONAMENTELE_FIECARUIA;
            int ok3 = 0;
            for (int i = d.Rows.Count - 1; i >= 0 && ok3 == 0; i--)
                if (int.Parse(d.Rows[i]["ID"].ToString()) == Form3.ID_curent)
                {
                    ok3 = 1;

                    idtipabonamentcurent = int.Parse(d.Rows[i]["ID_tip_abonament"].ToString());
                    idabonamentcurent = int.Parse(d.Rows[i]["ID_abonament"].ToString());

                }
            comboBox2.Items.Clear();
            if (dateTimePicker2.Text.Contains("duminică"))
            {
                MessageBox.Show("Nu se pot face rezervari duminica.Va rugam alegeti alta zi!");
            }
            else if (dateTimePicker2.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Nu se pot crea abonamente,cu o data anterioara datei actuale!");
            }
            else
            {

                DateTime todaysDate = DateTime.Today;

                DataTable d1 = baze_de_date_atestatDataSet.TIPURI_ABONAMENTE;
                DataTable d2 = baze_de_date_atestatDataSet.REZERVARE;
                int contorizarerezervari = 0;
                int z = int.Parse(rEZERVARETableAdapter.nrrezervari(Form3.ID_curent).ToString());
                for (int i = 0; i < d2.Rows.Count; i++)
                    if (idtipabonamentcurent == int.Parse(d2.Rows[i]["ID_abonament"].ToString().Trim())) contorizarerezervari++;
                if (contorizarerezervari == int.Parse(d1.Rows[idtipabonamentcurent - 1]["Nr_sedinte"].ToString().Trim())) MessageBox.Show("Ati folosit toate sedintele disponibile abonamentului dumneavoastra!");
                else
                {

                    if (DateTime.Compare(DateTime.Parse(d.Rows[idabonamentcurent - 1]["Data_inceperii"].ToString()).AddDays(int.Parse(d1.Rows[idtipabonamentcurent - 1]["Valabilitate"].ToString().Trim(' '))), DateTime.Parse(dateTimePicker2.Text)) < 0) MessageBox.Show("Nu se pot face rezervari dupa data expirarii abonamentului!");
                    else
                    {
                        DateTime t;
                        int oktime = 1;
                        for (int i = d2.Rows.Count - 1; i >= 0; i--)
                        {

                            if (idabonamentcurent == int.Parse(d2.Rows[i]["ID_abonament"].ToString().Trim()))
                            {

                                string text = d2.Rows[i]["Data_ora_rezervare"].ToString().Trim();
                                string text2 = "";
                                for (int j = 0; j < 10; j++)
                                    text2 += text[j];
                                t = DateTime.Parse(text2);
                                DateTime t3 = DateTime.Parse(dateTimePicker2.Text);
                                if (t.Day == t3.Day && t.Month == t3.Month && t.Year == t3.Year) oktime = 0;

                            }

                        }
                        if (oktime == 0) MessageBox.Show("Nu va puteti crea o alta rezervare in aceeasi zi!");
                        else
                        {
                            int di = 0,
                            df = 0;
                            DataTable d3 = baze_de_date_atestatDataSet.ANGAJAT;
                            if (idtipabonamentcurent != 3)
                            {

                                for (int i = 0; i < d3.Rows.Count; i++)
                                    if (int.Parse(d3.Rows[i]["Id_tip_abonament"].ToString()) == idtipabonamentcurent)
                                    {
                                        di = (d3.Rows[i]["Program_incepere"].ToString().Trim(' ')[0] - '0') * 10 + (d3.Rows[i]["Program_incepere"].ToString().Trim(' ')[1] - '0');
                                        df = (d3.Rows[i]["Program_sfarsit"].ToString().Trim(' ')[0] - '0') * 10 + (d3.Rows[i]["Program_sfarsit"].ToString().Trim(' ')[1] - '0');
                                        iddangajat = int.Parse(d3.Rows[i]["ID_angajat"].ToString());
                                    }
                                textBox8.Text = d3.Rows[iddangajat - 1]["Nume"].ToString();
                            }
                            else
                            {
                                int n = 0;
                                for (int i = 0; i < d3.Rows.Count; i++)
                                    if (int.Parse(d3.Rows[i]["Id_tip_abonament"].ToString()) == 3) n++;
                                int[] s = new int[n + 1];
                                int[] s1 = new int[n + 1];
                                int n1 = 0;
                                for (int i = 0; i < d3.Rows.Count; i++)
                                    if (int.Parse(d3.Rows[i]["Id_tip_abonament"].ToString()) == idtipabonamentcurent)
                                    {

                                        s[n1] = int.Parse(d3.Rows[i]["ID_angajat"].ToString());
                                        s1[n1] = int.Parse(d3.Rows[i]["Nr_ore_lucrate_rezervari"].ToString());
                                        n1++;
                                    }
                                n1--;
                                int min = s1[0],
                                minpoz = 0;
                                for (int i = 1; i <= n1; i++)
                                    if (min > s1[i])
                                    {
                                        min = s1[i];
                                        minpoz = i;
                                    }

                                iddangajat = s[minpoz];
                                di = (d3.Rows[s[minpoz] - 1]["Program_incepere"].ToString().Trim(' ')[0] - '0') * 10 + (d3.Rows[s[minpoz] - 1]["Program_incepere"].ToString().Trim(' ')[1] - '0');
                                df = (d3.Rows[s[minpoz] - 1]["Program_sfarsit"].ToString().Trim(' ')[0] - '0') * 10 + (d3.Rows[s[minpoz] - 1]["Program_sfarsit"].ToString().Trim(' ')[1] - '0');

                                textBox8.Text = d3.Rows[s[minpoz] - 1]["Nume"].ToString();
                            }
                            DateTime t1;
                            int[] v = new int[14];
                            int nv = 0;

                            for (int i = d2.Rows.Count - 1; i >= 0; i--)
                            {

                                string text = d2.Rows[i]["Data_ora_rezervare"].ToString().Trim();
                                string text2 = "";
                                for (int j = 0; j < 10; j++)
                                    text2 += text[j];
                                t1 = DateTime.Parse(text2);

                                DateTime t2 = DateTime.Parse(dateTimePicker2.Text);

                                if (t1.Day == t2.Day && t1.Month == t2.Month && t1.Year == t2.Year)
                                {
                                    v[nv] = (text[11] - '0') * 10 + (text[12] - '0');

                                    nv++;

                                }

                            }
                            for (int k = di; k < df; k++)
                            {
                                int okelimin = 1;
                                for (int g = 0; g < nv; g++)
                                    if (k == v[g]) okelimin = 0;
                                if (okelimin == 1)
                                {
                                    if (k < 9) comboBox2.Items.Add("0" + k.ToString() + ":00:00" + "-" + "0" + (k + 1).ToString() + ":00:00");
                                    else if (k == 9) comboBox2.Items.Add("0" + k.ToString() + ":00:00" + "-" + (k + 1).ToString() + ":00:00");
                                    else comboBox2.Items.Add(k.ToString() + ":00:00" + "-" + (k + 1).ToString() + ":00:00");

                                }

                            }
                        }
                    }

                }

            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            DataTable d = baze_de_date_atestatDataSet.REZERVARE;
            DataTable d2 = baze_de_date_atestatDataSet.ANGAJAT;
            int q;
            int maxi = 0;
            for (int i = 0; i < d.Rows.Count; i++)
                if (int.Parse(d.Rows[i]["ID_rezervare"].ToString()) > maxi) maxi = int.Parse(d.Rows[i]["ID_rezervare"].ToString());
            q = maxi + 1;
            if (comboBox2.SelectedIndex > -1)
            {
                string t1 = "";
                for (int i = 0; i < 8; i++)
                    t1 += comboBox2.Text[i];
                string t = dateTimePicker2.Text + ' ' + t1;
                rEZERVARETableAdapter.inserarerezervare(q, iddangajat, idabonamentcurent, DateTime.Parse(t));
                rEZERVARETableAdapter.Update(this.baze_de_date_atestatDataSet.REZERVARE);
                this.rEZERVARETableAdapter.Fill(this.baze_de_date_atestatDataSet.REZERVARE);
                rEZERVARETableAdapter.ordonareid(baze_de_date_atestatDataSet.REZERVARE);

                aNGAJATTableAdapter.updatenrore(iddangajat);
                aNGAJATTableAdapter.Update(this.baze_de_date_atestatDataSet.ANGAJAT);
                this.aNGAJATTableAdapter.Fill(this.baze_de_date_atestatDataSet.ANGAJAT);
                tabControl1.SelectedTab = tabPage10;
            }
            else MessageBox.Show("Nu ati selectat ora!");
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void anulezaORezervareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (okactualizaredate == 0) MessageBox.Show("Trebuie sa va actualizati datele!");
            else
            {
                DataTable d = baze_de_date_atestatDataSet.ABONAMENTELE_FIECARUIA;
                DataTable d1 = baze_de_date_atestatDataSet.REZERVARE;
                DataTable d2 = baze_de_date_atestatDataSet.TIPURI_ABONAMENTE;
                DateTime todaysDate = DateTime.Now;
                int verif3 = 1,
                verif4 = 1;
                int ok1 = 0;
                for (int i = d.Rows.Count - 1; i >= 0 && ok1 == 0; i--)
                {
                    string text = d.Rows[i]["ID"].ToString();

                    if (string.Compare(text, Form3.ID_curent.ToString()) == 0)
                    {
                        ok1 = 1;
                        int a = int.Parse(d.Rows[i]["ID_tip_abonament"].ToString().Trim(' '));
                        if (DateTime.Compare(DateTime.Parse(d.Rows[i]["Data_inceperii"].ToString()), todaysDate) > 0)
                        {
                            verif3 = 0;
                        }
                        else if (DateTime.Compare(DateTime.Parse(d.Rows[i]["Data_inceperii"].ToString()).AddDays(int.Parse(d2.Rows[a - 1]["Valabilitate"].ToString().Trim(' '))), todaysDate) < 0)
                        {
                            verif4 = 0;
                        }
                    }
                }

                if (ok1 == 0) MessageBox.Show("Trebuie sa va faceti abonament!");
                else
                {
                    if (verif4 == 0) MessageBox.Show("Abonamentul va expirat!");
                    else

                        if (verif3 == 0) MessageBox.Show("Aveti un abonament valid,dar data inceperi nu este data actuala!");

                        else
                        {

                            int verif1 = 1;
                            int okv = 0;
                            for (int i = d.Rows.Count - 1; i >= 0 && verif1 == 1 && okv == 0; i--)
                                if (int.Parse(d.Rows[i]["ID"].ToString()) == Form3.ID_curent)
                                {

                                    if (int.Parse(d.Rows[i]["ID_tip_abonament"].ToString()) == 1 || int.Parse(d.Rows[i]["ID_tip_abonament"].ToString()) == 2 || int.Parse(d.Rows[i]["ID_tip_abonament"].ToString()) == 4 || int.Parse(d.Rows[i]["ID_tip_abonament"].ToString()) == 9) verif1 = 0;
                                    if (okv == 0)
                                    {
                                        idtipabonamentcurent = int.Parse(d.Rows[i]["ID_tip_abonament"].ToString());
                                        idabonamentcurent = int.Parse(d.Rows[i]["ID_abonament"].ToString());
                                        okv = 1;
                                    }
                                }

                            if (verif1 == 0) MessageBox.Show("Abonamentul dumneavoastra nu necesita rezervare!");

                            if (verif1 == 1)
                            {
                                int verif2 = 0;
                                int ok = 0;
                                for (int i = d1.Rows.Count - 1; i >= 0 && ok == 0; i--)
                                {
                                    if (idabonamentcurent == int.Parse(d1.Rows[i]["ID_abonament"].ToString().Trim()) && DateTime.Compare(DateTime.Parse(d1.Rows[i]["Data_ora_rezervare"].ToString()), todaysDate) > 0)
                                    {
                                        ok = 1;
                                        verif2 = 1;

                                    }

                                }
                                if (verif2 == 0) MessageBox.Show("Nu aveti nici o rezervare!");
                                else
                                {
                                    comboBox3.Items.Clear();
                                    comboBox3.Text = "";
                                    richTextBox1.Clear();
                                    for (int i = 0; i < d1.Rows.Count; i++)
                                        if (idabonamentcurent == int.Parse(d1.Rows[i]["ID_abonament"].ToString()) && DateTime.Compare(todaysDate, DateTime.Parse(d1.Rows[i]["Data_ora_rezervare"].ToString())) < 0)
                                        {
                                            comboBox3.Items.Add(d1.Rows[i]["Data_ora_rezervare"].ToString());
                                            richTextBox1.Text += d1.Rows[i]["Data_ora_rezervare"].ToString() + '\n';
                                        }
                                    richTextBox1.SelectAll();
                                    richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
                                    richTextBox1.DeselectAll();
                                    tabControl1.SelectedTab = tabPage8;
                                }
                            }

                        }
                }
            }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex > -1)
            {
                int ok = 0;
                int a = 0;
                DataTable d1 = baze_de_date_atestatDataSet.REZERVARE;
                for (int i = d1.Rows.Count - 1; i >= 0 && ok == 0; i--)
                    if (int.Parse(d1.Rows[i]["ID_abonament"].ToString()) == idabonamentcurent && string.Compare(d1.Rows[i]["Data_ora_rezervare"].ToString(), comboBox3.Text) == 0)
                    {
                        ok = 1;
                        a = i;
                    }

                if (ok == 1)
                {

                    rEZERVARETableAdapter.anuleazarezervare(a + 1);
                    rEZERVARETableAdapter.Update(this.baze_de_date_atestatDataSet.REZERVARE);
                    this.rEZERVARETableAdapter.Fill(this.baze_de_date_atestatDataSet.REZERVARE);

                    aNGAJATTableAdapter.updaterezanulari(iddangajat);
                    aNGAJATTableAdapter.Update(this.baze_de_date_atestatDataSet.ANGAJAT);
                    this.aNGAJATTableAdapter.Fill(this.baze_de_date_atestatDataSet.ANGAJAT);

                    MessageBox.Show("Anulare cu succes!");
                    tabControl1.SelectedTab = tabPage10;
                    comboBox3.Items.Clear();
                    comboBox3.Text = "";
                    richTextBox1.Clear();
                }
            }
            else MessageBox.Show("Nu ati selectat nimic!");
        }

        private void progresToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void abonamenteleMeleToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void abonamentFavoritToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void meniuPrincipalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (okactualizaredate == 0) MessageBox.Show("Trebuie sa va actualizati datele!");
            else
            {
                this.Hide();
                Form1 activate1 = new Form1();
                activate1.ShowDialog();
                this.Close();
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void progresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (okactualizaredate == 0) MessageBox.Show("Trebuie sa va actualizati datele!");
            else
            {
                DataTable d = baze_de_date_atestatDataSet.STATISTICA_GREUTATE;
                tabControl1.SelectedTab = tabPage9;
                float a = float.Parse(sTATISTICA_GREUTATETableAdapter.progres_regres(Form3.ID_curent).ToString());

                if (a > 0)
                {
                    textBox4.BackColor = Color.Red;
                    textBox4.ReadOnly = true;
                    textBox4.Text = a.ToString();
                }
                else
                {
                    textBox4.BackColor = Color.Green;
                    textBox4.ReadOnly = true;
                    textBox4.Text = a.ToString();
                }

                float b = float.Parse(sTATISTICA_GREUTATETableAdapter.indiceactual(Form3.ID_curent).ToString());
                textBox3.Text = b.ToString();
            }
        }
        private void abonamenteleMeleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (okactualizaredate == 0) MessageBox.Show("Trebuie sa va actualizati datele!");
            else
            {
                richTextBox2.Text = "";
                tabControl1.SelectedTab = tabPage7;
                DataTable d = baze_de_date_atestatDataSet.TIPURI_ABONAMENTE;
                tIPURI_ABONAMENTETableAdapter.abonamentelemele(baze_de_date_atestatDataSet.TIPURI_ABONAMENTE, Form3.ID_curent);
                for (int i = 0; i < d.Rows.Count; i++)
                    richTextBox2.Text += d.Rows[i]["Denumire"].ToString() + "            " + d.Rows[i]["Data_inceperii"].ToString().Remove(10) + '\n';
                richTextBox2.SelectAll();
                richTextBox2.SelectionAlignment = HorizontalAlignment.Left;
                richTextBox2.DeselectAll();
            }
        }

        private void investitiaInMineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (okactualizaredate == 0) MessageBox.Show("Trebuie sa va actualizati datele!");
            else
            {
                richTextBox3.Text = "";
                DataTable d = baze_de_date_atestatDataSet.TIPURI_ABONAMENTE;
                DataTable d1 = baze_de_date_atestatDataSet.UTILIZATOR;

                int s = 0,
                o = 0;
                tIPURI_ABONAMENTETableAdapter.cheltueliore(baze_de_date_atestatDataSet.TIPURI_ABONAMENTE, Form3.ID_curent);
                for (int i = 0; i < d.Rows.Count; i++)
                {
                    richTextBox3.Text += d.Rows[i]["Bucati"].ToString() + "               " + d.Rows[i]["Denumire"] + d.Rows[i]["Valoare"] + "   " + d.Rows[i]["timp"] + '\n';
                    s = s + int.Parse(d.Rows[i]["Valoare"].ToString());
                    o = o + int.Parse(d.Rows[i]["timp"].ToString());
                }
                richTextBox3.SelectAll();
                richTextBox3.SelectionAlignment = HorizontalAlignment.Left;
                richTextBox3.DeselectAll();
                textBox5.Text = s.ToString();
                textBox6.Text = o.ToString();

                DateTime time;
                time = DateTime.Parse(d1.Rows[Form3.ID_curent - 1]["Data_creare_cont"].ToString());
                DateTime zeroTime = new DateTime(1, 1, 1);
                DateTime olddate = time;
                DateTime curdate = DateTime.Now.ToLocalTime();
                TimeSpan span = curdate - olddate;
                int years = (zeroTime + span).Year - 1;
                int months = (zeroTime + span).Month - 1;
                int days = (zeroTime + span).Day;

                textBox7.Text = years + " ani " + months + " luni " + days + " zile ";

                tabControl1.SelectedTab = tabPage11;
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}