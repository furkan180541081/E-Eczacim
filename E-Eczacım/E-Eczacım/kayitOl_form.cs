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
    public partial class kayitOl_form : Form
    {
        string k_adi;
        bool eczane=false;
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E-Eczacım.mdb");

        public kayitOl_form()
        {
            InitializeComponent();
            button1.Visible = true;
            button2.Visible = false;
            button3.Visible = false;
        }

        public kayitOl_form(string ad)
        {
            InitializeComponent();
            button1.Visible = false;
            button2.Visible = true;
            button3.Visible = true;
            txt_ad.Enabled = false;
            txt_soyad.Enabled = false;
            txt_k_adi.Enabled = false;
            txt_tc.Enabled = false;
            k_adi = ad.ToLower();
            OleDbCommand komut = new OleDbCommand("Select * from Kullanici_Kayit where kullanici_adi='" + k_adi + "'", baglanti);
            baglanti.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            txt_ad.Text = dt.Rows[0]["adi"].ToString();
            txt_soyad.Text = dt.Rows[0]["soyadi"].ToString();
            txt_k_adi.Text = dt.Rows[0]["kullanici_adi"].ToString();
            txt_tc.Text = dt.Rows[0]["tc_kimlik"].ToString();
            txt_eposta.Text = dt.Rows[0]["eposta_adresi"].ToString();
            txt_tel_no.Text = dt.Rows[0]["telefon_no"].ToString();
            txt_adres.Text = dt.Rows[0]["adres"].ToString();
            txt_sifre.Text = dt.Rows[0]["sifre"].ToString();
            txt_konum.Text = dt.Rows[0]["konum"].ToString();
            baglanti.Close();
            if (k_adi.Contains("eczane"))
            {
                label1.Text = "Eczane İsmi:";
                label1.Location = new Point(117, 246);
            }
        }
        public kayitOl_form(string tur,bool eczaneMi)
        {
            InitializeComponent();
            button1.Visible = true;
            button2.Visible = false;
            button3.Visible = false;
            label1.Text = "Eczane İsmi:";
            label1.Location = new Point(117, 246);
            eczane = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_ad.Text.Trim() != "" && txt_soyad.Text.Trim() != "" && txt_k_adi.Text.Trim() != "" && txt_tc.Text != "" && txt_tc.Text.Length==11 && txt_eposta.Text.Trim() != "" && txt_tel_no.Text.Trim() != "" && txt_adres.Text.Trim() != "" && txt_sifre.Text.Trim() != "" && txt_sifre_tekrar.Text.Trim() != "" && txt_konum.Text != "" && txt_sifre.Text.Trim().Equals(txt_sifre_tekrar.Text.Trim()))
            {
                OleDbCommand mevcut_k_adi = new OleDbCommand("Select * from Kullanici_Kayit where kullanici_adi='" + txt_k_adi.Text.Trim().ToLower() + "'", baglanti);
                OleDbCommand mevcut_eposta = new OleDbCommand("Select * from Kullanici_Kayit where eposta_adresi='" + txt_eposta.Text.Trim().ToLower() + "'", baglanti);
                baglanti.Open();
                OleDbDataReader a = mevcut_k_adi.ExecuteReader();
                OleDbDataReader b = mevcut_eposta.ExecuteReader();
                if (a.Read() && b.Read())
                {
                    MessageBox.Show("Bu Kullanıcı Adı ve E-Posta Adresi Sistemde Kayıtlı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    baglanti.Close();
                }
                else if (a.Read())
                {
                    MessageBox.Show("Bu Kullanıcı Adı Sistemde Kayıtlı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    baglanti.Close();
                }
                else if (b.Read())
                {
                    MessageBox.Show("Bu E-Posta Adresi Sistemde Kayıtlı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    baglanti.Close();
                }

                else
                {
                    string k_adi = txt_k_adi.Text.Trim().ToLower();
                    string yetki = "kullanıcı";
                    if (eczane) { if(!txt_k_adi.Text.Trim().ToLower().Contains("eczanesi")) k_adi = txt_k_adi.Text.Trim().ToLower() + " eczanesi"; yetki = "eczane"; }
                    OleDbCommand kayit = new OleDbCommand("Insert into Kullanici_Kayit(adi,soyadi,kullanici_adi,tc_kimlik,eposta_adresi,telefon_no,adres,sifre,konum,Yetki) values ('" + txt_ad.Text.Trim().ToLower() + "','" + txt_soyad.Text.Trim().ToLower() + "','" + k_adi + "','" + txt_tc.Text + "','" + txt_eposta.Text.Trim().ToLower() + "','" + txt_tel_no.Text.Trim() + "','" + txt_adres.Text.Trim().ToLower() + "','" + txt_sifre.Text.Trim() + "','" + txt_konum.Text + "','" + yetki + "')", baglanti);
                    kayit.ExecuteNonQuery();
                    kayit.Dispose();
                    baglanti.Close();
                    MessageBox.Show("Kayıt Tamamlandı!", "Kayıt Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Boş Alan Bırakmayınız ve Şifreleri Birbirine Uyumlu Giriniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }     
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult a = MessageBox.Show("Kaydınızı Silmek İstediğinizden Emin Misiniz?", "Kayıt Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (a == DialogResult.Yes)
            {
                OleDbCommand sil = new OleDbCommand("Delete * from Kullanici_Kayit where kullanici_adi='" + k_adi + "'", baglanti);
                baglanti.Open();
                sil.ExecuteNonQuery();
                sil.Dispose();
                baglanti.Close();
                MessageBox.Show("Kaydınız Başarıyla Silinmiştir...", "Kayıt Silindi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (txt_tel_no.Text.Trim() != "" && txt_adres.Text.Trim() != "" && txt_konum.Text != "" && txt_sifre.Text.Trim() != "" && txt_sifre_tekrar.Text.Trim() != "" && txt_sifre.Text.Trim().Equals(txt_sifre_tekrar.Text.Trim()))
            {
                OleDbCommand guncelle = new OleDbCommand("Update Kullanici_Kayit set telefon_no='" + txt_tel_no.Text.Trim() + "',adres='" + txt_adres.Text.Trim().ToLower() + "',sifre='" + txt_sifre.Text.Trim() + "',konum='" + txt_konum.Text.Trim() + "'where kullanici_adi='" + k_adi + "'", baglanti);
                baglanti.Open();
                guncelle.ExecuteNonQuery();
                guncelle.Dispose();
                baglanti.Close();
                MessageBox.Show("Kayıt Güncellendi!", "Kayıt Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Boş Alan Bırakmayınız ve Şifreleri Birbirine Uyumlu Giriniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }     
        }
        private void kayitOl_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Application.OpenForms["eczaneGiris_form"] != null)
            {
                eczaneGiris_form a = Application.OpenForms["eczaneGiris_form"] as eczaneGiris_form;
                a.Show();
            }
            else if (Application.OpenForms["kullaniciGiris_form"] != null)
            {
                kullaniciGiris_form b = Application.OpenForms["kullaniciGiris_form"] as kullaniciGiris_form;
                b.Show();
            }
            else
            {
                giris_form giris1 = new giris_form();
                giris1.Visible = true;
            }
        }

        private void txt_tc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            konum_form konumSec = new konum_form();
            konumSec.ShowDialog();
        }
    }
}