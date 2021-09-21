using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Net.Mail;

namespace E_Eczacım
{
    public partial class sifremiUnuttum_form : Form
    {
        public sifremiUnuttum_form()
        {
            InitializeComponent();
        }
        string dogrulamaKodu = "";
        string eposta = "";
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E-Eczacım.mdb");
        private void button1_Click(object sender, EventArgs e)
        {
            eposta = textBox1.text.Trim();
            OleDbCommand mevcut_eposta = new OleDbCommand("Select * from Kullanici_Kayit where eposta_adresi='" + eposta + "'", baglanti);
            baglanti.Open();
            OleDbDataReader a = mevcut_eposta.ExecuteReader();
            if (a.Read())
            {
                baglanti.Close();
                Random rastgele = new Random();
                string elemanlar = "ABCDEFGHIJKLMNOPRSTUVYZWX1234567890";
                for (int i = 0; i < 6; i++) { dogrulamaKodu += elemanlar[rastgele.Next(elemanlar.Length)]; }
                MailMessage mesaj = new MailMessage("e_eczacim.180541081@outlook.com", eposta, "E-Eczacım Otomasyonu Onay Kodu", "Üyeliğinizin onaylanması için geçerli onay kodunuz: '" + dogrulamaKodu + "'\n\nE-Eczacım Otomasyon Sistemi");
                SmtpClient istemci = new SmtpClient("smtp.live.com", 587);
                istemci.EnableSsl = true;
                istemci.UseDefaultCredentials = true;
                istemci.Credentials = new System.Net.NetworkCredential("e_eczacim.180541081@outlook.com", "180541081.Furkan");
                istemci.Send(mesaj);
                MessageBox.Show("Doğrulama Kodunuz Başarıyla Gönderilmiştir. Lütfen Doğrulama Kodunu Alttaki Kutucuğa Girip, Doğrula Butonuna Basınız...", "Doğrulama Kodu Gönderimi Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                panel2.Visible = true;
                textBox1.Enabled = false;
                button1.Enabled = false;
            }
            else
            {
                baglanti.Close();
                MessageBox.Show(textBox1.text+": Bu E-Posta Adresi Sistemde Kayıtlı Değil!", "E-Posta Adresi Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
            string dogrulama = textBox2.text.Trim();
            if (dogrulama.Equals(dogrulamaKodu))
            {
                panel1.Visible = true;
            }
            else
            {
                MessageBox.Show("Gönderilen Doğrulama Kodu, Girilen Kodla Uyumlu Değil! Lütfen Tekrar Deneyin...", "Doğrulama Kodu Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string sifre1 = textBox7.text.Trim();
            string sifre2 = textBox8.text.Trim();
            if (sifre1 != "" && sifre2 != "" && sifre1.Equals(sifre2))
            {
                baglanti.Open();
                OleDbCommand sifre_guncelle = new OleDbCommand("Update Kullanici_Kayit set sifre='" + sifre1 + "'where eposta_adresi='" + eposta + "'", baglanti);
                sifre_guncelle.ExecuteNonQuery();
                sifre_guncelle.Dispose();
                baglanti.Close();
                MessageBox.Show("Şifre Güncellendi!", "Şifre Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Girilen Şifreler Birbirine Uyumlu Değil! Lütfen Tekrar Deneyin...", "Şifre Uyumu Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void sifremiUnuttum_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            giris_form giris1 = new giris_form();
            giris1.Visible = true;
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            panel1.Width = panel1.Width + 40;
            if (panel1.Width == 520)
            {
                timer1.Stop();
                this.Refresh();
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.text == "                           E-Posta Adresinizi Girin")
            {
                textBox1.text = "";
                textBox1.ForeColor = Color.Red;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.text == "")
            {
                textBox1.ForeColor = Color.Black;
                textBox1.text = "                           E-Posta Adresinizi Girin";
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.text == "E-Posta Adresinize Gönderilen Doğrulama Kodunu Girin")
            {
                textBox2.text = "";
                textBox2.ForeColor = Color.Red;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.text == "")
            {
                textBox2.ForeColor = Color.Black;
                textBox2.text = "E-Posta Adresinize Gönderilen Doğrulama Kodunu Girin";
            }
        }

        private void textBox7_Enter(object sender, EventArgs e)
        {
            string txt = textBox7.text;
            if (txt == "                               Yeni Şifrenizi Girin")
            {
                textBox7.text = "";
                textBox7.ForeColor = Color.Red;
            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            string txt = textBox7.text;
            if (txt == "")
            {
                textBox7.ForeColor = Color.Black;
                textBox7.text = "                               Yeni Şifrenizi Girin";
            }
        }

        private void textBox8_Enter(object sender, EventArgs e)
        {
            string txt = textBox8.text;
            if (txt == "                         Yeni Şifrenizi Tekrar Girin")
            {
                textBox8.text = "";
                textBox8.ForeColor = Color.Red;
            }
        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            string txt = textBox7.text;
            if (txt == "")
            {
                textBox8.ForeColor = Color.Black;
                textBox8.text = "                         Yeni Şifrenizi Tekrar Girin";
            }
        }
    }
}
