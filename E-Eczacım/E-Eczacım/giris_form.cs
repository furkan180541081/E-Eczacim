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

namespace E_Eczacım
{
    public partial class giris_form : Form
    {
        public giris_form()
        {
            InitializeComponent();
        }
        
        private void sifre_txt_Enter(object sender, EventArgs e)
        {
            if(sifre_txt.Text == "") sifre_txt.Text = "";
            if (sifreGoster.Value == false)
            {
                sifre_txt.isPassword = false;
            }
            else
            {
                sifre_txt.isPassword = true;
            }
        }

        private void sakla_btn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void cik_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void sifreGoster_OnValueChange(object sender, EventArgs e)
        {
            if (sifreGoster.Value == false)
            {
                sifre_txt.isPassword = false;
            }
            else
            {
                sifre_txt.isPassword = true;
            }
        }

        private void giris_btn_Click(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E-Eczacım.mdb");
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select * from Kullanici_Kayit where kullanici_adi='" + k_adi_txt.Text + "' and sifre = '" + sifre_txt.Text + "'", baglanti);
            OleDbDataReader okuma = komut.ExecuteReader();
            if (okuma.Read())
            {
                this.Hide();
                OleDbCommand yetkiKomut = new OleDbCommand("Select Yetki from Kullanici_Kayit where kullanici_adi='" + k_adi_txt.Text + "'", baglanti);
                OleDbCommand adKomut = new OleDbCommand("Select adi from Kullanici_Kayit where kullanici_adi='" + k_adi_txt.Text + "'", baglanti);
                OleDbCommand soyadKomut = new OleDbCommand("Select soyadi from Kullanici_Kayit where kullanici_adi='" + k_adi_txt.Text + "'", baglanti);
                string Yetkisi = yetkiKomut.ExecuteScalar().ToString();
                string adi = adKomut.ExecuteScalar().ToString().ToUpper()+" "+soyadKomut.ExecuteScalar().ToString().ToUpper();
                baglanti.Close();
                if (Yetkisi == "kullanıcı")
                {
                    kullaniciGiris_form yetkili = new kullaniciGiris_form(adi, k_adi_txt.Text.Trim());
                    yetkili.Show();
                }
                else
                {
                    eczaneGiris_form eczane = new eczaneGiris_form(adi, k_adi_txt.Text.Trim());
                    eczane.Show();
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı Adınız ve Şifreniz Hatalı!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                k_adi_txt.Text = ""; sifre_txt.Text = "";
            }
        }

        private void kayitOl_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            kayitOl_form kayit = new kayitOl_form();
            kayit.ShowDialog();
        }

        private void sifremiUnuttum_lbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            sifremiUnuttum_form sifreYenile = new sifremiUnuttum_form();
            sifreYenile.ShowDialog();
        }

        private void eczaneKayit_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            kayitOl_form kayit = new kayitOl_form("eczane",true);
            kayit.ShowDialog();
        }
    }
}