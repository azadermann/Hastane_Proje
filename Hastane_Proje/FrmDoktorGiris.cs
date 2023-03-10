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
    public partial class FrmDoktorGiris : Form
    {
        public FrmDoktorGiris()
        {
            InitializeComponent();
        }

        sqlbaglantisi bag = new sqlbaglantisi();

        private void btnGiris_Click(object sender, EventArgs e)
        {
            SqlCommand komutGiris = new SqlCommand("Select * from  Tbl_Doktorlar where DoktorTC=@p1 and DoktorSifre=@p2", bag.baglanti());
            komutGiris.Parameters.AddWithValue("@p1",mskTC.Text);
            komutGiris.Parameters.AddWithValue("@p2",txtSifre.Text);
            SqlDataReader dr = komutGiris.ExecuteReader();
            if (dr.Read())
            {
                FrmDoktorDetay frmDoktorDetay = new FrmDoktorDetay();
                frmDoktorDetay.doktorTc = mskTC.Text;
                frmDoktorDetay.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş Tekrar Deneyin","Hata",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                mskTC.Clear();
                txtSifre.Clear();
            }
            bag.baglanti().Close();
        }
    }
}
