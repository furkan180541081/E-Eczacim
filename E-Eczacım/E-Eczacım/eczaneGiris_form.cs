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
using CefSharp;
using CefSharp.WinForms;
using System.Net;
using HtmlAgilityPack;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.ToolTips;
using GMap.NET.WindowsForms.Markers;

namespace E_Eczacım
{
    public partial class eczaneGiris_form : Form
    {
        string adi;
        string tamAd;
        string eczaneAd;
        string enlem;
        string boylam;
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E-Eczacım.mdb");
        public ChromiumWebBrowser chromeBrowser1;
        public eczaneGiris_form(string ad,string eczane_isim)
        {
            InitializeComponent();
            adi = ad.Substring(0, ad.IndexOf(" ")).ToLower();
            label1.Text = ad+"\n("+eczane_isim.ToUpper()+")";
            label2.Text += ad + ";";
            CefSettings settings = new CefSettings();
            Cef.Initialize(settings);
            tamAd = ad;
            eczaneAd = eczane_isim.ToLower();
            haritaAc();

        }
        public void haritaAc()
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select konum from Kullanici_Kayit where kullanici_adi='" + eczaneAd + "'", baglanti);
            string konum = komut.ExecuteScalar().ToString();
            baglanti.Close();
            string[] dizi = konum.Split(';');
            enlem = dizi[0].Trim().Replace(',', '.');
            boylam = dizi[1].Trim().Replace(',', '.');
            string eczane = "https://www.google.com/maps/@" + enlem + "," + boylam + ",16z";
            chromeBrowser1 = new ChromiumWebBrowser(eczane);
            this.panel3.Controls.Add(chromeBrowser1);
            chromeBrowser1.Dock = DockStyle.Fill;
        }

