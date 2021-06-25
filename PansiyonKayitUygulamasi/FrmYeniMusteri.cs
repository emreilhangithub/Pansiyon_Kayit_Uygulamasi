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
    public partial class FrmYeniMusteri : Form
    {
        public FrmYeniMusteri()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();
        Musteri musteri = new Musteri();

        private void btnOda101_Click(object sender, EventArgs e)
        {
            txtOdaNo.Text = "101";
        }

        private void btnOda102_Click(object sender, EventArgs e)
        {
            txtOdaNo.Text = "102";
        }

        private void btnOda103_Click(object sender, EventArgs e)
        {
            txtOdaNo.Text = "103";
        }

        private void btnOda104_Click(object sender, EventArgs e)
        {
            txtOdaNo.Text = "104";
        }

        private void btnOda105_Click(object sender, EventArgs e)
        {
            txtOdaNo.Text = "105";
        }

        private void btnOda106_Click(object sender, EventArgs e)
        {
            txtOdaNo.Text = "106";
        }

        private void btnOda107_Click(object sender, EventArgs e)
        {
            txtOdaNo.Text = "107";
        }

        private void btnOda108_Click(object sender, EventArgs e)
        {
            txtOdaNo.Text = "108";
        }

        private void btnOda109_Click(object sender, EventArgs e)
        {
            txtOdaNo.Text = "109";
        }

        private void btnDoluOda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kırmızı Renkli Butonlar Dolu Odaları Gösterir");
        }

        private void btnBosOda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Yeşil Renkli Butonlar Boş Odaları Gösterir");
        }

        private void dtpCikisTarihi_ValueChanged(object sender, EventArgs e)
        {
            //cıkıs tarihi değeri değiştigi zaman
            int ucret;
            DateTime kucukTarih = Convert.ToDateTime(dtpGirisTarihi.Text);
            DateTime buyukTarih = Convert.ToDateTime(dtpCikisTarihi.Text); //tarih olark tanımladık

            TimeSpan Sonuc;
            Sonuc = buyukTarih - kucukTarih; //aradaki farkı alır

            lblToplamGun.Text = Sonuc.TotalDays.ToString();
            //total daysa demezsek 000 ile yazar

            ucret = Convert.ToInt32(lblToplamGun.Text) * 50;
            txtUcret.Text = ucret.ToString();

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            musteri.Ad1          = txtAd.Text;
            musteri.Soyad1       = txtSoyad.Text;
            musteri.Cinsiyet1    = cmbCinsiyet.Text;
            musteri.Telefon1     = mskTelefon.Text;
            musteri.Mail1        = txtMail.Text;
            musteri.Tc1          = txtTc.Text;
            musteri.OdaNo1       = txtOdaNo.Text;
            musteri.Ucret1       = decimal.Parse(txtUcret.Text);
            musteri.GirisTarihi1 = DateTime.Parse(dtpGirisTarihi.Text);
            musteri.CikisTarihi1 = DateTime.Parse(dtpCikisTarihi.Text);
            //lblToplamGun.Text = dtpCikisTarihi.Value.ToString("yyyy-MM-dd");
            //lblToplamGun.Text = musteri.GirisTarihi1.ToString();

            SqlCommand kaydetkomutu = new SqlCommand("insert into Tbl_MusteriEkle (Ad,Soyad,Cinsiyet,Telefon,Mail,Tc,OdaNo,Ucret,GirisTarihi,CikisTarihi) values(@Ad,@Soyad,@Cinsiyet,@Telefon,@Mail,@Tc,@OdaNo,@Ucret,@GirisTarihi,@CikisTarihi)", bgl.baglanti());
            kaydetkomutu.Parameters.AddWithValue("@Ad", musteri.Ad1);
            kaydetkomutu.Parameters.AddWithValue("@Soyad", musteri.Soyad1);
            kaydetkomutu.Parameters.AddWithValue("@Cinsiyet", musteri.Cinsiyet1);
            kaydetkomutu.Parameters.AddWithValue("@Telefon", musteri.Telefon1);
            kaydetkomutu.Parameters.AddWithValue("@Mail", musteri.Mail1);
            kaydetkomutu.Parameters.AddWithValue("@Tc", musteri.Tc1);
            kaydetkomutu.Parameters.AddWithValue("@OdaNo", musteri.OdaNo1);
            kaydetkomutu.Parameters.AddWithValue("@Ucret", musteri.Ucret1);
            kaydetkomutu.Parameters.AddWithValue("@GirisTarihi", musteri.GirisTarihi1);
            kaydetkomutu.Parameters.AddWithValue("@CikisTarihi", musteri.CikisTarihi1);             

            int etkilenen = kaydetkomutu.ExecuteNonQuery();
            if (etkilenen > 0)
            {
                MessageBox.Show("Güncelleme Başarılı");
            }
            else
            {
                MessageBox.Show("Günceleme işlemi başarısız!!!!!!!!!");
            }
            bgl.baglanti().Close();

        }
    }
}
