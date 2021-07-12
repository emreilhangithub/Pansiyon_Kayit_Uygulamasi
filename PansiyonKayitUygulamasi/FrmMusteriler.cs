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
    public partial class FrmMusteriler : Form
    {
        sqlbaglantisi bgl = new sqlbaglantisi();
        Musteri musteri = new Musteri();
        //int id = 0;

        public FrmMusteriler()
        {
            InitializeComponent();
        }

        void listele()
        {                   
            List<Musteri> musteriListele = new List<Musteri>();
            DataTable tablo = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select  [Musteri_Id],[Ad],[Soyad],[Cinsiyet],[Telefon],[Mail],[Tc] from Tbl_Musteri ", bgl.baglanti());
            da.Fill(tablo);

            musteriListele = tablo.AsEnumerable().Select(s => new Musteri
            {
                Musteri_Id1 = s.Field<int>("Musteri_Id"),
                Ad1 = s.Field<string>("Ad"),
                Soyad1 = s.Field<string>("Soyad"),
                Cinsiyet1 = s.Field<string>("Cinsiyet"),
                Telefon1 = s.Field<string>("Telefon"),
                Mail1 = s.Field<string>("Mail"),
                Tc1 = s.Field<string>("Tc")
            }
          ).ToList();


            dataGridView1.DataSource = musteriListele;
        }

        void temizle()
        {
            musteri.Musteri_Id1 = 0;
            txtAd.Clear();
            txtSoyad.Clear();
            cmbCinsiyet.Text = "";   
            mskTelefon.Clear();    
            txtMail.Clear();       
            txtTc.Clear();             
            txtArama.Clear();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {       
            musteri.Musteri_Id1 = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()); //idyi gizledik kimse göremiyor
            txtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            cmbCinsiyet.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            mskTelefon.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtMail.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtTc.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();       
            //txtArama.Text = musteri.Musteri_Id1.ToString();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
           temizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            musteri.Ad1 = txtAd.Text;
            musteri.Soyad1 = txtSoyad.Text;
            musteri.Cinsiyet1 = cmbCinsiyet.Text;
            musteri.Telefon1 = mskTelefon.Text;
            musteri.Mail1 = txtMail.Text;
            musteri.Tc1 = txtTc.Text;
            //lblToplamGun.Text = dtpCikisTarihi.Value.ToString("yyyy-MM-dd");
            //lblToplamGun.Text = musteri.GirisTarihi1.ToString();

            SqlCommand guncellemekomutu = new SqlCommand("UPDATE Tbl_Musteri  SET Ad=@Ad,Soyad=@Soyad,Cinsiyet=@Cinsiyet,Telefon=@Telefon,Mail=@Mail,Tc=@Tc where Musteri_Id=@Musteri_Id", bgl.baglanti());
            guncellemekomutu.Parameters.AddWithValue("@Ad", musteri.Ad1);
            guncellemekomutu.Parameters.AddWithValue("@Soyad", musteri.Soyad1);
            guncellemekomutu.Parameters.AddWithValue("@Cinsiyet", musteri.Cinsiyet1);
            guncellemekomutu.Parameters.AddWithValue("@Telefon", musteri.Telefon1);
            guncellemekomutu.Parameters.AddWithValue("@Mail", musteri.Mail1);
            guncellemekomutu.Parameters.AddWithValue("@Tc", musteri.Tc1);
            guncellemekomutu.Parameters.AddWithValue("@Musteri_Id", musteri.Musteri_Id1);

            int etkilenen = guncellemekomutu.ExecuteNonQuery();
            if (etkilenen > 0)
            {
                MessageBox.Show("Güncelleme Başarılı");
                listele();
                temizle();
            }
            else
            {
                MessageBox.Show("Günceleme işlemi başarısız!!!!!!!!!");
            }
            bgl.baglanti().Close();
            
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            musteri.Tc1 = txtArama.Text;

            List<Musteri> musteriAra = new List<Musteri>();
            DataTable tablo = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select  [Musteri_Id],[Ad],[Soyad],[Cinsiyet],[Telefon],[Mail],[Tc] from Tbl_Musteri ", bgl.baglanti());
            da.Fill(tablo);

            musteriAra = tablo.AsEnumerable().Select(s => new Musteri
            {
                Musteri_Id1 = s.Field<int>("Musteri_Id"),
                Ad1 = s.Field<string>("Ad"),
                Soyad1 = s.Field<string>("Soyad"),
                Cinsiyet1 = s.Field<string>("Cinsiyet"),
                Telefon1 = s.Field<string>("Telefon"),
                Mail1 = s.Field<string>("Mail"),
                Tc1 = s.Field<string>("Tc")
            }
          ).Where(s=> s.Tc1.Contains(musteri.Tc1)).ToList();


            dataGridView1.DataSource = musteriAra;
















        }
    }
}
