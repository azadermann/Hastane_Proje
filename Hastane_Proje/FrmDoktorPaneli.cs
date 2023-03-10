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
    public partial class FrmDoktorPaneli : Form
    {
        public FrmDoktorPaneli()
        {
            InitializeComponent();
        }

        sqlbaglantisi bag = new sqlbaglantisi();

        private void FrmDoktorPaneli_Load(object sender, EventArgs e)
        {
            //Datagird de Doktorların Listesini Aktarma
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select Doktorid,DoktorAd,DoktorSoyad,DoktorBrans,DoktorTC,DoktorSifre from Tbl_Doktorlar", bag.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bag.baglanti().Close();

            //Bransları combobox'a ekleme 

            SqlCommand komut = new SqlCommand("Select BransAd from Tbl_Brans", bag.baglanti());
            SqlDataReader rdr = komut.ExecuteReader();
            while (rdr.Read())
            {
                cmbBrans.Items.Add(rdr[0].ToString());
            }

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            //Doktor Ekleme

            SqlCommand komutEkle = new SqlCommand("insert into Tbl_Doktorlar (DoktorAd,DoktorSoyad,DoktorBrans,DoktorTC,DoktorSifre) values (@d1,@d2,@d3,@d4,@d5)", bag.baglanti());
            komutEkle.Parameters.AddWithValue("@d1", txtAd.Text);
            komutEkle.Parameters.AddWithValue("@d2", txtSoyad.Text);
            komutEkle.Parameters.AddWithValue("@d3", cmbBrans.Text);
            komutEkle.Parameters.AddWithValue("@d4", mskTC.Text);
            komutEkle.Parameters.AddWithValue("@d5", txtSifre.Text);
            komutEkle.ExecuteNonQuery();
            bag.baglanti().Close();
            MessageBox.Show("Yeni Doktor Başarıyla Eklendi ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Datagrid den seçilen alanı Araçlara aktarma ("TextBox,Combobox..Vb)

            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            txtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbBrans.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            mskTC.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtSifre.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();


        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            //Doktor silme

            SqlCommand komutSil = new SqlCommand("Delete from Tbl_Doktorlar where DoktorTC=@dt", bag.baglanti());
            komutSil.Parameters.AddWithValue("@dt", mskTC.Text);
            komutSil.ExecuteNonQuery();
            bag.baglanti().Close();
            MessageBox.Show("Kayıt Başarıyla Silindi ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            //Doktor Bilgisi Güncelleme

            SqlCommand komutGuncelle = new SqlCommand("Update Tbl_Doktorlar set DoktorAd=@d1,DoktorSoyad=@d2,DoktorBrans=@d3,DoktorSifre=@d5 where DoktorTC=@d4", bag.baglanti());
            komutGuncelle.Parameters.AddWithValue("@d1", txtAd.Text);
            komutGuncelle.Parameters.AddWithValue("@d2", txtSoyad.Text);
            komutGuncelle.Parameters.AddWithValue("@d3", cmbBrans.Text);
            komutGuncelle.Parameters.AddWithValue("@d4", mskTC.Text);
            komutGuncelle.Parameters.AddWithValue("@d5", txtSifre.Text);
            komutGuncelle.ExecuteNonQuery();
            bag.baglanti().Close();
            MessageBox.Show("Doktor Bilgisi Başarıyla Güncellendi ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
