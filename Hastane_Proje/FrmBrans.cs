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
    public partial class FrmBrans : Form
    {
        public FrmBrans()
        {
            InitializeComponent();
        }

        sqlbaglantisi bag = new sqlbaglantisi ();

        private void FrmBrans_Load(object sender, EventArgs e)
        {
            //Datagrid'e Doktoraları Aktarma

            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter("Select * from Tbl_Brans", bag.baglanti());
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
            bag.baglanti().Close();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            //Yeni Branş Ekleme

            SqlCommand komutEkle = new SqlCommand("insert into Tbl_Brans (BransAd) values (@b1)", bag.baglanti());
            komutEkle.Parameters.AddWithValue("@b1",txtBransAd.Text);
            komutEkle.ExecuteNonQuery();
            bag.baglanti().Close();
            MessageBox.Show(txtBransAd.Text+" "+"Branşı Başarıyla Ekelndi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtBransAd.Clear();
            txtBransid.Clear();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            //Branş Silme 

            SqlCommand komutSil = new SqlCommand("Delete from Tbl_Brans where Bransid=@i1", bag.baglanti());
            komutSil.Parameters.AddWithValue("@i1",txtBransid.Text);
            komutSil.ExecuteNonQuery();
            bag.baglanti().Close();
            MessageBox.Show(txtBransAd.Text + " " + "Branşı Başarıyla Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtBransid.Clear();
            txtBransid.Clear();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Verileri Araçlara aktarama (txtbox..vb)

            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            txtBransid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtBransAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            //Branş Güncelleme 

            SqlCommand komutguncelle = new SqlCommand("Update Tbl_Brans set BransAd=@ba1 where Bransid=@bi1", bag.baglanti());
            komutguncelle.Parameters.AddWithValue("@ba1",txtBransAd.Text);
            komutguncelle.Parameters.AddWithValue("@bi1",txtBransid.Text);
            komutguncelle.ExecuteNonQuery();
            bag.baglanti().Close();
            MessageBox.Show(txtBransAd.Text + " " + "Branşı Başarıyla Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtBransid.Clear();
            txtBransid.Clear();
        }
    }
}
