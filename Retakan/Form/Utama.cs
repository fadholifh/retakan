using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Data.SqlClient;

namespace Retakan
{
    public partial class Utama : Form
    {
        private SqlConnection koneksiObj;
        public Utama()
        {
            InitializeComponent();
            InitializePosition();
            koneksiObj = KoneksiDB.Koneksi.GetKoneksi();
        }
        String[,] rssData = null;
        private String[,] getRssData(String chanel)
        {
            System.Net.WebRequest myRequest = System.Net.WebRequest.Create(chanel);
            System.Net.WebResponse myResponse = myRequest.GetResponse();

            System.IO.Stream rssStream = myResponse.GetResponseStream();
            System.Xml.XmlDocument rssDoc = new System.Xml.XmlDocument();

            rssDoc.Load(rssStream);
            System.Xml.XmlNodeList rssItem = rssDoc.SelectNodes("rss/channel/item");

            String[,] tempRssData = new String[100, 3];

            for (int i = 0; i < 5; i++)
            {
                System.Xml.XmlNode rssNode;
                rssNode = rssItem.Item(i).SelectSingleNode("title");
                if (rssNode != null)
                {
                    tempRssData[i, 0] = rssNode.InnerText;
                }
                else
                {
                    tempRssData[i, 0] = "";
                }
                rssNode = rssItem.Item(i).SelectSingleNode("description");
                if (rssNode != null)
                {
                    tempRssData[i, 1] = rssNode.InnerText;
                }
                else
                {
                    tempRssData[i, 1] = "";
                }
                rssNode = rssItem.Item(i).SelectSingleNode("link");
                if (rssNode != null)
                {
                    tempRssData[i, 2] = rssNode.InnerText;
                }
                else
                {
                    tempRssData[i, 2] = "";
                }
            }
            return tempRssData;
        }
        private void InitializePosition()
        {
            // Set Extend Attribute
            this.ClientSize = new System.Drawing.Size(800, 600);
            PanelMain.BackColor = Color.FromArgb(20, 0, 0, 0);
            //PanelMain.ClientSize = new System.Drawing.Size(697, 522);
            PanelA1.BackColor = Color.FromArgb(180, 158, 33, 36);
            PanelA2.BackColor = Color.FromArgb(150, 158, 33, 36);
            PanelB1.BackColor = Color.FromArgb(180, 156, 77, 35);
            PanelB2.BackColor = Color.FromArgb(150, 156, 77, 35);
            PanelC1.BackColor = Color.FromArgb(180, 17, 147, 36);
            PanelC2.BackColor = Color.FromArgb(150, 17, 147, 36);
            PanelAtas.BackColor = Color.FromArgb(70, 0, 0, 0);
            PanelKiri.BackColor = Color.FromArgb(50, 0, 0, 0);
            PanelSearch.BackColor = Color.FromArgb(0, 255, 255, 255);
            PnlTxt.BackColor = Color.FromArgb(0, 255, 255, 255);
            PnlBg.BackColor = Color.FromArgb(80, 255, 255, 255);
            DGView.BackgroundColor = Color.Lavender;
            panel1.BackColor = Color.Transparent;

            LblJudul1.BackColor = Color.Transparent;
            LblJudul2.BackColor = Color.Transparent;
            LblJudul3.BackColor = Color.Transparent;
            LblIsi1.BackColor = Color.Transparent;
            LblIsi2.BackColor = Color.Transparent;
            LblIsi3.BackColor = Color.Transparent;

            LblSkala1.BackColor = Color.Transparent;
            LblSkala2.BackColor = Color.Transparent;
            LblSkala3.BackColor = Color.Transparent;
            LblMag1.BackColor = Color.Transparent;
            LblMag2.BackColor = Color.Transparent;
            LblMag3.BackColor = Color.Transparent;
            LblSR1.BackColor = Color.Transparent;
            LblSR2.BackColor = Color.Transparent;
            LblSR3.BackColor = Color.Transparent;
            LblLokasi1.BackColor = Color.Transparent;
            LblLokasi2.BackColor = Color.Transparent;
            LblLokasi3.BackColor = Color.Transparent;
            LblWaktu1.BackColor = Color.Transparent;
            LblWaktu2.BackColor = Color.Transparent;
            LblWaktu3.BackColor = Color.Transparent;
            LblPTsunami1.BackColor = Color.Transparent;
            LblPTsunami2.BackColor = Color.Transparent;
            LblPTsunami3.BackColor = Color.Transparent;

            LblSkala1.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            LblMag1.Font = new Font("Myraid Pro", 72, FontStyle.Bold);
            LblSR1.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            LblLokasi1.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            LblWaktu1.Font = new Font("Segoe UI", 8, FontStyle.Bold);
            LblPTsunami1.Font = new Font("Segoe UI", 8, FontStyle.Bold);
            LblSkala2.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            LblMag2.Font = new Font("Myraid Pro", 72, FontStyle.Bold);
            LblSR2.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            LblLokasi2.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            LblWaktu2.Font = new Font("Segoe UI", 8, FontStyle.Bold);
            LblPTsunami2.Font = new Font("Segoe UI", 8, FontStyle.Bold);
            LblSkala3.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            LblMag3.Font = new Font("Myraid Pro", 72, FontStyle.Bold);
            LblSR3.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            LblLokasi3.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            LblWaktu3.Font = new Font("Segoe UI", 8, FontStyle.Bold);
            LblPTsunami3.Font = new Font("Segoe UI", 8, FontStyle.Bold);

            BtnMinimize.Text = "";
            BtnMinimize.BackColor = Color.Transparent;
            BtnMinimize.FlatAppearance.BorderSize = 0;
            BtnMinimize.FlatStyle = FlatStyle.Flat;
            BtnMinimize.FlatAppearance.MouseDownBackColor = Color.Transparent;
            BtnMinimize.FlatAppearance.MouseOverBackColor = Color.Transparent;

            BtnClose.Text = "";
            BtnClose.BackColor = Color.Transparent;
            BtnClose.FlatAppearance.BorderSize = 0;
            BtnClose.FlatStyle = FlatStyle.Flat;
            BtnClose.FlatAppearance.MouseDownBackColor = Color.Transparent;
            BtnClose.FlatAppearance.MouseOverBackColor = Color.Transparent;

            BtnTerkini.Text = "";
            BtnTerkini.BackColor = Color.Transparent;
            BtnTerkini.FlatAppearance.BorderSize = 0;
            BtnTerkini.FlatStyle = FlatStyle.Flat;
            BtnTerkini.FlatAppearance.MouseDownBackColor = Color.Transparent;
            BtnTerkini.FlatAppearance.MouseOverBackColor = Color.Transparent;

            BtnMaps.Text = "";
            BtnMaps.BackColor = Color.Transparent;
            BtnMaps.FlatAppearance.BorderSize = 0;
            BtnMaps.FlatStyle = FlatStyle.Flat;
            BtnMaps.FlatAppearance.MouseDownBackColor = Color.Transparent;
            BtnMaps.FlatAppearance.MouseOverBackColor = Color.Transparent;

            BtnSearch.Text = "";
            BtnSearch.BackColor = Color.Transparent;
            BtnSearch.FlatAppearance.BorderSize = 0;
            BtnSearch.FlatStyle = FlatStyle.Flat;
            BtnSearch.FlatAppearance.MouseDownBackColor = Color.Transparent;
            BtnSearch.FlatAppearance.MouseOverBackColor = Color.Transparent;

            BtnCari.Text = "";
            BtnCari.BackColor = Color.Transparent;
            BtnCari.FlatAppearance.BorderSize = 0;
            BtnCari.FlatStyle = FlatStyle.Flat;
            BtnCari.FlatAppearance.MouseDownBackColor = Color.Transparent;
            BtnCari.FlatAppearance.MouseOverBackColor = Color.Transparent;

            BtnBTempat.Text = "";
            BtnBTempat.BackColor = Color.Transparent;
            BtnBTempat.FlatAppearance.BorderSize = 0;
            BtnBTempat.FlatStyle = FlatStyle.Flat;
            BtnBTempat.FlatAppearance.MouseDownBackColor = Color.Transparent;
            BtnBTempat.FlatAppearance.MouseOverBackColor = Color.Transparent;

            BtnBWaktu.Text = "";
            BtnBWaktu.BackColor = Color.Transparent;
            BtnBWaktu.FlatAppearance.BorderSize = 0;
            BtnBWaktu.FlatStyle = FlatStyle.Flat;
            BtnBWaktu.FlatAppearance.MouseDownBackColor = Color.Transparent;
            BtnBWaktu.FlatAppearance.MouseOverBackColor = Color.Transparent;


            //bound
            PanelAtas.SetBounds(0, 0, 800, 90);
            PanelKiri.SetBounds(0, 90, 80, 510);
            PanelMain.SetBounds(80, 90, 720, 510);
            PanelA1.SetBounds(0, 0, 240, 171);
            PanelA2.SetBounds(240, 0, 480, 171);
            PanelB1.SetBounds(0, 171, 240, 171);
            PanelB2.SetBounds(240, 171, 480, 171);
            PanelC1.SetBounds(0, 342, 240, 172);
            PanelC2.SetBounds(240, 342, 480, 171);
            PanelSearch.SetBounds(80, 90, 720, 510);
            PnlTxt.SetBounds(230, 70, 249, 24);
            DGView.SetBounds(230, 70, 249, 24);
            BtnBTempat.SetBounds(200, 20, 150, 25);
            BtnBWaktu.SetBounds(360, 20, 150, 25);
            BtnCari.SetBounds(430, 69, 39, 25);
            TxtCari.SetBounds(10, 1, 230, 25);
            WebMaps.SetBounds(80, 90, 720, 510);
            BtnMinimize.SetBounds(702, 0, 49, 21);
            BtnClose.SetBounds(751, 0, 49, 21);
            BtnTerkini.SetBounds(3, 20, 73, 73);
            BtnMaps.SetBounds(3, 104, 73, 73);
            BtnSearch.SetBounds(3, 188, 73, 73);
            DGView.SetBounds(35, 110, 650, 375);
            PnlBg.SetBounds(35, 110, 650, 375);
            DTPicker.SetBounds(230, 72, 200, 28);

            LblJudul1.SetBounds(5, 15, 230, 20);
            LblJudul2.SetBounds(5, 15, 230, 20);
            LblJudul3.SetBounds(5, 15, 230, 20);
            LblIsi1.SetBounds(5, 55, 230, 100);
            LblIsi2.SetBounds(5, 55, 230, 100);
            LblIsi3.SetBounds(5, 55, 230, 100);

            LblSkala1.SetBounds(5, 5, 73, 73);
            LblMag1.SetBounds(150, 30, 73, 73);
            LblSR1.SetBounds(300, 45, 73, 73);
            LblLokasi1.SetBounds(5, 145, 73, 73);
            LblWaktu1.SetBounds(350, 5, 73, 73);
            LblPTsunami1.SetBounds(335, 150, 73, 73);
            LblSkala2.SetBounds(5, 5, 73, 73);
            LblMag2.SetBounds(150, 30, 73, 73);
            LblSR2.SetBounds(300, 45, 73, 73);
            LblLokasi2.SetBounds(5, 145, 73, 73);
            LblWaktu2.SetBounds(350, 5, 73, 73);
            LblPTsunami2.SetBounds(335, 150, 73, 73);
            LblSkala3.SetBounds(5, 5, 73, 73);
            LblMag3.SetBounds(150, 30, 73, 73);
            LblSR3.SetBounds(300, 45, 73, 73);
            LblLokasi3.SetBounds(5, 145, 73, 73);
            LblWaktu3.SetBounds(350, 5, 73, 73);
            LblPTsunami3.SetBounds(335, 150, 73, 73);

            label44.SetBounds(10, 20, 31, 30);
            label43.SetBounds(50, 20, 295, 30);
            label42.SetBounds(350, 20, 186, 30);
            label41.SetBounds(540, 20, 100, 30);

            label1.SetBounds(10, 65, 31, 23);
            label2.SetBounds(50, 65, 295, 23);
            label3.SetBounds(350, 65, 186, 23);
            label4.SetBounds(540, 65, 100, 23);
            label5.SetBounds(10, 95, 31, 23);
            label6.SetBounds(50, 95, 295, 23);
            label7.SetBounds(350, 95, 186, 23);
            label8.SetBounds(540, 95, 100, 23);
            label12.SetBounds(10, 125, 31, 23);
            label11.SetBounds(50, 125, 295, 23);
            label10.SetBounds(350, 125, 186, 23);
            label9.SetBounds(540, 125, 100, 23);
            label16.SetBounds(10, 155, 31, 23);
            label15.SetBounds(50, 155, 295, 23);
            label14.SetBounds(350, 155, 186, 23);
            label13.SetBounds(540, 155, 100, 23);
            label20.SetBounds(10, 185, 31, 23);
            label19.SetBounds(50, 185, 295, 23);
            label18.SetBounds(350, 185, 186, 23);
            label17.SetBounds(540, 185, 100, 23);
            label24.SetBounds(10, 215, 31, 23);
            label23.SetBounds(50, 215, 295, 23);
            label22.SetBounds(350, 215, 186, 23);
            label21.SetBounds(540, 215, 100, 23);
            label28.SetBounds(10, 245, 31, 23);
            label27.SetBounds(50, 245, 295, 23);
            label26.SetBounds(350, 245, 186, 23);
            label25.SetBounds(540, 245, 100, 23);
            label32.SetBounds(10, 275, 31, 23);
            label31.SetBounds(50, 275, 295, 23);
            label30.SetBounds(350, 275, 186, 23);
            label29.SetBounds(540, 275, 100, 23);
            label36.SetBounds(10, 305, 31, 23);
            label35.SetBounds(50, 305, 295, 23);
            label34.SetBounds(350, 305, 186, 23);
            label33.SetBounds(540, 305, 100, 23);
            label40.SetBounds(10, 335, 31, 23);
            label39.SetBounds(50, 335, 295, 23);
            label38.SetBounds(350, 335, 186, 23);
            label37.SetBounds(540, 335, 100, 23);
            panel1.SetBounds(10, 5, 183, 74);



            this.BackgroundImage = global::Retakan.Properties.Resources.bg2;
            //PanelKiri.BackgroundImage = global::Retakan.Properties.Resources.kiri;
            //PanelAtas.BackgroundImage = global::Retakan.Properties.Resources.header;
            BtnClose.Image = global::Retakan.Properties.Resources.close;
            BtnMinimize.Image = global::Retakan.Properties.Resources.minim;
            BtnTerkini.Image = global::Retakan.Properties.Resources.terkini_off;
            PanelA2.BackgroundImage = global::Retakan.Properties.Resources.merah_;
            PanelB2.BackgroundImage = global::Retakan.Properties.Resources.orange_;
            PanelC2.BackgroundImage = global::Retakan.Properties.Resources.hijau_;
            BtnMaps.Image = global::Retakan.Properties.Resources.peta_off;
            BtnSearch.Image = global::Retakan.Properties.Resources.cari_off;
            PnlTxt.BackgroundImage = global::Retakan.Properties.Resources.caritxt;
            BtnCari.Image = global::Retakan.Properties.Resources.btncari_off;
            BtnBTempat.Image = global::Retakan.Properties.Resources.tempat_on;
            BtnBWaktu.Image = global::Retakan.Properties.Resources.waktu_off;
            panel1.BackgroundImage = global::Retakan.Properties.Resources.unnamed;



        }

