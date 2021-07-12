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
    public partial class FrmOdalar : Form
    {
        public FrmOdalar()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();     

        private void FrmOdalar_Load(object sender, EventArgs e)
        {
            BosOdalar();
            DoluOdalar();
            MusteriTablosuKontrol(); //yeni kayıt olunca bunu yapacak
        }

        private void MusteriTablosuKontrol()
        {
            SqlCommand komut = new SqlCommand("Select * from Tbl_Musteri", bgl.baglanti());
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read()) //Kayıtlar okundugu sürece bu işlemi yap
            {
                foreach (Control item in Controls) //formdaki kontrolleri dolas
                {
                    if (item is Button) //itemler buton ise
                    {
                        if (item.Text == read["OdaNo"].ToString()) //eğer veri tabanındaki kayıt ile eşleşiyorsa item 
                        {
                            item.Text = read["Tc"].ToString(); //plakayı yaz
                        }

                    }
                }
            }
        }

        private void DoluOdalar()
        {
            SqlCommand komut = new SqlCommand("Select * from Tbl_Odalar", bgl.baglanti());
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read()) //Kayıtlar okundugu sürece bu işlemi yap
            {
                foreach (Control item in Controls) //formdaki kontrolleri dolas
                {
                    if (item is Button) //itemler buton ise
                    {
                        if (item.Text == read["Oda_Numarasi"].ToString() && read["Oda_Durumu"].ToString() == "DOLU") //eğer veri tabanındaki kayıt ile eşleşiyorsa item ve durumu dolu ise
                        {
                            item.BackColor = Color.Red;
                        }

                    }
                }
            }
        }

        private void BosOdalar()
        {
            int sayac = 1;
            foreach (Control item in Controls) //formdaki contorlleri dolaş
            {
                if (item is Button) //itemler buton ise
                {
                    item.Text = "O-" + sayac;
                    item.Name = "O-" + sayac;
                    sayac++;//dongu her calıstıgında sayac artsın
                }
            }
        }

        private void btnDoluOda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Dolu Odalar Kırmızı renk ile gösterilir");
        }

        private void btnBosOda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Boş Odalar Beyaz renk ile gösterilir");
        }
    }
}
