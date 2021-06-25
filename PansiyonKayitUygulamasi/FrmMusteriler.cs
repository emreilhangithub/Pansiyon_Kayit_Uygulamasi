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
    }
}
