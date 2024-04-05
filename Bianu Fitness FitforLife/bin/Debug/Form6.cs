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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'baze_de_date_atestatDataSet.STATISTICA_GREUTATE' table. You can move, or remove it, as needed.
            this.sTATISTICA_GREUTATETableAdapter.Fill(this.baze_de_date_atestatDataSet.STATISTICA_GREUTATE);
            // TODO: This line of code loads data into the 'baze_de_date_atestatDataSet.UTILIZATOR' table. You can move, or remove it, as needed.
            this.uTILIZATORTableAdapter.Fill(this.baze_de_date_atestatDataSet.UTILIZATOR);
            baze_de_date_atestatDataSet.EnforceConstraints = false;
        }
        bool verificare_data(String data)
        {
            try
            {
                DateTime dt = DateTime.Parse(data);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable d = baze_de_date_atestatDataSet.UTILIZATOR;
            int verif = 1;
            ///nr_id
            int q = d.Rows.Count;
            q++;
            ///greutate
            int okg = 1,
            okgv = 0,
            okgol = 1;
            int okgc = 0;
            if (textBox7.Text == "") okgol = 0;
            for (int i = 0; i < textBox7.Text.Length; i++)
            {
                if (i > 0 && i < textBox7.Text.Length && textBox7.Text[i] == ',') okgv++;

                else if (!(textBox7.Text[i] >= '0' && textBox7.Text[i] <= '9')) okg = 0;
                else okgc = 1;

            }
            if (okgol == 1)
            {
                if (textBox7.Text.Length > 1) if (textBox7.Text[0] == '0' && textBox7.Text[1] != ',') okg = 0;
            }
            if (okgol == 0) MessageBox.Show("Nu ati introdus valori pentru Greutate!");
            else if (!(okgv <= 1 && okg == 1 && okgc == 1 && double.Parse(textBox7.Text) != 0))
            {
                MessageBox.Show("Nu ati introdus valori valide pentru Greutate!");
                textBox7.Text = "";
                verif = 0;
            }
            else if (verif == 1)
            {

                double a = double.Parse(textBox7.Text);
                ///inaltime
                int okh = 1,
                okhv = 0,
                okhh = 1;
                if (textBox8.Text == "")
                {
                    okhh = 0;
                    okh = 0;
                }
                if (textBox8.Text.Length > 4) okh = 0;
                int okhc = 0;
                for (int i = 0; i < textBox8.Text.Length; i++)
                {
                    if (textBox8.Text[i] == ',') okhv++;

                    else if (!(textBox8.Text[i] >= '0' && textBox8.Text[i] <= '9')) okh = 0;
                    else okhc = 1;

                }
                if (okhh == 1)
                {
                    if (textBox8.Text.Length > 1) if (textBox8.Text[0] == '0' && textBox8.Text[1] != ',') okh = 0;
                }
                if (textBox8.Text.Length > 4) if (!(textBox8.Text[1] == ',' && okhv == 1)) okh = 0;
                if (okhh == 0) MessageBox.Show("Nu ati introdus valori pentru Inaltime!");
                else if (!(okhv <= 1 && okh == 1 && okhc == 1 && double.Parse(textBox8.Text) <= 3 && double.Parse(textBox8.Text) != 0))
                {
                    MessageBox.Show("Nu ati introdus valori valide pentru Inaltime!");
                    textBox8.Text = "";
                    verif = 0;
                }
                else if (verif == 1)
                {
                    double b = double.Parse(textBox8.Text);
                    ///sex
                    int okcpv = 1;
                    int ok3 = 1;
                    if (textBox4.Text.Length == 13)
                    {
                        if (!(textBox4.Text[0] == '1' || textBox4.Text[0] == '2' || textBox4.Text[0] == '5' || textBox4.Text[0] == '6' || textBox4.Text[0] == '7' || textBox4.Text[0] == '8')) okcpv = 0;
                        if (!(textBox4.Text[1] >= '0' && textBox4.Text[1] <= '9' && textBox4.Text[2] >= '0' && textBox4.Text[2] <= '9')) okcpv = 0;
                        if (!((textBox4.Text[3] == '0' && textBox4.Text[4] >= '1' && textBox4.Text[4] <= '9') || (textBox4.Text[3] == '1' && textBox4.Text[4] >= '0' && textBox4.Text[4] <= '2'))) okcpv = 0;
                        if (!((textBox4.Text[5] == '0' && textBox4.Text[6] >= '1' && textBox4.Text[6] <= '9') || (textBox4.Text[5] == '1' && textBox4.Text[6] >= '0' && textBox4.Text[6] <= '9') || (textBox4.Text[5] == '2' && textBox4.Text[6] >= '0' && textBox4.Text[6] <= '9') || (textBox4.Text[5] == '3' && textBox4.Text[6] >= '0' && textBox4.Text[6] <= '1'))) okcpv = 0;
                        if (!((textBox4.Text[7] == '0' && textBox4.Text[8] >= '1' && textBox4.Text[8] <= '9') || (textBox4.Text[7] == '1' && textBox4.Text[8] >= '0' && textBox4.Text[8] <= '9') || (textBox4.Text[7] == '2' && textBox4.Text[8] >= '0' && textBox4.Text[8] <= '9') || (textBox4.Text[7] == '3' && textBox4.Text[8] >= '0' && textBox4.Text[8] <= '9') || (textBox4.Text[7] == '4' && textBox4.Text[8] >= '0' && textBox4.Text[8] <= '8') || (textBox4.Text[7] == '5' && textBox4.Text[8] >= '1' && textBox4.Text[8] <= '2'))) okcpv = 0;
                        if (!((textBox4.Text[9] == '0' && textBox4.Text[10] == '0' && textBox4.Text[11] == '1') || (textBox4.Text[9] >= '0' && textBox4.Text[9] <= '9' && textBox4.Text[10] >= '0' && textBox4.Text[10] <= '9' && textBox4.Text[11] >= '0' && textBox4.Text[11] <= '9'))) okcpv = 0;
                        int[] connst;
                        connst = new int[12] {
							2,
							7,
							9,
							1,
							4,
							6,
							3,
							5,
							8,
							2,
							7,
							9
						};
                        int suma = 0;

                        for (int i = 0; i < 12; i++)
                            suma = suma + connst[i] * (textBox4.Text[i] - '0');
                        if (suma % 11 < 10)
                        {
                            if (!((textBox4.Text[12] - '0') == suma % 11)) okcpv = 0;
                        }
                        else if (suma % 11 == 10)
                        {
                            if (!((textBox4.Text[12] - '0') == 1)) okcpv = 0;
                        }
                    }
                    else
                    {
                        okcpv = 0;
                    }

                    if (okcpv == 0)
                    {
                        if (textBox4.Text == "") MessageBox.Show("Nu ati introdus valori pentru CNP!");
                        else
                        {
                            MessageBox.Show("Nu ati introdus valori valide pentru CNP!");
                            textBox4.Text = "";
                            verif = 0;
                        }
                    }
                    else
                    {
                        if (okcpv == 1)
                        {
                            for (int i = 0; i < d.Rows.Count; i++)
                            {
                                string text = (d.Rows[i]["CNP"].ToString()).Trim(' ');
                                if (string.Compare(text, textBox4.Text) == 0)
                                {
                                    ok3 = 0;
                                    verif = 0;
                                }
                            }
                        }
                    }
                    if (ok3 == 0 && okcpv == 1)
                    {
                        MessageBox.Show("Acest CNP exista in baza de date.Va rog sa mergeti pe meniu,LOG IN,la Recuperare Cont");
                        textBox4.Text = "";
                        verif = 0;
                    }

                    else if (okcpv == 1 && verif == 1)
                    {
                        string cp = textBox4.Text.ToString();
                        int se = cp[0] - '0';
                        int s = 0;
                        if (se == 1 || se == 3 || se == 5 || se == 7) s = 1;
                        else if (se == 2 || se == 4 || se == 6 || se == 8) s = 2;
                        ///elev_student
                        int el = 0;
                        int okelev = 1;
                        if (radioButton1.Checked == false && radioButton2.Checked == false) okelev = 0;
                        if (okelev == 0)
                        {
                            MessageBox.Show("Nu ati selectat daca sunteti Elev/Student sau nu!");
                            verif = 0;
                        }
                        else
                        {
                            if (radioButton1.Checked == true) el = 1;
                            else if (radioButton2.Checked == true) el = 2;
                            ///judet
                            string[] z;
                            z = new string[52] {
								"Alba",
								"Arad",
								"Arges",
								"Bacau",
								"Bihor",
								"Bistrita-Nasaud",
								"Botosani",
								"Brasov",
								"Braila",
								"Buzau",
								"Caras-Severin",
								"Cluj",
								"Constanta",
								"Covasna",
								"Dambovita",
								"Dolj",
								"Galati",
								"Gorj",
								"Harghita",
								"Hunedoara",
								"Ialomita",
								"Iasi",
								"Ilfov",
								"Maramures",
								"Mehedinti",
								"Mures",
								"Neamt",
								"Olt",
								"Prahova",
								"Satu Mare",
								"Salaj",
								"Sibiu",
								"Suceava",
								"Teleorman",
								"Timis",
								"Tulcea",
								"Vaslui",
								"Valcea",
								"Vrancea",
								"Bucuresti",
								"Bucuresti Sec.1",
								"Bucuresti Sec.2",
								"Bucuresti Sec.3",
								"Bucuresti Sec.4",
								"Bucuresti Sec.5",
								"Bucuresti Sec.6",
								"Bucuresti Sec.7",
								"Bucuresti Sec.8",
								"__",
								"__",
								"Calarasi",
								"Giurgiu"
							};
                            string j1 = cp.Remove(0, 7);
                            string j2 = j1.Remove(2, 4);
                            int jud = (j2[0] - '0') * 10 + (j2[1] - '0');
                            ///plata
                            int p = 0;
                            int okplata = 1;
                            if (checkBox1.Checked == false && checkBox2.Checked == false) okplata = 0;
                            if (okplata == 0)
                            {
                                MessageBox.Show("Nu ati selectat cum efectuati plata!");
                                verif = 0;
                            }
                            else
                            {
                                if (checkBox1.Checked == true) p = 1;
                                else if (checkBox2.Checked == true) p = 2;
                                ///data_creare_cont
                                DateTime todaysDate = DateTime.Today;

                                ///nume
                                int ok1 = 1;
                                int contl = 0;
                                if (textBox1.Text == "")
                                {
                                    MessageBox.Show("Nu ati introdus un Nume!");
                                    verif = 0;
                                }
                                else if (textBox1.Text.Length > 24 || !((textBox1.Text[0] >= 'A' && textBox1.Text[0] <= 'Z') || (textBox1.Text[0] >= 'a' && textBox1.Text[0] <= 'z')) || !((textBox1.Text[1] >= 'A' && textBox1.Text[1] <= 'Z') || (textBox1.Text[1] >= 'a' && textBox1.Text[1] <= 'z')))
                                {
                                    MessageBox.Show("Nu ati introdus un Nume valid!");
                                    textBox1.Text = "";
                                    verif = 0;
                                }
                                else
                                {
                                    for (int i = 0; i < textBox1.Text.Length; i++)
                                    {
                                        if (!((textBox1.Text[i] >= 'A' && textBox1.Text[i] <= 'Z') || (textBox1.Text[i] >= 'a' && textBox1.Text[i] <= 'z') || (textBox1.Text[i] == '-') || (textBox1.Text[i] == ' ')))
                                        {
                                            ok1 = 0;
                                            verif = 0;
                                        }
                                        if ((textBox1.Text[i] >= 'A' && textBox1.Text[i] <= 'Z') || (textBox1.Text[i] >= 'a' && textBox1.Text[i] <= 'z')) contl++;

                                    }
                                }
                                if (contl == 0 && verif == 1)
                                {
                                    MessageBox.Show("Nu ati introdus un Nume valid!");
                                    verif = 0;
                                    textBox1.Text = "";
                                }
                                else if (ok1 == 0)
                                {
                                    MessageBox.Show("Nu ati introdus un Nume valid!");
                                    verif = 0;
                                    textBox1.Text = "";
                                }
                                else if (verif == 1)
                                {
                                    int ok2 = 1;
                                    ///prenume
                                    int contll = 0;
                                    if (textBox2.Text == "")
                                    {
                                        MessageBox.Show("Nu ati introdus un Prenume!");
                                        verif = 0;
                                    }
                                    else if (textBox2.Text.Length > 29 || !((textBox2.Text[0] >= 'A' && textBox2.Text[0] <= 'Z') || (textBox2.Text[0] >= 'a' && textBox2.Text[0] <= 'z')) || !((textBox2.Text[1] >= 'A' && textBox2.Text[1] <= 'Z') || (textBox2.Text[1] >= 'a' && textBox2.Text[1] <= 'z')))
                                    {
                                        MessageBox.Show("Nu ati introdus un Prenume valid!");
                                        textBox2.Text = "";
                                        verif = 0;
                                    }
                                    else
                                    {

                                        for (int i = 0; i < textBox2.Text.Length; i++)
                                        {
                                            if (!((textBox2.Text[i] >= 'A' && textBox2.Text[i] <= 'Z') || (textBox2.Text[i] >= 'a' && textBox2.Text[i] <= 'z') || (textBox2.Text[i] == '-') || (textBox2.Text[i] == ' '))) ok2 = 0;
                                            if ((textBox2.Text[i] >= 'A' && textBox2.Text[i] <= 'Z') || (textBox2.Text[i] >= 'a' && textBox2.Text[i] <= 'z')) contll++;
                                        }
                                    }
                                    if (contll == 0 && verif == 1)
                                    {
                                        MessageBox.Show("Nu ati introdus un Prenume valid!");
                                        verif = 0;
                                        textBox2.Text = "";
                                    }
                                    else if (ok2 == 0)
                                    {
                                        MessageBox.Show("Nu ati introdus un Prenume valid!");
                                        verif = 0;
                                        textBox2.Text = "";
                                    }
                                    else if (verif == 1)
                                    {
                                        ///nrtel
                                        if (textBox3.Text == "")
                                        {
                                            MessageBox.Show("Nu ati introdus un Numar_Telefon!");
                                            verif = 0;
                                        }
                                        else if (!(textBox3.Text[0] == '0' && textBox3.Text.Length == 10))
                                        {
                                            MessageBox.Show("Nu ati introdus un Numar_Telefon valid!");
                                            textBox3.Text = "";
                                            verif = 0;
                                        }
                                        else
                                        {
                                            int oktel = 1;
                                            for (int i = 0; i < textBox3.Text.Length; i++)
                                            {
                                                if (!(textBox3.Text[i] >= '0' && textBox3.Text[i] <= '9'))
                                                {
                                                    oktel = 0;
                                                    verif = 0;
                                                }
                                            }
                                            if (oktel == 0)
                                            {
                                                MessageBox.Show("Nu ati introdus un Numar_Telefon valid!");
                                                textBox3.Text = "";
                                                verif = 0;
                                            }
                                            else
                                            {
                                                for (int i = 0; i < d.Rows.Count; i++)
                                                    if (string.Compare(textBox3.Text, d.Rows[i]["Nr_telefon"].ToString().Trim(' ')) == 0)
                                                    {
                                                        verif = 0;
                                                    }
                                                if (verif == 0)
                                                {
                                                    MessageBox.Show("Acest Numar_Telefon exista in baza de date.Va rog sa mergeti pe meniu,LOG IN,la Recuperare Cont");
                                                    textBox3.Text = "";
                                                }
                                                else if (verif == 1)
                                                {

                                                    int ok5 = 1;
                                                    ///localitate
                                                    int contlll = 0;
                                                    if (textBox5.Text == "")
                                                    {
                                                        MessageBox.Show("Nu ati introdus o Localitate!");
                                                        verif = 0;
                                                    }
                                                    else if (textBox5.Text.Length > 29 || !((textBox5.Text[0] >= 'A' && textBox5.Text[0] <= 'Z') || (textBox5.Text[0] >= 'a' && textBox5.Text[0] <= 'z')) || !((textBox5.Text[1] >= 'A' && textBox5.Text[1] <= 'Z') || (textBox5.Text[1] >= 'a' && textBox5.Text[1] <= 'z')))
                                                    {
                                                        MessageBox.Show("Nu ati introdus o Localitate valida!");
                                                        textBox5.Text = "";
                                                        verif = 0;
                                                    }
                                                    else
                                                    {

                                                        for (int i = 0; i < textBox5.Text.Length; i++)
                                                        {
                                                            if (!((textBox5.Text[i] >= 'A' && textBox5.Text[i] <= 'Z') || (textBox5.Text[i] >= 'a' && textBox5.Text[i] <= 'z') || (textBox5.Text[i] == '-') || (textBox5.Text[i] == ' '))) ok5 = 0;
                                                            if ((textBox5.Text[i] >= 'A' && textBox5.Text[i] <= 'Z') || (textBox5.Text[i] >= 'a' && textBox5.Text[i] <= 'z')) contlll++;
                                                        }
                                                    }
                                                    if (contlll == 0 && verif == 1)
                                                    {
                                                        MessageBox.Show("Nu ati introdus o Localitate valid!");
                                                        verif = 0;
                                                        textBox5.Text = "";
                                                    }
                                                    else if (ok5 == 0)
                                                    {
                                                        MessageBox.Show("Nu ati introdus o Localitate valida!");
                                                        verif = 0;
                                                        textBox5.Text = "";
                                                    }
                                                    else if (verif == 1)
                                                    {
                                                        ///numecont
                                                        if (!(textBox9.Text != ""))
                                                        {
                                                            MessageBox.Show("Nu ati introdus Nume_Cont!");
                                                            textBox9.Text = "";
                                                            verif = 0;
                                                        }
                                                        else
                                                        {
                                                            int okverif = 1;
                                                            for (int i = 0; i < textBox9.Text.Length; i++)
                                                                if (textBox9.Text[i] == ' ') okverif = 0;
                                                            if (okverif == 0)
                                                            {
                                                                MessageBox.Show("Ati introdus in Nume_Cont spatii si nu aveti voie!");
                                                                textBox9.Text = "";
                                                            }
                                                            else if (verif == 1)
                                                            {
                                                                ///parola
                                                                if (!(textBox10.Text != ""))
                                                                {
                                                                    MessageBox.Show("Nu ati introdus Parola!");
                                                                    verif = 0;
                                                                }
                                                                else
                                                                {
                                                                    int okspa = 0;
                                                                    for (int i = 0; i < textBox10.Text.Length; i++)
                                                                        if (textBox10.Text[i] == ' ') okspa = 1;
                                                                    if (okspa == 1)
                                                                    {
                                                                        MessageBox.Show("Ati introdus in Parola spatii si nu aveti voie!");
                                                                        textBox10.Text = "";
                                                                        verif = 0;
                                                                    }

                                                                    else if (verif == 1)
                                                                    {
                                                                        ///datanasterii
                                                                        if (textBox11.Text == "")
                                                                        {
                                                                            MessageBox.Show("Nu ati introdus Data_Nasterii!");
                                                                            verif = 0;

                                                                        }
                                                                        else if (!(verificare_data(textBox11.Text)))
                                                                        {
                                                                            MessageBox.Show("Nu ati introdus Data_Nasterii valida!");
                                                                            verif = 0;
                                                                            textBox11.Text = "";
                                                                        }
                                                                        else
                                                                        {
                                                                            int okdata = 1;
                                                                            DateTime datanastere = Convert.ToDateTime(textBox11.Text);
                                                                            if (!(datanastere.Day == (textBox4.Text[5] - '0') * 10 + (textBox4.Text[6] - '0')))
                                                                            {
                                                                                okdata = 0;
                                                                            }
                                                                            if (!(datanastere.Month == (textBox4.Text[3] - '0') * 10 + (textBox4.Text[4] - '0')))
                                                                            {
                                                                                okdata = 0;
                                                                            }

                                                                            if (!(datanastere.Year % 100 == (textBox4.Text[1] - '0') * 10 + (textBox4.Text[2] - '0')))
                                                                            {
                                                                                okdata = 0;
                                                                            }
                                                                            if (okdata == 0)
                                                                            {
                                                                                MessageBox.Show("Data din CNP si Data_Nasterii introdusa nu corespund!");
                                                                                verif = 0;
                                                                                textBox11.Text = "";
                                                                            }
                                                                            else if (verif == 1)
                                                                            {
                                                                                ///parola_recuperare
                                                                                string x = textBox1.Text.ToString();
                                                                                string recup = "";
                                                                                recup = recup + x[0] + x[1];
                                                                                string y = textBox2.Text.ToString();
                                                                                recup = recup + y[0];
                                                                                string o = textBox11.Text.ToString();
                                                                                if (o[1] == '.') recup = recup + '0' + o[0];
                                                                                else recup = recup + o[0] + o[1];
                                                                                string t = textBox3.Text.ToString();
                                                                                recup = recup + t[t.Length - 2] + t[t.Length - 1];
                                                                                string m = textBox4.Text.ToString();
                                                                                recup = recup + m[m.Length - 3] + m[m.Length - 2] + m[m.Length - 1];
                                                                                recup = recup + z[jud - 1][0];
                                                                                string n = textBox4.Text.ToString();
                                                                                recup = recup + n[0] + n[1];
                                                                                ///verif_nume_cont
                                                                                int ok = 1;
                                                                                for (int i = 0; i < d.Rows.Count; i++)
                                                                                {
                                                                                    string text = (d.Rows[i]["Nume_cont"].ToString()).Trim(' ');
                                                                                    if (string.Compare(text, textBox9.Text) == 0)
                                                                                    {
                                                                                        ok = 0;
                                                                                        verif = 0;
                                                                                    }
                                                                                }
                                                                                if (ok == 0)
                                                                                {
                                                                                    MessageBox.Show("Acest Nume_Cont apartine la alt utilizator.Va rog alegeti alt Nume_Cont!");
                                                                                    textBox9.Text = "";
                                                                                    verif = 0;
                                                                                }
                                                                                if (verif == 1)
                                                                                {
                                                                                    DataTable ds = baze_de_date_atestatDataSet.STATISTICA_GREUTATE;
                                                                                    int k = ds.Rows.Count;
                                                                                    k++;
                                                                                    uTILIZATORTableAdapter.inserare(q, textBox1.Text.ToString(), textBox2.Text.ToString(), textBox11.Text.ToString(), textBox3.Text.ToString(), textBox4.Text.ToString(), s, el, z[jud - 1], textBox5.Text.ToString(), textBox6.Text.ToString(), a, b, p, textBox10.Text.ToString(), textBox9.Text.ToString(), todaysDate.ToString(), Math.Round((a / (b * b)), 2), recup);
                                                                                    uTILIZATORTableAdapter.Update(this.baze_de_date_atestatDataSet.UTILIZATOR);
                                                                                    tableAdapterManager.UpdateAll(baze_de_date_atestatDataSet);
                                                                                    this.uTILIZATORTableAdapter.Fill(this.baze_de_date_atestatDataSet.UTILIZATOR);
                                                                                    sTATISTICA_GREUTATETableAdapter.inserarestatisticainitiala(k, q, 0, Math.Round((a / (b * b)), 2), Math.Round((a / (b * b)), 2), todaysDate.ToString());
                                                                                    sTATISTICA_GREUTATETableAdapter.Update(this.baze_de_date_atestatDataSet.STATISTICA_GREUTATE);
                                                                                    tableAdapterManager.UpdateAll(baze_de_date_atestatDataSet);
                                                                                    this.sTATISTICA_GREUTATETableAdapter.Fill(this.baze_de_date_atestatDataSet.STATISTICA_GREUTATE);
                                                                                    this.Hide();
                                                                                    Form1 activate1 = new Form1();
                                                                                    activate1.ShowDialog();
                                                                                    this.Close();

                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true && radioButton1.Checked == true)

                radioButton2.Checked = false;

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true && radioButton2.Checked == true) radioButton1.Checked = false;

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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 activate1 = new Form1();
            activate1.ShowDialog();
            this.Close();

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

    }
}