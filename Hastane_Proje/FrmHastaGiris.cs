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

namespace Hastane_Proje
{
    public partial class FrmHastaGiris : Form
    {
        public FrmHastaGiris()
        {
            InitializeComponent();
        }
        //class dan sql bağlantısı alınıyor 
        sqlbaglantisi bag = new sqlbaglantisi();

        private void button1_Click(object sender, EventArgs e)
        {
            //sql comutlarını ve parametrelerini tanımlıyoruz 

            SqlCommand komut = new SqlCommand("Select * From Tbl_Hastalar Where HastaTc=@p1 and HastaSifre=@p2", bag.baglanti());
            komut.Parameters.AddWithValue("@p1", mskTC.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();

            //veritabanından okuduğu bilgiler textbox daki değerlerle aynıysa giriş yapıp Hasta Detay Formunu Açıyor

            if (dr.Read())
            {
                FrmHastaDetay frmHastaDetay = new FrmHastaDetay();
                //Burdaki Tc No Değerini Diğer Formdaki tc Değişkenine Atadık
                frmHastaDetay.tc = mskTC.Text;
                frmHastaDetay.Show();
                this.Hide();
                

            }
            //Eğer aynı değilse Hata Verip Bütün Yazılanları Temizliyor 

            else
            {
                MessageBox.Show("Hatalı Giriş Tekrar Deneyin", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mskTC.Clear();
                txtSifre.Clear();
            }
            //sql Bağlantısı kapatılıyor

            bag.baglanti().Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lnkKayitOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmHastaKayit frmKayit = new FrmHastaKayit();
            frmKayit.Show();

        }
    }
}
