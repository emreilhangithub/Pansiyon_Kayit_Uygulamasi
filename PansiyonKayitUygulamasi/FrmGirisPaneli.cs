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
        Kullanici kullanici = new Kullanici();

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            var result = new List<Kullanici>(); //liste oluşturduk         

            SqlCommand cmd = new SqlCommand("select Kullanici_Adi,Kullanici_Sifre from Tbl_Kullanicilar", bgl.baglanti());
     
            SqlDataAdapter da = new SqlDataAdapter(cmd);            
            DataTable dt = new DataTable();
            da.Fill(dt);

            result = dt.AsEnumerable().Select(s => new Kullanici
            {
                Kullanici_Adi1 = s.Field<string>("Kullanici_Adi"),
                Kullanici_Sifre1 = s.Field<string>("Kullanici_Sifre")
            }).ToList();

            var user = result.FirstOrDefault(x => x.Kullanici_Adi1 == txtKullaniciAdi.Text && x.Kullanici_Sifre1 == txtKullaniciSifre.Text);
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
