using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.ToolTips;
using GMap.NET.WindowsForms.Markers;
using CefSharp;
using CefSharp.WinForms;

namespace E_Eczacım
{
    public partial class konum_form : Form
    {
        public konum_form()
        {
            InitializeComponent();
            
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {
            gMapControl1.ShowCenter = false;
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            gMapControl1.Position = new PointLatLng(39.1641410476874, 35.9912109375);
            gMapControl1.MinZoom = 5;
            gMapControl1.MaxZoom = 21;
            gMapControl1.Zoom = 5;
        }

        private void gMapControl1_MouseClick(object sender, MouseEventArgs e)
        {
            if (gMapControl1.Overlays.Count != 0)
                gMapControl1.Overlays.RemoveAt(0);
            if (e.Button == MouseButtons.Left)
            {
                double enlem = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lat;
                double boylam = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lng;

                GMapOverlay isaret = new GMapOverlay("markers");
                GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(enlem, boylam), GMarkerGoogleType.green_dot);
                isaret.Markers.Add(marker);
                marker.ToolTipText = enlem + " ; " + boylam;
                gMapControl1.Overlays.Add(isaret);
                gMapControl1.Zoom -= 1;
                gMapControl1.Zoom += 1;
                textBox1.Text = enlem + " ; " + boylam;
            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void konum_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Application.OpenForms["kayitOl_form"] != null)
            {
                kayitOl_form a = Application.OpenForms["kayitOl_form"] as kayitOl_form;
                a.txt_konum.Text = textBox1.Text;
            }
        }
    }
}
