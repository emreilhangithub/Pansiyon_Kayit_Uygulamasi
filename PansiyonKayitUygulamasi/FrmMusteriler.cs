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
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Musteri ", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
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
            txtOdaNo.Clear();      
            txtUcret.Clear();      
            dtpGirisTarihi.Text = "";
            dtpCikisTarihi.Text = "";
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
            txtOdaNo.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtUcret.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            dtpGirisTarihi.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            dtpCikisTarihi.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
            //txtArama.Text = musteri.Musteri_Id1.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand silmekomutu = new SqlCommand("DELETE FROM Tbl_Musteri WHERE Musteri_Id=@Musteri_Id", bgl.baglanti());
            silmekomutu.Parameters.AddWithValue("@Musteri_Id",musteri.Musteri_Id1);

            int etkilenen = silmekomutu.ExecuteNonQuery();
            if (etkilenen > 0)
            {
                MessageBox.Show("Silme Başarılı");
                listele();
                temizle();
            }
            else
            {
                MessageBox.Show("Silme işlemi başarısız!!!!!!!!!");
            }
            bgl.baglanti().Close();
            

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
            musteri.OdaNo1 = txtOdaNo.Text;
            musteri.Ucret1 = decimal.Parse(txtUcret.Text);
            musteri.GirisTarihi1 = DateTime.Parse(dtpGirisTarihi.Text);
            musteri.CikisTarihi1 = DateTime.Parse(dtpCikisTarihi.Text);
            //lblToplamGun.Text = dtpCikisTarihi.Value.ToString("yyyy-MM-dd");
            //lblToplamGun.Text = musteri.GirisTarihi1.ToString();

            SqlCommand guncellemekomutu = new SqlCommand("UPDATE Tbl_Musteri  SET Ad=@Ad,Soyad=@Soyad,Cinsiyet=@Cinsiyet,Telefon=@Telefon,Mail=@Mail,Tc=@Tc,OdaNo=@OdaNo,Ucret=@Ucret,GirisTarihi=@GirisTarihi,CikisTarihi=@CikisTarihi where Musteri_Id=@Musteri_Id", bgl.baglanti());
            guncellemekomutu.Parameters.AddWithValue("@Ad", musteri.Ad1);
            guncellemekomutu.Parameters.AddWithValue("@Soyad", musteri.Soyad1);
            guncellemekomutu.Parameters.AddWithValue("@Cinsiyet", musteri.Cinsiyet1);
            guncellemekomutu.Parameters.AddWithValue("@Telefon", musteri.Telefon1);
            guncellemekomutu.Parameters.AddWithValue("@Mail", musteri.Mail1);
            guncellemekomutu.Parameters.AddWithValue("@Tc", musteri.Tc1);
            guncellemekomutu.Parameters.AddWithValue("@OdaNo", musteri.OdaNo1);
            guncellemekomutu.Parameters.AddWithValue("@Ucret", musteri.Ucret1);
            guncellemekomutu.Parameters.AddWithValue("@GirisTarihi", musteri.GirisTarihi1);
            guncellemekomutu.Parameters.AddWithValue("@CikisTarihi", musteri.CikisTarihi1);
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
            dataGridView1.DataSource = null;
            SqlCommand aramakomutu = new SqlCommand("Select * from Tbl_Musteri where Tc=@Tc",bgl.baglanti());
            aramakomutu.Parameters.AddWithValue("@Tc", txtArama.Text);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(aramakomutu);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
