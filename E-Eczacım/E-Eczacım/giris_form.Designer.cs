namespace E_Eczacım
{
    partial class giris_form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(giris_form));
            this.k_adi_txt = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.sifre_txt = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.sifremiUnuttum_lbl = new System.Windows.Forms.LinkLabel();
            this.sakla_btn = new Bunifu.Framework.UI.BunifuImageButton();
            this.cik_btn = new Bunifu.Framework.UI.BunifuImageButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.kayitOl_btn = new Bunifu.Framework.UI.BunifuTileButton();
            this.sifreGoster = new Bunifu.Framework.UI.BunifuiOSSwitch();
            this.giris_btn = new Bunifu.Framework.UI.BunifuThinButton2();
            this.eczaneKayit_btn = new Bunifu.Framework.UI.BunifuTileButton();
            ((System.ComponentModel.ISupportInitialize)(this.sakla_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cik_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // k_adi_txt
            // 
            this.k_adi_txt.BackColor = System.Drawing.Color.White;
            this.k_adi_txt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.k_adi_txt.Font = new System.Drawing.Font("Century Gothic", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.k_adi_txt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.k_adi_txt.HintForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.k_adi_txt.HintText = "Lütfen Kullanıcı Adınızı Girin";
            this.k_adi_txt.isPassword = false;
            this.k_adi_txt.LineFocusedColor = System.Drawing.Color.Transparent;
            this.k_adi_txt.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.k_adi_txt.LineMouseHoverColor = System.Drawing.Color.Green;
            this.k_adi_txt.LineThickness = 3;
            this.k_adi_txt.Location = new System.Drawing.Point(44, 245);
            this.k_adi_txt.Margin = new System.Windows.Forms.Padding(4);
            this.k_adi_txt.Name = "k_adi_txt";
            this.k_adi_txt.Size = new System.Drawing.Size(379, 37);
            this.k_adi_txt.TabIndex = 2;
            this.k_adi_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // sifre_txt
            // 
            this.sifre_txt.BackColor = System.Drawing.Color.White;
            this.sifre_txt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.sifre_txt.Font = new System.Drawing.Font("Century Gothic", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sifre_txt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.sifre_txt.HintForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.sifre_txt.HintText = "Lütfen Şifrenizi Girin";
            this.sifre_txt.isPassword = false;
            this.sifre_txt.LineFocusedColor = System.Drawing.Color.Transparent;
            this.sifre_txt.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.sifre_txt.LineMouseHoverColor = System.Drawing.Color.Green;
            this.sifre_txt.LineThickness = 3;
            this.sifre_txt.Location = new System.Drawing.Point(44, 298);
            this.sifre_txt.Margin = new System.Windows.Forms.Padding(4);
            this.sifre_txt.Name = "sifre_txt";
            this.sifre_txt.Size = new System.Drawing.Size(379, 35);
            this.sifre_txt.TabIndex = 3;
            this.sifre_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.sifre_txt.Enter += new System.EventHandler(this.sifre_txt_Enter);
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // sifremiUnuttum_lbl
            // 
            this.sifremiUnuttum_lbl.AutoSize = true;
            this.sifremiUnuttum_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sifremiUnuttum_lbl.Location = new System.Drawing.Point(275, 346);
            this.sifremiUnuttum_lbl.Name = "sifremiUnuttum_lbl";
            this.sifremiUnuttum_lbl.Size = new System.Drawing.Size(148, 16);
            this.sifremiUnuttum_lbl.TabIndex = 4;
            this.sifremiUnuttum_lbl.TabStop = true;
            this.sifremiUnuttum_lbl.Text = "ŞİFREMİ UNUTTUM";
            this.sifremiUnuttum_lbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.sifremiUnuttum_lbl_LinkClicked);
            // 
            // sakla_btn
            // 
            this.sakla_btn.BackColor = System.Drawing.Color.Transparent;
            this.sakla_btn.Image = ((System.Drawing.Image)(resources.GetObject("sakla_btn.Image")));
            this.sakla_btn.ImageActive = null;
            this.sakla_btn.Location = new System.Drawing.Point(411, 0);
            this.sakla_btn.Name = "sakla_btn";
            this.sakla_btn.Size = new System.Drawing.Size(59, 46);
            this.sakla_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.sakla_btn.TabIndex = 13;
            this.sakla_btn.TabStop = false;
            this.sakla_btn.Zoom = 10;
            this.sakla_btn.Click += new System.EventHandler(this.sakla_btn_Click);
            // 
            // cik_btn
            // 
            this.cik_btn.BackColor = System.Drawing.Color.Transparent;
            this.cik_btn.Image = ((System.Drawing.Image)(resources.GetObject("cik_btn.Image")));
            this.cik_btn.ImageActive = null;
            this.cik_btn.Location = new System.Drawing.Point(463, 0);
            this.cik_btn.Name = "cik_btn";
            this.cik_btn.Size = new System.Drawing.Size(59, 46);
            this.cik_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.cik_btn.TabIndex = 12;
            this.cik_btn.TabStop = false;
            this.cik_btn.Zoom = 10;
            this.cik_btn.Click += new System.EventHandler(this.cik_btn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(121, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(268, 201);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // kayitOl_btn
            // 
            this.kayitOl_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.kayitOl_btn.color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.kayitOl_btn.colorActive = System.Drawing.Color.MediumSeaGreen;
            this.kayitOl_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.kayitOl_btn.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kayitOl_btn.ForeColor = System.Drawing.Color.Blue;
            this.kayitOl_btn.Image = ((System.Drawing.Image)(resources.GetObject("kayitOl_btn.Image")));
            this.kayitOl_btn.ImagePosition = -20;
            this.kayitOl_btn.ImageZoom = 100;
            this.kayitOl_btn.LabelPosition = 16;
            this.kayitOl_btn.LabelText = "KULLANICI KAYIT";
            this.kayitOl_btn.Location = new System.Drawing.Point(82, 373);
            this.kayitOl_btn.Margin = new System.Windows.Forms.Padding(6);
            this.kayitOl_btn.Name = "kayitOl_btn";
            this.kayitOl_btn.Size = new System.Drawing.Size(113, 78);
            this.kayitOl_btn.TabIndex = 6;
            this.kayitOl_btn.Click += new System.EventHandler(this.kayitOl_btn_Click);
            // 
            // sifreGoster
            // 
            this.sifreGoster.BackColor = System.Drawing.Color.Transparent;
            this.sifreGoster.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sifreGoster.BackgroundImage")));
            this.sifreGoster.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sifreGoster.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sifreGoster.Location = new System.Drawing.Point(435, 313);
            this.sifreGoster.Name = "sifreGoster";
            this.sifreGoster.OffColor = System.Drawing.Color.Gray;
            this.sifreGoster.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(202)))), ((int)(((byte)(94)))));
            this.sifreGoster.Size = new System.Drawing.Size(35, 20);
            this.sifreGoster.TabIndex = 1;
            this.sifreGoster.Value = true;
            this.sifreGoster.OnValueChange += new System.EventHandler(this.sifreGoster_OnValueChange);
            // 
            // giris_btn
            // 
            this.giris_btn.ActiveBorderThickness = 1;
            this.giris_btn.ActiveCornerRadius = 20;
            this.giris_btn.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.giris_btn.ActiveForecolor = System.Drawing.Color.White;
            this.giris_btn.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.giris_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.giris_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("giris_btn.BackgroundImage")));
            this.giris_btn.ButtonText = "GİRİŞ YAP";
            this.giris_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.giris_btn.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.giris_btn.ForeColor = System.Drawing.Color.SeaGreen;
            this.giris_btn.IdleBorderThickness = 1;
            this.giris_btn.IdleCornerRadius = 20;
            this.giris_btn.IdleFillColor = System.Drawing.Color.White;
            this.giris_btn.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.giris_btn.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.giris_btn.Location = new System.Drawing.Point(231, 409);
            this.giris_btn.Margin = new System.Windows.Forms.Padding(5);
            this.giris_btn.Name = "giris_btn";
            this.giris_btn.Size = new System.Drawing.Size(223, 71);
            this.giris_btn.TabIndex = 5;
            this.giris_btn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.giris_btn.Click += new System.EventHandler(this.giris_btn_Click);
            // 
            // eczaneKayit_btn
            // 
            this.eczaneKayit_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.eczaneKayit_btn.color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.eczaneKayit_btn.colorActive = System.Drawing.Color.MediumSeaGreen;
            this.eczaneKayit_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.eczaneKayit_btn.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.eczaneKayit_btn.ForeColor = System.Drawing.Color.Blue;
            this.eczaneKayit_btn.Image = ((System.Drawing.Image)(resources.GetObject("eczaneKayit_btn.Image")));
            this.eczaneKayit_btn.ImagePosition = -25;
            this.eczaneKayit_btn.ImageZoom = 100;
            this.eczaneKayit_btn.LabelPosition = 16;
            this.eczaneKayit_btn.LabelText = "ECZANE KAYIT";
            this.eczaneKayit_btn.Location = new System.Drawing.Point(82, 463);
            this.eczaneKayit_btn.Margin = new System.Windows.Forms.Padding(6);
            this.eczaneKayit_btn.Name = "eczaneKayit_btn";
            this.eczaneKayit_btn.Size = new System.Drawing.Size(113, 78);
            this.eczaneKayit_btn.TabIndex = 14;
            this.eczaneKayit_btn.Click += new System.EventHandler(this.eczaneKayit_btn_Click);
            // 
            // giris_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(523, 555);
            this.Controls.Add(this.eczaneKayit_btn);
            this.Controls.Add(this.sakla_btn);
            this.Controls.Add(this.cik_btn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.sifremiUnuttum_lbl);
            this.Controls.Add(this.kayitOl_btn);
            this.Controls.Add(this.sifre_txt);
            this.Controls.Add(this.sifreGoster);
            this.Controls.Add(this.k_adi_txt);
            this.Controls.Add(this.giris_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "giris_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GİRİŞ";
            ((System.ComponentModel.ISupportInitialize)(this.sakla_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cik_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuThinButton2 giris_btn;
        private Bunifu.Framework.UI.BunifuMaterialTextbox k_adi_txt;
        private Bunifu.Framework.UI.BunifuiOSSwitch sifreGoster;
        private Bunifu.Framework.UI.BunifuMaterialTextbox sifre_txt;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuImageButton sakla_btn;
        private Bunifu.Framework.UI.BunifuImageButton cik_btn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel sifremiUnuttum_lbl;
        private Bunifu.Framework.UI.BunifuTileButton kayitOl_btn;
        private Bunifu.Framework.UI.BunifuTileButton eczaneKayit_btn;
    }
}

