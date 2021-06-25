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
    public partial class FrmGirisPaneli : Form
    {
        public FrmGirisPaneli()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();
        Personel personel = new Personel();

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            var result = new List<Personel>(); //liste oluşturduk         

            SqlCommand cmd = new SqlCommand("select Personel_Adi,Personel_Sifre from Tbl_Personel", bgl.baglanti());
     
            SqlDataAdapter da = new SqlDataAdapter(cmd);            
            DataTable dt = new DataTable();
            da.Fill(dt);

            result = dt.AsEnumerable().Select(s => new Personel
            {
                Personel_Adi1 = s.Field<string>("Personel_Adi"),
                Personel_Sifre1 = s.Field<string>("Personel_Sifre")
            }).ToList();

            var user = result.FirstOrDefault(x => x.Personel_Adi1 == txtKullaniciAdi.Text && x.Personel_Sifre1 == txtKullaniciSifre.Text);
            if (user != null)
            {
                MessageBox.Show("Giriş başarılı Ana Sayfaya Hoş Geldiniz");
                FrmAnaForm fr = new FrmAnaForm();
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Geçersiz Giriş, lütfen kullanıcı adı ve şifreyi kontrol edin");
            }        

        }
    }
}
