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
    public partial class FrmDoktorBilgiDuzenle : Form
    {
        public FrmDoktorBilgiDuzenle()
        {
            InitializeComponent();
        }

        sqlbaglantisi bag = new sqlbaglantisi();
        public string TCnumara;
        string id;

        private void FrmDoktorBilgiDuzenle_Load(object sender, EventArgs e)
        {
            
            mskTC.Text = TCnumara;

            //Doktor Bilgilerini Araçlara yazadırma

            SqlCommand cmd = new SqlCommand("Select * from Tbl_Doktorlar where DoktorTC=@p1",bag.baglanti());
            cmd.Parameters.AddWithValue("@p1",mskTC.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtAd.Text = dr[1].ToString();
                txtSoyad.Text = dr[2].ToString();
                cmbBrans.Text = dr[3].ToString();
                txtSifre.Text= dr[5].ToString();
                id= dr[0].ToString();
                
            }
            bag.baglanti().Close();
            
            

        }

        private void btnBilgiGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd2 = new SqlCommand("Update Tbl_Doktorlar set DoktorAd=@p1,DoktorSoyad=@p2,DoktorBrans=@p3,DoktorSifre=@p4 where DoktorTC=@p5",bag.baglanti());
            cmd2.Parameters.AddWithValue("@p1",txtAd.Text);
            cmd2.Parameters.AddWithValue("@p2",txtSoyad.Text);
            cmd2.Parameters.AddWithValue("@p3", cmbBrans.Text);
            cmd2.Parameters.AddWithValue("@p5", mskTC.Text);
            cmd2.Parameters.AddWithValue("@p4", txtSifre.Text);
            cmd2.ExecuteNonQuery();
            bag.baglanti().Close();
            MessageBox.Show("Doktor Bilgisi Başarıyla Güncellendi ","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }
    }
}
