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

        public void odaDurumu()
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
            ).Where(x => x.Oda_Durumu == "BOŞ").ToList();

            cmbOdaNo.DisplayMember = "Oda_Numarasi";
            cmbOdaNo.ValueMember = "Oda_Numarasi";
            cmbOdaNo.DataSource = order;
        }

        void odaGuncelle()
        {
            SqlCommand odaguncellekomutu = new SqlCommand("UPDATE Tbl_Odalar SET Oda_Durumu='DOLU' where Oda_Numarasi=@Oda_Numarasi", bgl.baglanti());
            odaguncellekomutu.Parameters.AddWithValue("@Oda_Numarasi", musteri.OdaNo1);
            int etkilenen = odaguncellekomutu.ExecuteNonQuery();
            if (etkilenen > 0)
            {
                MessageBox.Show("Oda Durumu Güncellemesi Başarılı");
            }
            else
            {
                MessageBox.Show("Günceleme işlemi başarısız!!!!!!!!!");
            }           
           
            odaDurumu();            
            bgl.baglanti().Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            musteri.Ad1          = txtAd.Text;
            musteri.Soyad1       = txtSoyad.Text;
            musteri.Cinsiyet1    = cmbCinsiyet.Text;
            musteri.Telefon1     = mskTelefon.Text;
            musteri.Mail1        = txtMail.Text;
            musteri.Tc1          = txtTc.Text;
            musteri.OdaNo1       = cmbOdaNo.Text;
            musteri.GirisTarihi1 = DateTime.Parse(dtpGirisTarihi.Text);

            SqlCommand kaydetkomutu = new SqlCommand("insert into Tbl_Musteri (Ad,Soyad,Cinsiyet,Telefon,Mail,Tc,OdaNo,GirisTarihi) values(@Ad,@Soyad,@Cinsiyet,@Telefon,@Mail,@Tc,@OdaNo,@GirisTarihi)", bgl.baglanti());
            kaydetkomutu.Parameters.AddWithValue("@Ad", musteri.Ad1);
            kaydetkomutu.Parameters.AddWithValue("@Soyad", musteri.Soyad1);
            kaydetkomutu.Parameters.AddWithValue("@Cinsiyet", musteri.Cinsiyet1);
            kaydetkomutu.Parameters.AddWithValue("@Telefon", musteri.Telefon1);
            kaydetkomutu.Parameters.AddWithValue("@Mail", musteri.Mail1);
            kaydetkomutu.Parameters.AddWithValue("@Tc", musteri.Tc1);
            kaydetkomutu.Parameters.AddWithValue("@OdaNo", musteri.OdaNo1);
            kaydetkomutu.Parameters.AddWithValue("@GirisTarihi", musteri.GirisTarihi1);            

            int etkilenen = kaydetkomutu.ExecuteNonQuery();
            if (etkilenen > 0)
            {
                MessageBox.Show("Kayıt Başarılı");
            }
            else
            {
                MessageBox.Show("Kayıt işlemi başarısız!!!!!!!!!");
            }
            bgl.baglanti().Close();
            odaGuncelle();        

        }

        private void FrmYeniMusteri_Load(object sender, EventArgs e)
        {
            odaDurumu();
        }


    }
}
