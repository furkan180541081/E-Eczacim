using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using System.Data.OleDb;
using System.Net;
using HtmlAgilityPack;

namespace E_Eczacım
{
    public partial class kullaniciGiris_form : Form
    {
        string k_adi;
        string tamAd;
        string enlem;
        string boylam;
        float toplam=0;
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E-Eczacım.mdb");
        public ChromiumWebBrowser chromeBrowser;
        
        public kullaniciGiris_form(string ad,string k_ad)
        {
            InitializeComponent();
            //adi = ad.Substring(0, ad.IndexOf(" ")).ToLower();
            label1.Text = ad;
            label2.Text += ad + ";";
            CefSettings settings = new CefSettings();
            Cef.Initialize(settings);
            tamAd = ad;
            k_adi = k_ad;
            haritaAc();
        }

        public void haritaAc()
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select konum from Kullanici_Kayit where kullanici_adi='" + k_adi + "'", baglanti);
            string konum = komut.ExecuteScalar().ToString();
            baglanti.Close();
            string[] dizi = konum.Split(';');
            enlem = dizi[0].Trim().Replace(',', '.');
            boylam = dizi[1].Trim().Replace(',', '.');
            string eczane = "https://www.google.com/maps/search/Eczaneler/@" + enlem + "," + boylam + ",18z";
            chromeBrowser = new ChromiumWebBrowser(eczane);
            this.panel3.Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;
        }

