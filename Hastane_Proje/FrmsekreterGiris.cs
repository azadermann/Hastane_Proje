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
    public partial class FrmsekreterGiris : Form
    {
        public FrmsekreterGiris()
        {
            InitializeComponent();
        }

        sqlbaglantisi bag = new sqlbaglantisi();

        private void btnGiris_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select SekreterTC,SekreterSifre from Tbl_Sekreter where SekreterTC=@p1 and SekreterSifre=@p2", bag.baglanti()); ;
            komut.Parameters.AddWithValue("@p1",mskTC.Text);
            komut.Parameters.AddWithValue("@p2",txtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                
                FrmSekreterDetay frmSekreterDetay = new FrmSekreterDetay();
                frmSekreterDetay.SekreterTc = mskTC.Text;
                frmSekreterDetay.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş Lütfen Tekrar Deneyin ","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Error);
                mskTC.Clear();
                txtSifre.Clear();
            }
            bag.baglanti().Close();
        }
    }
}
