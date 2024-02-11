using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PansiyonKayitUygulamasi
{
    public partial class FrmCikisYapmisMusteriler : Form
    {
        public FrmCikisYapmisMusteriler()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        private void satisListesi()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter adtr = new SqlDataAdapter("select * from Tbl_Cikislar", bgl.baglanti());
                adtr.Fill(dt);
                dataGridView1.DataSource = dt;
                bgl.baglanti().Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }

        private void FrmCikisYapmisMusteriler_Load(object sender, EventArgs e)
        {
            satisListesi();
        }
    }
}
