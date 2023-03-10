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

namespace Hastane_Proje
{
    public partial class FrmBilgiDüzenle : Form
    {
        public FrmBilgiDüzenle()
        {
            InitializeComponent();
        }

        public string TcNo;

        sqlbaglantisi bag = new sqlbaglantisi();

        private void FrmBilgiDüzenle_Load(object sender, EventArgs e)
        {
            mskTC.Text = TcNo;
            SqlCommand komut = new SqlCommand("Select * from Tbl_Hastalar where HastaTC=@p1", bag.baglanti());
            komut.Parameters.AddWithValue("@p1", TcNo);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtAd.Text = dr[1].ToString();
                txtSoyad.Text = dr[2].ToString();
                mskTelefon.Text = dr[4].ToString();
                txtSifre.Text = dr[5].ToString();
                cmbCinsiyet.Text = dr[6].ToString();

            }
            bag.baglanti().Close();


        }

        private void btnBilgiGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komutGuncelle = new SqlCommand("update Tbl_Hastalar set HastaAd=@p1,HastaSoyad=@p2,HastaTelefon=@p3,HastaSifre=@p4,HastaCinsiyet=@p5 where HastaTC=@p6",bag.baglanti());
            komutGuncelle.Parameters.AddWithValue("@p1",txtAd.Text);
            komutGuncelle.Parameters.AddWithValue("@p2",txtSoyad.Text);
            komutGuncelle.Parameters.AddWithValue("@p3", mskTelefon.Text);
            komutGuncelle.Parameters.AddWithValue("@p4",txtSifre.Text);
            komutGuncelle.Parameters.AddWithValue("@p5",cmbCinsiyet.Text);
            komutGuncelle.Parameters.AddWithValue("@p6",mskTC.Text);
            komutGuncelle.ExecuteNonQuery();
            bag.baglanti().Close();
            MessageBox.Show("Bilgileriniz Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