        private void adminGiris_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
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
            if (panel4.Visible == true && panel5.Visible == false && metroTabControl1.Visible == false)
            {
                panel2.Location = new Point(37, 1);
                panel2.Width = 826;
                panel4.Location = new Point(0, 0);
                panel4.Width = 826;
            }
            else if (panel4.Visible == true && panel5.Visible == true && metroTabControl1.Visible == false)
            {
                panel2.Location = new Point(37, 1);
                panel2.Width = 826;
                panel4.Location = new Point(0, 0);
                panel4.Width = 826;
                panel5.Location = new Point(0, 0);
                panel5.Width = 826;
            }
            else if (panel4.Visible == true && panel5.Visible == true && metroTabControl1.Visible == true)
            {
                panel2.Location = new Point(37, 1);
                panel2.Width = 826;
                panel4.Location = new Point(0, 0);
                panel4.Width = 826;
                panel5.Location = new Point(0, 0);
                panel5.Width = 826;
                metroTabControl1.Location = new Point(0, 0);
                metroTabControl1.Width = 826;
                txt_gelen.Width = 826;
                txt_giden.Width = 826;
                txt_gonder.Width = 826;
            }
            else if (panel4.Visible == false && panel5.Visible == false && metroTabControl1.Visible == false)
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
            kayitOl_form bilgi = new kayitOl_form(k_adi);
            bilgi.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.panel3.Controls.Contains(chromeBrowser)) this.panel3.Controls.Remove(chromeBrowser);
            panel4.Visible = true;
            panel5.Visible = false;
            metroTabControl1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.panel3.Controls.Contains(chromeBrowser)) this.panel3.Controls.Remove(chromeBrowser);
            panel4.Visible = true;
            panel5.Visible = true;
            metroTabControl1.Visible = false;
            listBox1.Visible = false;
            listBox2.Visible = false;
            pictureBox2.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            button6.Visible = false;
            receteGor_cbox.Items.Clear();
            OleDbCommand komut = new OleDbCommand("select * from recete", baglanti);
            baglanti.Open();
            OleDbDataReader recete = komut.ExecuteReader();
            if (recete.HasRows)
            {
                while (recete.Read())
                {
                    if (recete["kullanici"].ToString() == tamAd)
                    {
                        receteGor_cbox.Items.Add(recete["recete_no"].ToString());
                    }
                }
            }
            baglanti.Close();
            if (receteGor_cbox.Items.Count == 0)
            {
                receteGor_cbox.PromptText = "Reçeteniz Bulunmamaktadır...";
                metroLabel1.Visible = false;
                metroLabel2.Visible = false;
                tarihGor_lbl.Visible = false;
                durumGor_lbl.Visible = false;
                eczaneGor_lbl.Visible = false;
                alinanIlac_list.Visible = false;
                toplamGor_lbl.Visible = false;
                odenenGor_lbl.Visible = false;
                odemeSekliGor_lbl.Visible = false;
                konumGor_lbl.Visible = false;
                tumIlac_list.Visible = false;
                alinanIlac_list.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.panel3.Controls.Contains(chromeBrowser)) this.panel3.Controls.Remove(chromeBrowser);
            panel3.Size = new Size(663, 530);
            panel3.Location = new Point(0, 0);
            panel4.Visible = false;
            panel5.Visible = false;
            metroTabControl1.Visible = false;
            hastalik_Ac();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.panel3.Controls.Contains(chromeBrowser)) this.panel3.Controls.Remove(chromeBrowser);
            panel4.Visible = true;
            panel5.Visible = true;
            metroTabControl1.Visible = true;
            listBox1.Visible = false;
            listBox2.Visible = false;
            pictureBox2.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            button6.Visible = false;
            gelen_veri_cek();
            giden_veri_cek();
            recete_cbox.Items.Clear();
            OleDbCommand komut = new OleDbCommand("select * from recete", baglanti);
            baglanti.Open();
            OleDbDataReader recete = komut.ExecuteReader();
            if (recete.HasRows)
            {
                while (recete.Read())
                {
                    if (recete["kullanici"].ToString() == tamAd)
                    {
                        recete_cbox.Items.Add(recete["recete_no"].ToString());
                    }  
                }
            }
            baglanti.Close();
        }

        public void hastalik_Ac()
        {
            chromeBrowser = new ChromiumWebBrowser("https://prospektus.co/hastaliklar/kategori.html");
            this.panel3.Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;
        }

        private void bM_txt1_Enter(object sender, EventArgs e)
        {
            if (bM_txt1.Text == "Lütfen Reçete Numaranızı Giriniz...") bM_txt1.Text = "";
        }

        private void bM_txt1_Leave(object sender, EventArgs e)
        {
            if (bM_txt1.Text == "") bM_txt1.Text = "Lütfen Reçete Numaranızı Giriniz...";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            textBox1.Text = "";
            textBox2.Text = "FİYATI:   ";
            textBox3.Text = "Toplam Ödenecek Tutar:              ";
            OleDbCommand komut = new OleDbCommand("select ilaclar from recete where recete_no='" + bM_txt1.Text.ToUpper() + "'", baglanti);
            OleDbCommand komut2 = new OleDbCommand("select kullanici from recete where recete_no='" + bM_txt1.Text.ToUpper() + "'", baglanti);
            baglanti.Open();
            if (komut.ExecuteScalar() != null && komut2.ExecuteScalar().ToString() == tamAd)
            {
                string ilaclar = komut.ExecuteScalar().ToString();
                string[] ilacListe = ilaclar.Split(';');
                foreach (string ilacIsım in ilacListe) listBox1.Items.Add(ilacIsım);
                listBox1.Visible = true;
            }
            else
            {
                MessageBox.Show("Lütfen Geçerli ve Sizin Adınıza Yazılmış Bir Reçete Numarası Giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                listBox1.Items.Clear();
                listBox1.Visible = false;
                bM_txt1.Text = "Lütfen Reçete Numaranızı Giriniz...";
            }
            baglanti.Close();
        }

        public void Odendi(string odeme,string durum)
        {
            var url = new Uri("https://www.google.com/maps/search/Eczaneler/@" + enlem + "," + boylam + ",17z");
            var client = new WebClient();
            client.Encoding = Encoding.UTF8;
            string html = client.DownloadString(url);
            string htmlisim = html.Substring(html.IndexOf(@"TYPE_PHARMACY\"",[\""SearchResult.TYPE_PHARMACY\"",\""TR\"), 100);
            string[] liste = htmlisim.Split('\\');
            string eczane = liste[liste.Length - 2].Remove(0, 1);
            string alinan = "";
            foreach (string ilac in listBox2.Items) alinan += ilac + ";";

            OleDbCommand guncelle = new OleDbCommand("Update recete set alinanlar='" + alinan.Remove(alinan.Length - 1, 1) + "',eczane='" + eczane + "',odeme='" + odeme +"',tarih='" + DateTime.Now.ToShortDateString() + "',durum='" + durum + "'where recete_no='" + bM_txt1.Text + "'", baglanti);
            baglanti.Open();
            guncelle.ExecuteNonQuery();
            guncelle.Dispose();
            baglanti.Close();
            MessageBox.Show("Ödeme İşlemi Başarılı...", "Ödeme Seçildi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            bM_txt1.Text = "Lütfen Reçete Numaranızı Giriniz...";
            listBox1.Visible = false;
            listBox2.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            button6.Visible = false;
            pictureBox2.Visible = false;
            panel4.Visible = false;
            haritaAc();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            odeme_form ode = new odeme_form(float.Parse(textBox3.Text.Remove(0,36)));
            ode.ShowDialog();
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                textBox1.Text = "";
                pictureBox2.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;

                var url = new Uri("https://prospektus.co/ilac/" + listBox1.SelectedItem.ToString().ToLower() + "/");
                var client = new WebClient();
                client.Encoding = Encoding.UTF8;
                string html = client.DownloadString(url);
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);
                var veri = doc.DocumentNode.SelectSingleNode("//*[@id='main']/div[3]/div/div/div[3]/table/tbody/tr[4]/td[2]/span");
                textBox2.Text = "FİYATI:   " + veri.InnerText;
                var veri2 = doc.DocumentNode.SelectNodes("//*[@id='main']/div[4]/div/div/div/div[2]");
                string bilgi="";
                foreach (var i in veri2) bilgi += i.InnerText + "\n";
                if (bilgi.IndexOf("\n\n\nATC")!=-1)
                bilgi=bilgi.Remove(bilgi.IndexOf("\n\n\nATC"),bilgi.IndexOf("Nedir ve Ne için kullanılır?") - bilgi.IndexOf("\n\n\nATC"));
                textBox1.Text = bilgi.Remove(bilgi.IndexOf(" Ruhsat"), (bilgi.Length - (bilgi.IndexOf(" Ruhsat")))).Replace("&rsquo;", "'").Replace("&lsquo;", "'").Replace("&reg;", "").Replace("&nbsp;", "\n").Replace("&deg;", "\u00B0").Replace("&#39", "'").Replace("Yan\nEtkileri", "Yan Etkileri").Replace("Nasıl\nKullanılır", "Nasıl Kullanılır").Replace("edilmesi\ngerekenler", "edilmesi gerekenler").Replace("Kullanılmaması", "\nKullanılmaması").Trim();
                var resimVer = doc.DocumentNode.SelectSingleNode("//*[@id='main']/div[3]/div/div/div[2]/div/img");
                string resim = html.Substring(html.IndexOf("data-src="), 200).Remove(0, 10);
                resim = resim.Remove(resim.IndexOf(" class"), (resim.Length - resim.IndexOf(" class")));
                pictureBox2.Load("https://prospektus.co" + resim.Remove(resim.Length - 1, 1));
            }
        }

        private void listBox2_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex != -1)
            {
                var url = new Uri("https://prospektus.co/ilac/" + listBox2.SelectedItem.ToString().ToLower() + "/");
                var client = new WebClient();
                client.Encoding = Encoding.UTF8;
                string html = client.DownloadString(url);
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);
                var veri = doc.DocumentNode.SelectSingleNode("//*[@id='main']/div[3]/div/div/div[3]/table/tbody/tr[4]/td[2]/span");
                textBox2.Text =  "FİYATI:   " + veri.InnerText;
                var veri2 = doc.DocumentNode.SelectNodes("//*[@id='main']/div[4]/div/div/div/div[2]");
                string bilgi = "";
                foreach (var i in veri2) bilgi += i.InnerText + "\n";
                bilgi = bilgi.Remove(bilgi.IndexOf("\n\n\nATC"), bilgi.IndexOf("Nedir ve Ne için kullanılır?") - bilgi.IndexOf("\n\n\nATC"));
                textBox1.Text = bilgi.Remove(bilgi.IndexOf(" Ruhsat"), (bilgi.Length - (bilgi.IndexOf(" Ruhsat")))).Replace("&rsquo;", "'").Replace("&lsquo;", "'").Replace("&reg;", " ").Replace("&nbsp;", "\n").Replace("&deg;", " ").Trim();
                var resimVer = doc.DocumentNode.SelectSingleNode("//*[@id='main']/div[3]/div/div/div[2]/div/img");
                string resim = html.Substring(html.IndexOf("data-src="), 200).Remove(0, 10);
                resim = resim.Remove(resim.IndexOf(" class"), (resim.Length - resim.IndexOf(" class")));
                pictureBox2.Load("https://prospektus.co" + resim.Remove(resim.Length - 1, 1));
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            listBox2.Enabled = true;
            listBox2.Visible = true;
            textBox3.Visible = true;
            textBox3.Visible = true;
            button6.Visible = true;
            listBox2.Items.Add(listBox1.SelectedItem.ToString());
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            listBox1.Refresh();
            string fiyat = textBox2.Text.Substring(textBox2.Text.IndexOf(" ")).Trim();
            toplam += float.Parse(fiyat.Remove(fiyat.Length - 3, 3).Replace('.', ','));
            textBox3.Text = "Toplam Ödenecek Tutar:              " + Math.Round(toplam,2).ToString();
            if (listBox1.Items.Count == 0) { listBox1.Enabled = false; }
        }

        private void listBox2_DoubleClick(object sender, EventArgs e)
        {
            listBox1.Enabled = true;
            var url = new Uri("https://prospektus.co/ilac/" + listBox2.SelectedItem.ToString().ToLower() + "/");
            var client = new WebClient();
            client.Encoding = Encoding.UTF8;
            string html = client.DownloadString(url);
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            var veri = doc.DocumentNode.SelectSingleNode("//*[@id='main']/div[3]/div/div/div[3]/table/tbody/tr[4]/td[2]/span");
            float cikar = float.Parse(veri.InnerText.Remove(veri.InnerText.IndexOf(" "), 3).Replace('.', ','));
            toplam -= cikar;
            listBox1.Items.Add(listBox2.SelectedItem.ToString());
            listBox2.Items.RemoveAt(listBox2.SelectedIndex);
            listBox2.Refresh();
            textBox3.Text = "Toplam Ödenecek Tutar:              " + Math.Round(toplam, 2).ToString();
            if (listBox2.Items.Count == 0) { textBox3.Text = "Toplam Ödenecek Tutar:              "; listBox2.Enabled = false; button6.Visible = false; }
        }

        public void gelen_veri_cek()
        {
            dgv_gelen.Rows.Clear();
            OleDbCommand gelen_komut = new OleDbCommand("Select * from eczane_mesaj where kullanici='" + tamAd + "'", baglanti);
            baglanti.Open();
            OleDbDataReader gelen_oku = gelen_komut.ExecuteReader();
            if (gelen_oku.HasRows)
            {
                while (gelen_oku.Read())
                {
                    gelen_lbl.Visible = false;
                    dgv_gelen.Rows.Add(gelen_oku["eczane"].ToString(), gelen_oku["recete_no"].ToString(), gelen_oku["mesaj"].ToString(), gelen_oku["tarih"].ToString());
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
            OleDbCommand giden_komut = new OleDbCommand("Select * from kullanici_mesaj where kullanici='" + tamAd + "'", baglanti);
            baglanti.Open();
            OleDbDataReader giden_oku = giden_komut.ExecuteReader();
            if (giden_oku.HasRows)
            {
                while (giden_oku.Read())
                {
                    giden_lbl.Visible = false;
                    dgv_giden.Rows.Add(giden_oku["eczane"].ToString(), giden_oku["recete_no"].ToString(), giden_oku["mesaj"].ToString(), giden_oku["tarih"].ToString());
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
            OleDbCommand komut = new OleDbCommand("select eczane from recete where recete_no='" + recete_cbox.SelectedItem.ToString() + "'", baglanti);
            baglanti.Open();
            eczane_lbl.Text = "ECZANE: " + komut.ExecuteScalar().ToString().ToUpper();
            baglanti.Close();
            if (eczane_lbl.Text == "ECZANE: ")
            {
                txt_gonder.Text = "Eczaneye mesaj göndermeden önce reçete numaranızla satın alım yapmalısınız.";
                txt_gonder.Enabled = false;
                gonder_btn.Enabled = false;
            }
        }

        private void gonder_btn_Click(object sender, EventArgs e)
        {
            if (txt_gonder.Text.Trim() != "")
            {
                baglanti.Open();
                string alici = eczane_lbl.Text.Remove(0, 8);
                string recete_no = recete_cbox.SelectedItem.ToString();
                OleDbCommand komut = new OleDbCommand("Insert into kullanici_mesaj(kullanici,eczane,recete_no,mesaj,tarih) values ('" + tamAd + "','" + alici + "','" + recete_no + "','" + txt_gonder.Text.Trim() + "','" + DateTime.Now.ToString() + "')", baglanti);
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

        private void receteGor_cbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            tumIlac_list.Items.Clear();
            alinanIlac_list.Items.Clear();
            float top_ilac = 0;
            float alinan_ilac = 0;
            OleDbCommand komut_eczane = new OleDbCommand("select eczane from recete where recete_no='" + receteGor_cbox.SelectedItem.ToString() + "'", baglanti);
            OleDbCommand komut_odeme = new OleDbCommand("select odeme from recete where recete_no='" + receteGor_cbox.SelectedItem.ToString() + "'", baglanti);
            OleDbCommand komut_tarih = new OleDbCommand("select tarih from recete where recete_no='" + receteGor_cbox.SelectedItem.ToString() + "'", baglanti);
            OleDbCommand komut_durum = new OleDbCommand("select durum from recete where recete_no='" + receteGor_cbox.SelectedItem.ToString() + "'", baglanti);
            OleDbCommand komut_ilaclar = new OleDbCommand("select ilaclar from recete where recete_no='" + receteGor_cbox.SelectedItem.ToString() + "'", baglanti);
            OleDbCommand komut_alinanlar = new OleDbCommand("select alinanlar from recete where recete_no='" + receteGor_cbox.SelectedItem.ToString() + "'", baglanti);
            baglanti.Open();
            if (komut_ilaclar.ExecuteScalar() != null)
            {
                string ilaclar = komut_ilaclar.ExecuteScalar().ToString();
                string[] ilacListe = ilaclar.Split(';');
                
                string alinan_ilaclar=komut_alinanlar.ExecuteScalar().ToString();
                string[] alinanlar=alinan_ilaclar.Split(';');
                foreach (string ilacIsım in ilacListe)
                {
                    var url = new Uri("https://prospektus.co/ilac/" + ilacIsım + "/");
                    var client = new WebClient();
                    client.Encoding = Encoding.UTF8;
                    string html = client.DownloadString(url);
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(html);
                    var veri = doc.DocumentNode.SelectSingleNode("//*[@id='main']/div[3]/div/div/div[3]/table/tbody/tr[4]/td[2]/span");
                    string fiyat =veri.InnerText;
                    top_ilac += float.Parse(fiyat.Remove(fiyat.IndexOf(" "), 3).Replace('.',','));
                    tumIlac_list.Items.Add(new ListViewItem(new string[] { ilacIsım, fiyat }));
                    if (alinanlar.Contains(ilacIsım))
                    {
                        alinan_ilac += float.Parse(fiyat.Remove(fiyat.IndexOf(" "), 3).Replace('.', ','));
                        alinanIlac_list.Items.Add(new ListViewItem(new string[] { ilacIsım, fiyat }));
                    }
                }
            }
            tarihGor_lbl.Text = "TARİH: " + komut_tarih.ExecuteScalar().ToString();
            eczaneGor_lbl.Text = "ECZANE: " + komut_eczane.ExecuteScalar().ToString().ToUpper();
            konumGor_lbl.Text = "KONUM: " + enlem + " ; " + boylam;
            durumGor_lbl.Text = "DURUM: " + komut_durum.ExecuteScalar().ToString();
            toplamGor_lbl.Text = "Toplam Reçete Tutarı: " + top_ilac;
            odenenGor_lbl.Text = "Ödenen Tutar: " + alinan_ilac;
            odemeSekliGor_lbl.Text = "Ödeme Şekli: " + komut_odeme.ExecuteScalar().ToString();
            baglanti.Close();
        }
    }
}