        private void kullaniciGiris_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.panel3.Controls.Contains(chromeBrowser1)) this.panel3.Controls.Remove(chromeBrowser1);
            panel4.Visible = true;
            metroTabControl1.Visible = false;
            button5.Visible = false;
            button6.Visible = true;
            receteSec_cbox.Items.Clear();
            metroListView1.Items.Clear();
            metroLabel5.Text = "Hasta Adı-Soyadı: ";
            metroLabel6.Text = "Toplam Ödenecek Tutar: ";
            metroLabel7.Text = "Ödeme Şekli: ";
            gMapControl1.Visible = false;
            receteSec_cbox.PromptText = "Reçete Numarası Seçiniz";
            OleDbCommand komut = new OleDbCommand("select * from recete", baglanti);
            baglanti.Open();
            OleDbDataReader recete = komut.ExecuteReader();
            if (recete.HasRows)
            {
                while (recete.Read())
                {
                    if (recete["eczane"].ToString().ToLower() == eczaneAd && recete["durum"].ToString()=="Eczanede")
                    {
                        receteSec_cbox.Items.Add(recete["recete_no"].ToString());
                    }
                }
            }
            baglanti.Close();
            if (receteSec_cbox.Items.Count == 0)
            {
                receteSec_cbox.PromptText = "Gelen Reçete Bulunmamaktadır";
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (this.panel3.Controls.Contains(chromeBrowser1)) this.panel3.Controls.Remove(chromeBrowser1);
            panel4.Visible = true;
            metroTabControl1.Visible = false;
            button5.Visible = true;
            button6.Visible = false;
            receteSec_cbox.Items.Clear();
            metroListView1.Items.Clear();
            metroLabel5.Text = "Hasta Adı-Soyadı: ";
            metroLabel6.Text = "Toplam Ödenecek Tutar: ";
            metroLabel7.Text = "Ödeme Şekli: ";
            gMapControl1.Visible = false;
            receteSec_cbox.PromptText = "Reçete Numarası Seçiniz";
            OleDbCommand komut = new OleDbCommand("select * from recete", baglanti);
            baglanti.Open();
            OleDbDataReader recete = komut.ExecuteReader();
            if (recete.HasRows)
            {
                while (recete.Read())
                {
                    if (recete["eczane"].ToString().ToLower() == eczaneAd && recete["durum"].ToString() == "Gönderildi")
                    {
                        receteSec_cbox.Items.Add(recete["recete_no"].ToString());
                    }
                }
            }
            baglanti.Close();
            if (receteSec_cbox.Items.Count == 0)
            {
                receteSec_cbox.PromptText = "Onay Bekleyen Reçete Bulunmamaktadır";
            }
        }
        private void receteSec_cbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            gMapControl1.Visible = true;
            if (gMapControl1.Overlays.Count != 0)  gMapControl1.Overlays.RemoveAt(0);
            metroListView1.Items.Clear();
            metroLabel5.Text = "Hasta Adı-Soyadı: ";
            metroLabel6.Text = "Toplam Ödenecek Tutar: ";
            metroLabel7.Text = "Ödeme Şekli:  ";
            float toplam = 0;
            string alinanlar="";
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select kullanici from recete where recete_no='" + receteSec_cbox.SelectedItem.ToString() + "'", baglanti);
            string[] kullanıcı = komut.ExecuteScalar().ToString().Split(' ');
            string isim = kullanıcı[0].ToLower();
            string soyisim = kullanıcı[1].ToLower();
            OleDbCommand komut_konum = new OleDbCommand("select konum from Kullanici_kayit where adi='" + isim + "'and soyadi='" + soyisim + "'", baglanti);
            string[] konum = komut_konum.ExecuteScalar().ToString().Split(';');
            OleDbCommand komut_odeme = new OleDbCommand("select odeme from recete where recete_no='" + receteSec_cbox.SelectedItem.ToString() + "'", baglanti);
            string odeme = komut_odeme.ExecuteScalar().ToString();
            OleDbCommand komut_ilac = new OleDbCommand("select alinanlar from recete where recete_no='" + receteSec_cbox.SelectedItem.ToString() + "'", baglanti);
            if (komut_ilac.ExecuteScalar() != null)
            {
                alinanlar = komut_ilac.ExecuteScalar().ToString();
            }
            baglanti.Close();

            string[] ilacListe = alinanlar.Split(';');
            foreach (string ilac in ilacListe)
            {
                var url = new Uri("https://prospektus.co/ilac/" + ilac + "/");
                var client = new WebClient();
                client.Encoding = Encoding.UTF8;
                string html = client.DownloadString(url);
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);
                var veri = doc.DocumentNode.SelectSingleNode("//*[@id='main']/div[3]/div/div/div[3]/table/tbody/tr[4]/td[2]/span");
                string fiyat = veri.InnerText;
                toplam += float.Parse(fiyat.Remove(fiyat.IndexOf(" "), 3).Replace('.', ','));
                metroListView1.Items.Add(new ListViewItem(new string[] { ilac, fiyat }));
            }
            double en = double.Parse(konum[0].Replace('.', ','));
            double boy = double.Parse(konum[1].Replace('.', ','));
            metroLabel5.Text = "Hasta Adı-Soyadı:\n" + isim.ToUpper() + " " + soyisim.ToUpper();
            metroLabel6.Text = "Toplam Ödenecek Tutar: " + toplam + " TL";
            metroLabel7.Text = "Ödeme Şekli: " + odeme;

            gMapControl1.ShowCenter = false;
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            gMapControl1.Position = new PointLatLng(en, boy);
            gMapControl1.MinZoom = 5;
            gMapControl1.MaxZoom = 21;
            gMapControl1.Zoom = 18;
            GMapOverlay isaret = new GMapOverlay("markers");
            GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(en, boy), GMarkerGoogleType.green_dot);
            isaret.Markers.Add(marker);
            marker.ToolTipText = "Hastanın Konumu Burasıdır";
            gMapControl1.Overlays.Add(isaret);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (receteSec_cbox.SelectedIndex != -1)
            {
                OleDbCommand guncelle = new OleDbCommand("Update recete set durum='" + "Gönderildi" + "'where recete_no='" + receteSec_cbox.SelectedItem.ToString() + "'", baglanti);
                baglanti.Open();
                guncelle.ExecuteNonQuery();
                guncelle.Dispose();
                baglanti.Close();
                MessageBox.Show("İlaçlar 'Gönderildi' Diye İşaretlendi!", "İlaçlar Gönderildi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (receteSec_cbox.SelectedIndex != -1)
            {
                OleDbCommand guncelle = new OleDbCommand("Update recete set durum='" + "Tamamlandı" + "'where recete_no='" + receteSec_cbox.SelectedItem.ToString() + "'", baglanti);
                baglanti.Open();
                guncelle.ExecuteNonQuery();
                guncelle.Dispose();
                baglanti.Close();
                MessageBox.Show("İlaçlar 'Tamamlandı' Diye İşaretlendi!", "İlaç Gönderim İşlemi Tamamlandı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.panel3.Controls.Contains(chromeBrowser1)) this.panel3.Controls.Remove(chromeBrowser1);
            panel3.Size = new Size(663, 530);
            panel3.Location = new Point(0, 0);
            panel4.Visible = false;
            metroTabControl1.Visible = false;
            hastalik_Ac();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.panel3.Controls.Contains(chromeBrowser1)) this.panel3.Controls.Remove(chromeBrowser1);
            panel4.Visible = true;
            metroTabControl1.Visible = true;
            gelen_veri_cek();
            giden_veri_cek();
            recete_cbox.Items.Clear();
            recete_cbox.PromptText = "Reçete Numarası Seçiniz";
            OleDbCommand komut = new OleDbCommand("select * from recete", baglanti);
            baglanti.Open();
            OleDbDataReader recete = komut.ExecuteReader();
            if (recete.HasRows)
            {
                while (recete.Read())
                {
                    if (recete["eczane"].ToString().ToLower() == eczaneAd)
                    {
                        recete_cbox.Items.Add(recete["recete_no"].ToString());
                    }
                }
            }
            baglanti.Close();
        }

        public void hastalik_Ac()
        {
            chromeBrowser1 = new ChromiumWebBrowser("https://prospektus.co/hastaliklar/kategori.html");
            this.panel3.Controls.Add(chromeBrowser1);
            chromeBrowser1.Dock = DockStyle.Fill;
        }
        public void gelen_veri_cek()
        {
            dgv_gelen.Rows.Clear();
            OleDbCommand gelen_komut = new OleDbCommand("Select * from kullanici_mesaj where eczane='" + eczaneAd + "'", baglanti);
            baglanti.Open();
            OleDbDataReader gelen_oku = gelen_komut.ExecuteReader();
            if (gelen_oku.HasRows)
            {
                while (gelen_oku.Read())
                {
                    gelen_lbl.Visible = false;
                    dgv_gelen.Rows.Add(gelen_oku["kullanici"].ToString(), gelen_oku["recete_no"].ToString(), gelen_oku["mesaj"].ToString(), gelen_oku["tarih"].ToString());
                }
            }
            else
            {
                gelen_lbl.Visible = true;
            }

            baglanti.Close();
        }

        public void giden_veri_cek()
        {
            dgv_giden.Rows.Clear();
            OleDbCommand giden_komut = new OleDbCommand("Select * from eczane_mesaj where eczane='" + eczaneAd + "'", baglanti);
            baglanti.Open();
            OleDbDataReader giden_oku = giden_komut.ExecuteReader();
            if (giden_oku.HasRows)
            {
                while (giden_oku.Read())
                {
                    giden_lbl.Visible = false;
                    dgv_giden.Rows.Add(giden_oku["kullanici"].ToString(), giden_oku["recete_no"].ToString(), giden_oku["mesaj"].ToString(), giden_oku["tarih"].ToString());
                }
            }
            else
            {
                giden_lbl.Visible = true;
            }

            baglanti.Close();
        }

        private void dgv_giden_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_giden.Text = dgv_giden.CurrentRow.Cells[2].Value.ToString();
        }

        private void dgv_gelen_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_gelen.Text = dgv_gelen.CurrentRow.Cells[2].Value.ToString();
        }

        private void recete_cbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_gonder.Enabled = true;
            txt_gonder.Text = "";
            txt_gonder.Font = new Font("Microsoft Sans Serif", 12);
            txt_gonder.ForeColor = Color.DarkBlue;
            gonder_btn.Enabled = true;
            OleDbCommand komut = new OleDbCommand("select kullanici from recete where recete_no='" + recete_cbox.SelectedItem.ToString() + "'", baglanti);
            baglanti.Open();
            kullanici_lbl.Text = "KULLANICI: " + komut.ExecuteScalar().ToString().ToUpper();
            baglanti.Close();
        }

        private void gonder_btn_Click(object sender, EventArgs e)
        {
            if (txt_gonder.Text.Trim() != "")
            {
                baglanti.Open();
                string alici = kullanici_lbl.Text.Remove(0, 11);
                string recete_no = recete_cbox.SelectedItem.ToString();
                OleDbCommand komut = new OleDbCommand("Insert into eczane_mesaj(eczane,kullanici,recete_no,mesaj,tarih) values ('" + eczaneAd + "','" + alici + "','" + recete_no + "','" + txt_gonder.Text.Trim() + "','" + DateTime.Now.ToString() + "')", baglanti);
                komut.ExecuteNonQuery();
                komut.Dispose();
                baglanti.Close();
                MessageBox.Show("Mesajınız Gönderilmiştir...", "İletildi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                giden_veri_cek();
                txt_gonder.Enabled = false;
                gonder_btn.Enabled = false;
                metroTabControl1.SelectedIndex = 1;
            }
        }

        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
            panel2.Width = 663;
            panel2.Location = new Point(200, 1);
            panel1.Width = 200;
            label1.Visible = true;
            bunifuTileButton2.Visible = false;
            panel3.Width = 657;
        }

        private void bunifuTileButton3_Click(object sender, EventArgs e)
        {
            if (panel4.Visible == true && metroTabControl1.Visible == false)
            {
                panel2.Location = new Point(37, 1);
                panel2.Width = 826;
                panel4.Location = new Point(0, 0);
                panel4.Width = 826;
            }
            else if (panel4.Visible == true && metroTabControl1.Visible == true)
            {
                panel2.Location = new Point(37, 1);
                panel2.Width = 826;
                panel4.Location = new Point(0, 0);
                panel4.Width = 826;
                metroTabControl1.Location = new Point(0, 0);
                metroTabControl1.Width = 826;
                txt_gelen.Width = 826;
                txt_giden.Width = 826;
                txt_gonder.Width = 826;
            }
            else if (panel4.Visible == false && metroTabControl1.Visible == false)
            {
                panel2.Location = new Point(37, 1);
                panel2.Width = 826;
                panel3.Width = 826;
            }
            panel1.Width = 37;
            label1.Visible = false;
            bunifuTileButton2.Visible = true;
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuTileButton4_Click(object sender, EventArgs e)
        {
            kayitOl_form bilgi = new kayitOl_form(eczaneAd);
            bilgi.ShowDialog();
        }

    }
}
