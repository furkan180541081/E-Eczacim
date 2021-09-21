using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace E_Eczacım
{
    public partial class odeme_form : Form
    {
        public odeme_form(float ucret)
        {
            InitializeComponent();
            label12.Text += ucret + " TL";
            comboBox3.SelectedIndex = 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label9.Text = textBox1.Text;
        }

        private void maskedTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back) pictureBox3.Visible = false;
            label7.Text = maskedTextBox1.Text;
            string sayi = maskedTextBox1.Text.Replace(" ", "");
            if (sayi.Length == 16)
            {
                Regex visaRegex = new Regex("^4[0-9]{12}(?:[0-9]{3})?$");
                Regex masterRegex = new Regex("^5[1-5][0-9]{14}$");
                if (visaRegex.IsMatch(sayi))
                {
                    pictureBox3.Visible = true;
                    pictureBox3.BackgroundImage = ımageList1.Images[0];
                }
                else if (masterRegex.IsMatch(sayi))
                {
                    pictureBox3.Visible = true;
                    pictureBox3.BackgroundImage = ımageList1.Images[1];
                }
                else pictureBox3.Visible = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label8.Text = comboBox1.Text + "/" + comboBox2.Text;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            label8.Text = comboBox1.Text + "/" + comboBox2.Text;
        }

        private void maskedTextBox2_KeyUp(object sender, KeyEventArgs e)
        {
            label10.Text = maskedTextBox2.Text;
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            kullaniciGiris_form a = Application.OpenForms["adminGiris_form"] as kullaniciGiris_form;
            a.Odendi("Kredi/Banka","Eczanede");
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kullaniciGiris_form a = Application.OpenForms["adminGiris_form"] as kullaniciGiris_form;
            a.Odendi("Kapıda Kredi","Eczanede");
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            kullaniciGiris_form a = Application.OpenForms["adminGiris_form"] as kullaniciGiris_form;
            a.Odendi("Kapıda Nakit", "Eczanede");
            this.Close();
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void cik_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