        private void Utama_Load(object sender, EventArgs e)
        {
            PanelMain.Show();
            WebMaps.Hide();
            PanelSearch.Hide();
            BtnTerkini.Image = global::Retakan.Properties.Resources.terkini_on;
            BtnMaps.Image = global::Retakan.Properties.Resources.peta_off;
            BtnSearch.Image = global::Retakan.Properties.Resources.cari_off;

            PanelMain.Show();
            WebMaps.Hide();
            PanelSearch.Hide();
            BtnTerkini.Image = global::Retakan.Properties.Resources.terkini_on;
            BtnMaps.Image = global::Retakan.Properties.Resources.peta_off;
            BtnSearch.Image = global::Retakan.Properties.Resources.cari_off;

            rssData = getRssData("https://rss.sciencedaily.com/earth_climate/earthquakes.xml");
            LblJudul1.Text = rssData[0, 0];
            LblJudul2.Text = rssData[1, 0];
            LblJudul3.Text = rssData[2, 0];
            LblIsi1.Text = rssData[0, 1];
            LblIsi2.Text = rssData[1, 1];
            LblIsi3.Text = rssData[2, 1];

            A.AmbilDataBesar();
            D.AmbilDataMenengah();
            C.AmbilDataKecil();

            LblMag1.Text = A.mag.ToString("0.0", System.Globalization.CultureInfo.InvariantCulture);
            LblLokasi1.Text = A.place;
            LblWaktu1.Text = A.time.ToString();
            if (A.tsunami == "0")
            {
                LblPTsunami1.Text = "Tidak Berpotensi Tsunami";
            }
            else
            {
                LblPTsunami1.Text = "Berpotensi Tsunami";
            }
            Console.WriteLine(A.mag.ToString("0.0", System.Globalization.CultureInfo.InvariantCulture) + " Mag");

            LblMag2.Text = D.mag.ToString("0.0", System.Globalization.CultureInfo.InvariantCulture); ;
            LblLokasi2.Text = D.place;
            LblWaktu2.Text = D.time.ToString();
            Console.WriteLine(D.mag.ToString("0.0", System.Globalization.CultureInfo.InvariantCulture) + " Mag");
            Console.WriteLine(D.tsunami);
            if (D.tsunami == "0")
            {
                LblPTsunami2.Text = "Tidak Berpotensi Tsunami";
            }
            else
            {
                LblPTsunami2.Text = "Berpotensi Tsunami";
            }
            LblMag3.Text = C.mag.ToString("0.0", System.Globalization.CultureInfo.InvariantCulture); ;
            LblLokasi3.Text = C.place;
            LblWaktu3.Text = C.time.ToString();
            if (C.tsunami == "0")
            {
                LblPTsunami3.Text = "Tidak Berpotensi Tsunami";
            }
            else
            {
                LblPTsunami3.Text = "Berpotensi Tsunami";
            }
            Console.WriteLine(C.mag.ToString("0.0", System.Globalization.CultureInfo.InvariantCulture) + " Mag");
            
        }
        Process.AmbilData A = new Process.AmbilData();
        Process.AmbilBerdasarkanTanggal B = new Process.AmbilBerdasarkanTanggal();
        Process.AmbilData C = new Process.AmbilData();
        Process.AmbilData D = new Process.AmbilData();
        private void BtnTerkini_Click(object sender, EventArgs e)
        {
            PanelMain.Show();
            WebMaps.Hide();
            PanelSearch.Hide();
            BtnTerkini.Image = global::Retakan.Properties.Resources.terkini_on;
            BtnMaps.Image = global::Retakan.Properties.Resources.peta_off;
            BtnSearch.Image = global::Retakan.Properties.Resources.cari_off;

            rssData = getRssData("https://rss.sciencedaily.com/earth_climate/earthquakes.xml");
            LblJudul1.Text = rssData[0, 0];
            LblJudul2.Text = rssData[1, 0];
            LblJudul3.Text = rssData[2, 0];
            LblIsi1.Text = rssData[0, 1];
            LblIsi2.Text = rssData[1, 1];
            LblIsi3.Text = rssData[2, 1];

            A.AmbilDataBesar();
            D.AmbilDataMenengah();
            C.AmbilDataKecil();

            LblMag1.Text = A.mag.ToString("0.0", System.Globalization.CultureInfo.InvariantCulture);
            LblLokasi1.Text = A.place;
            LblWaktu1.Text = A.time.ToString();
            if (A.tsunami == "0")
            {
                LblPTsunami1.Text = "Tidak Berpotensi Tsunami";
            }
            else
            {
                LblPTsunami1.Text = "Berpotensi Tsunami";
            }
            Console.WriteLine(A.mag.ToString("0.0", System.Globalization.CultureInfo.InvariantCulture) + " Mag");

            LblMag2.Text = D.mag.ToString("0.0", System.Globalization.CultureInfo.InvariantCulture); ;
            LblLokasi2.Text = D.place;
            LblWaktu2.Text = D.time.ToString();
            Console.WriteLine(D.mag.ToString("0.0", System.Globalization.CultureInfo.InvariantCulture) + " Mag");
            Console.WriteLine(D.tsunami);
            if (D.tsunami == "0")
            {
                LblPTsunami2.Text = "Tidak Berpotensi Tsunami";
            }
            else
            {
                LblPTsunami2.Text = "Berpotensi Tsunami";
            }
            LblMag3.Text = C.mag.ToString("0.0", System.Globalization.CultureInfo.InvariantCulture); ;
            LblLokasi3.Text = C.place;
            LblWaktu3.Text = C.time.ToString();
            if (C.tsunami == "0")
            {
                LblPTsunami3.Text = "Tidak Berpotensi Tsunami";
            }
            else
            {
                LblPTsunami3.Text = "Berpotensi Tsunami";
            }
            Console.WriteLine(C.mag.ToString("0.0", System.Globalization.CultureInfo.InvariantCulture) + " Mag");
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnMaps_Click(object sender, EventArgs e)
        {
            PanelMain.Hide();
            WebMaps.Show();
            PanelSearch.Hide();
            BtnTerkini.Image = global::Retakan.Properties.Resources.terkini_off;
            BtnMaps.Image = global::Retakan.Properties.Resources.peta_on;
            BtnSearch.Image = global::Retakan.Properties.Resources.cari_off;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            PanelMain.Hide();
            WebMaps.Hide();
            PanelSearch.Show();
            PnlBg.Hide();
            BtnCari.Hide();
            DTPicker.Hide();
            TxtCari.Focus();
            PnlTxt.Show();
            DGView.Show();
            BtnBTempat.Image = global::Retakan.Properties.Resources.tempat_on;
            BtnBWaktu.Image = global::Retakan.Properties.Resources.waktu_off;
            BtnTerkini.Image = global::Retakan.Properties.Resources.terkini_off;
            BtnMaps.Image = global::Retakan.Properties.Resources.peta_off;
            BtnSearch.Image = global::Retakan.Properties.Resources.cari_on;

            //insert
            koneksiObj.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = null;
            sql = "insert into DataGempa (gempa,tempat,waktu,tsunami) values('" + C.mag + "','" + C.place + "','" + C.time.ToString("MM/dd/yyy hh:mm:ss") + "','" + C.tsunami + "')";
            try
            {
                adapter.InsertCommand = new SqlCommand(sql, koneksiObj);
                adapter.InsertCommand.ExecuteNonQuery();

                koneksiObj.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ex" + ex);
            }
        }

        private void BtnMinimize_MouseHover(object sender, EventArgs e)
        {
            BtnMinimize.Image = global::Retakan.Properties.Resources.minim_hov;
        }

        private void BtnMinimize_MouseLeave(object sender, EventArgs e)
        {
            BtnMinimize.Image = global::Retakan.Properties.Resources.minim;
        }

        private void BtnClose_MouseHover(object sender, EventArgs e)
        {
            BtnClose.Image = global::Retakan.Properties.Resources.close_hov;
        }

        private void BtnClose_MouseLeave(object sender, EventArgs e)
        {
            BtnClose.Image = global::Retakan.Properties.Resources.close;
        }

        private void BtnBTempat_Click(object sender, EventArgs e)
        {
            PnlBg.Hide();
            BtnCari.Hide();
            DTPicker.Hide();
            DGView.Show();
            PnlTxt.Show();
            TxtCari.Focus();
            BtnBTempat.Image = global::Retakan.Properties.Resources.tempat_on;
            BtnBWaktu.Image = global::Retakan.Properties.Resources.waktu_off;
        }

        private void BtnBWaktu_Click(object sender, EventArgs e)
        {
            PnlBg.Show();
            PnlTxt.Hide();
            BtnCari.Show();
            DTPicker.Show();
            DGView.Hide();
            BtnBTempat.Image = global::Retakan.Properties.Resources.tempat_off;
            BtnBWaktu.Image = global::Retakan.Properties.Resources.waktu_on;
        }

        private void TxtCari_TextChanged(object sender, EventArgs e)
        {
            SqlCommand proses = new SqlCommand("SELECT gempa[Besar Gempa],tempat[Tempat Terjadinya Gempa], waktu[Waktu Gempa], tsunami[Potensi] FROM DataGempa WHERE tempat like'%" + TxtCari.Text + "%'", koneksiObj);
            SqlDataAdapter adp = new SqlDataAdapter(proses);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            DGView.DataSource = dt;
            DataGridViewColumn column = DGView.Columns[0];
            column.Width = 90;
            DataGridViewColumn column1 = DGView.Columns[1];
            column1.Width = 260;
            DataGridViewColumn column2 = DGView.Columns[2];
            column2.Width = 150;
            DataGridViewColumn column3 = DGView.Columns[3];
            column3.Width = 105;
        }

        private void BtnCari_Click(object sender, EventArgs e)
        {
            B.AmbilBerdasarkanTanggalBase(DTPicker.Value.Date.ToString("yyyy-MM-dd"));
            label1.Text = B.mag.ToString("0.0", System.Globalization.CultureInfo.InvariantCulture); ;
            label2.Text = B.place;
            label3.Text = B.time.ToString();
            Console.WriteLine(A.time.ToString());
            Console.WriteLine(B.mag.ToString("0.0", System.Globalization.CultureInfo.InvariantCulture) + " Mag");
            Console.WriteLine(B.tsunami);
            if (B.tsunami == "0")
            {
                label4.Text = "Tidak Berpotensi Tsunami";
            }
            else
            {
                label4.Text = "Berpotensi Tsunami";
            }

            label5.Text = B.mag1.ToString("0.0", System.Globalization.CultureInfo.InvariantCulture); ;
            label6.Text = B.place1;
            label7.Text = B.time1.ToString();
            Console.WriteLine(B.mag1.ToString("0.0", System.Globalization.CultureInfo.InvariantCulture) + " Mag");
            Console.WriteLine(B.tsunami1);
            if (B.tsunami1 == "0")
            {
                label8.Text = "Tidak Berpotensi Tsunami";
            }
            else
            {
                label8.Text = "Berpotensi Tsunami";
            }

            label12.Text = B.mag2.ToString("0.0", System.Globalization.CultureInfo.InvariantCulture); ;
            label11.Text = B.place2;
            label10.Text = B.time2.ToString();
            Console.WriteLine(B.mag2.ToString("0.0", System.Globalization.CultureInfo.InvariantCulture) + " Mag");
            Console.WriteLine(B.tsunami2);
            if (B.tsunami2 == "0")
            {
                label9.Text = "Tidak Berpotensi Tsunami";
            }
            else
            {
                label9.Text = "Berpotensi Tsunami";
            }

            label16.Text = B.mag3.ToString("0.0", System.Globalization.CultureInfo.InvariantCulture); ;
            label15.Text = B.place3;
            label14.Text = B.time3.ToString();
            Console.WriteLine(B.mag3.ToString("0.0", System.Globalization.CultureInfo.InvariantCulture) + " Mag");
            Console.WriteLine(B.tsunami3);
            if (B.tsunami3 == "0")
            {
                label13.Text = "Tidak Berpotensi Tsunami";
            }
            else
            {
                label13.Text = "Berpotensi Tsunami";
            }

            label20.Text = B.mag4.ToString("0.0", System.Globalization.CultureInfo.InvariantCulture); ;
            label19.Text = B.place4;
            label18.Text = B.time4.ToString();
            Console.WriteLine(B.mag4.ToString("0.0", System.Globalization.CultureInfo.InvariantCulture) + " Mag");
            Console.WriteLine(B.tsunami4);
            if (B.tsunami4 == "0")
            {
                label17.Text = "Tidak Berpotensi Tsunami";
            }
            else
            {
                label17.Text = "Berpotensi Tsunami";
            }

            label24.Text = B.mag5.ToString("0.0", System.Globalization.CultureInfo.InvariantCulture); ;
            label23.Text = B.place5;
            label22.Text = B.time5.ToString();
            Console.WriteLine(B.mag5.ToString("0.0", System.Globalization.CultureInfo.InvariantCulture) + " Mag");
            Console.WriteLine(B.tsunami5);
            if (B.tsunami5 == "0")
            {
                label21.Text = "Tidak Berpotensi Tsunami";
            }
            else
            {
                label21.Text = "Berpotensi Tsunami";
            }

            label28.Text = B.mag6.ToString("0.0", System.Globalization.CultureInfo.InvariantCulture); ;
            label27.Text = B.place6;
            label26.Text = B.time6.ToString();
            Console.WriteLine(B.mag6.ToString("0.0", System.Globalization.CultureInfo.InvariantCulture) + " Mag");
            Console.WriteLine(B.tsunami6);
            if (B.tsunami6 == "0")
            {
                label25.Text = "Tidak Berpotensi Tsunami";
            }
            else
            {
                label25.Text = "Berpotensi Tsunami";
            }

            label32.Text = B.mag7.ToString("0.0", System.Globalization.CultureInfo.InvariantCulture); ;
            label31.Text = B.place7;
            label30.Text = B.time7.ToString();
            Console.WriteLine(B.mag7.ToString("0.0", System.Globalization.CultureInfo.InvariantCulture) + " Mag");
            Console.WriteLine(B.tsunami7);
            if (B.tsunami7 == "0")
            {
                label29.Text = "Tidak Berpotensi Tsunami";
            }
            else
            {
                label29.Text = "Berpotensi Tsunami";
            }

            label36.Text = B.mag8.ToString("0.0", System.Globalization.CultureInfo.InvariantCulture); ;
            label35.Text = B.place8;
            label34.Text = B.time8.ToString();
            Console.WriteLine(B.mag8.ToString("0.0", System.Globalization.CultureInfo.InvariantCulture) + " Mag");
            Console.WriteLine(B.tsunami8);
            if (B.tsunami8 == "0")
            {
                label33.Text = "Tidak Berpotensi Tsunami";
            }
            else
            {
                label33.Text = "Berpotensi Tsunami";
            }

            label40.Text = B.mag9.ToString("0.0", System.Globalization.CultureInfo.InvariantCulture); ;
            label39.Text = B.place9;
            label38.Text = B.time9.ToString();
            Console.WriteLine(B.mag9.ToString("0.0", System.Globalization.CultureInfo.InvariantCulture) + " Mag");
            Console.WriteLine(B.tsunami9);
            if (B.tsunami9 == "0")
            {
                label37.Text = "Tidak Berpotensi Tsunami";
            }
            else
            {
                label37.Text = "Berpotensi Tsunami";
            }
        }

        private void BtnCari_MouseHover(object sender, EventArgs e)
        {
            BtnCari.Image = global::Retakan.Properties.Resources.btncari_on;
        }

        private void BtnCari_MouseLeave(object sender, EventArgs e)
        {
            BtnCari.Image = global::Retakan.Properties.Resources.btncari_off;
        }
    }
}