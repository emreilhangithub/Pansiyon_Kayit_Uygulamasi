using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PansiyonKayitUygulamasi
{
    public partial class frmMusteriCikis : Form
    {

        sqlbaglantisi bgl = new sqlbaglantisi();
        Odalar oda = new Odalar();
        Musteri muster = new Musteri();

        public frmMusteriCikis()
        {
            InitializeComponent();
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMusteriCikis_Load(object sender, EventArgs e)
        {
            MusteriGetir();
            DoluOdalar();
            timer1.Enabled = true;

        }

        private void DoluOdalar()
        {
            List<Odalar> order = new List<Odalar>();
            DataTable tablo = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select Oda_Numarasi,Oda_Durumu FROM Tbl_Odalar", bgl.baglanti());
            da.Fill(tablo);

            order = tablo.AsEnumerable().Select(s => new Odalar
            {
                Oda_Numarasi = s.Field<string>("Oda_Numarasi"),
                Oda_Durumu = s.Field<string>("Oda_Durumu")
            }
            ).Where(x => x.Oda_Durumu == "DOLU").ToList();

            cmbOdaNumarasiSec.DisplayMember = "Oda_Numarasi";
            cmbOdaNumarasiSec.ValueMember = "Oda_Numarasi";
            cmbOdaNumarasiSec.DataSource = order;
        }

        private void MusteriGetir()
        {
            List<Musteri> mus = new List<Musteri>();
            DataTable tablo = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * FROM Tbl_Musteri", bgl.baglanti());
            da.Fill(tablo);

            mus = tablo.AsEnumerable().Select(s => new Musteri
            {
                 Tc1 = s.Field<string>("Tc")
            }
            ).ToList();

            cmbOdaAra.DisplayMember = "Tc1";
            cmbOdaAra.ValueMember = "Tc1";
            cmbOdaAra.DataSource = mus;
        }

        private void cmbPlakaAra_SelectedIndexChanged(object sender, EventArgs e)
        {
            muster.Tc1 = cmbOdaAra.SelectedValue.ToString();

            List<Musteri> mus = new List<Musteri>();
            DataTable tablo = new DataTable();
            SqlCommand komut = new SqlCommand("Select OdaNo,Tc FROM Tbl_Musteri where Tc=@Tc", bgl.baglanti());
            komut.Parameters.AddWithValue("@Tc", muster.Tc1);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.Fill(tablo);

            mus = tablo.AsEnumerable().Select(s => new Musteri
            {
                OdaNo1 = s.Field<string>("OdaNo")
            }
            ).ToList();

            var test = mus.FirstOrDefault();

            txtSeciliOda.Text = test.OdaNo1;

        }

        private void lblCikisTarihi_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblCikisTarihi.Text = DateTime.Now.ToString();
        }

        private void cmbParkYeri_SelectedIndexChanged(object sender, EventArgs e)
        {
            muster.OdaNo1 = cmbOdaNumarasiSec.SelectedValue.ToString();

            List<Musteri> mus = new List<Musteri>();
            DataTable tablo = new DataTable();
            SqlCommand komut = new SqlCommand("Select [Musteri_Id],[Ad],[Soyad],[Cinsiyet],[Telefon],[Mail],[Tc],[OdaNo],[GirisTarihi] FROM Tbl_Musteri where OdaNo=@OdaNo", bgl.baglanti());
            komut.Parameters.AddWithValue("@OdaNo", muster.OdaNo1);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.Fill(tablo);

            mus = tablo.AsEnumerable().Select(s => new Musteri
            {
                //Musteri_Id1 = s.Field<int>("Musteri_Id"),
                Ad1 = s.Field<string>("Ad"),
                Soyad1 = s.Field<string>("Soyad"),
                Cinsiyet1 = s.Field<string>("Cinsiyet"),
                Telefon1 = s.Field<string>("Telefon"),
                Mail1 = s.Field<string>("Mail"),
                Tc1 = s.Field<string>("Tc"),
                OdaNo1 = s.Field<string>("OdaNo"),
                GirisTarihi1 = s.Field<DateTime>("GirisTarihi")
            }
            ).ToList();

            var test = mus.FirstOrDefault();

            txtSeciliOda2.Text = test.OdaNo1;
            txtTc.Text = test.Tc1;
            txtAd.Text = test.Ad1;
            txtSoyad.Text = test.Soyad1;
            txtCinsiyet.Text = test.Cinsiyet1;
            txtTelefon.Text = test.Telefon1;
            txtMail.Text = test.Mail1;
            lblGelisTarihi.Text = test.GirisTarihi1.ToString();           

        }

        private void btnAracCikisi_Click(object sender, EventArgs e)
        {
            DateTime gelis, cikis;
            gelis = DateTime.Parse(lblGelisTarihi.Text);
            cikis = DateTime.Parse(lblCikisTarihi.Text);
            TimeSpan fark; //aradaki fark için
            fark = cikis - gelis;
            lblSure.Text = fark.TotalHours.ToString("0.00");//2 basamaklı gosterdik virgülden sonra
            lblToplamTutar.Text = (double.Parse(lblSure.Text) * (0.75)).ToString();

            SqlCommand komut = new SqlCommand("delete from Tbl_Musteri where Tc=@Tc", bgl.baglanti());
            komut.Parameters.AddWithValue("@Tc", txtTc.Text);
            komut.ExecuteNonQuery();

            SqlCommand komut2 = new SqlCommand("update Tbl_Odalar set Oda_Durumu='BOŞ' where Oda_Numarasi=@Oda_Numarasi", bgl.baglanti());
            komut2.Parameters.AddWithValue("@Oda_Numarasi", txtSeciliOda2.Text);
            komut2.ExecuteNonQuery();

            SqlCommand komut3 = new SqlCommand("insert into Tbl_Cikislar (oda_numarasi,tc,gelis_tarihi,cikis_tarihi,sure,tutar) values(@oda_numarasi,@tc,@gelis_tarihi,@cikis_tarihi,@sure,@tutar) ", bgl.baglanti());
            komut3.Parameters.AddWithValue("@oda_numarasi", txtSeciliOda2.Text);
            komut3.Parameters.AddWithValue("@tc", txtTc.Text);
            komut3.Parameters.AddWithValue("@gelis_tarihi", lblGelisTarihi.Text);
            komut3.Parameters.AddWithValue("@cikis_tarihi", lblCikisTarihi.Text);
            komut3.Parameters.AddWithValue("@sure", double.Parse(lblSure.Text));
            komut3.Parameters.AddWithValue("@tutar", double.Parse(lblToplamTutar.Text));
            komut3.ExecuteNonQuery();

            FrmYeniMusteri frmkayit = new FrmYeniMusteri();
            frmkayit.odaDurumu();

            bgl.baglanti().Close();


            MessageBox.Show("Araç Çıkışı yapıldı");


            foreach (Control item in grpMusteriBilgileri.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                    txtSeciliOda.Text = "";
                    cmbOdaAra.Text = "";
                    cmbOdaNumarasiSec.Text = "";
                }
            }
            lblSure.Text = "0";
            lblToplamTutar.Text = "0";
            DoluOdalar();
            MusteriGetir();


        }
    }
}
