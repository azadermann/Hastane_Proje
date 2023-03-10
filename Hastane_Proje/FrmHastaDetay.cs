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
    public partial class FrmHastaDetay : Form
    {
        public FrmHastaDetay()
        {
            InitializeComponent();
        }

        sqlbaglantisi bag = new sqlbaglantisi();

        //Diğer formdan tc nosunun Alıp Bu değişkene Aktardık
        public string tc;

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void FrmHastaDetay_Load(object sender, EventArgs e)
        {
            //Veritabanından Ad Ve Soyadı Aldık lblAdSoyad'a Yazdırdık
            lblTC.Text = tc;
            SqlCommand komut = new SqlCommand("Select HastaAd,HastaSoyad From Tbl_Hastalar where HastaTc=@p1", bag.baglanti());
            komut.Parameters.AddWithValue("@p1", lblTC.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblAdSoyad.Text = dr[0] + " " + dr[1];
            }
            bag.baglanti().Close();

            //Randevu Geçmişini dataGridView1'e Aktardık
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Randevular where HastaTC=" + tc, bag.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            //Branşları ComboBox'a Aktardık

            SqlCommand komut2 = new SqlCommand("Select BransAd from Tbl_Brans", bag.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                cmbBrans.Items.Add(dr2[0]);
            }
            bag.baglanti().Close();


        }

        private void cmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Doktorları ComboBox'a Aktardık

            cmbDoktor.Items.Clear();

            SqlCommand komut3 = new SqlCommand("Select DoktorAd,DoktorSoyad from Tbl_Doktorlar where DoktorBrans=@p1", bag.baglanti());
            komut3.Parameters.AddWithValue("@p1", cmbBrans.Text);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                cmbDoktor.Items.Add(dr3[0] + " " + dr3[1]);
            }
            bag.baglanti().Close();
        }

        private void cmbDoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Randevular where RandevuBrans='" + cmbBrans.Text + "'" + " and RandevuDoktor='" + cmbDoktor.Text + "'and RandevuDurum=0", bag.baglanti());
            da.Fill(dt);
            dataGridView2.DataSource = dt;

        }

        private void lnkBilgiDuzenle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmBilgiDüzenle frmBilgiDuzenle = new FrmBilgiDüzenle();
            frmBilgiDuzenle.TcNo = lblTC.Text;
            frmBilgiDuzenle.Show();

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;

            txtBransid.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
        }

        private void btnRandevuAl_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(txtBransid.Text))
            {
                MessageBox.Show("Lütfen Randevu Seçiniz ", "Uyarı !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SqlCommand komutRandevuAl = new SqlCommand("Update Tbl_Randevular Set RandevuDurum=1,HastaTC=@p1,HastaSikayet=@p2 where Randevuid=@p3", bag.baglanti());
                komutRandevuAl.Parameters.AddWithValue("@p1", lblTC.Text);
                komutRandevuAl.Parameters.AddWithValue("@p2", rchSikayet.Text);
                komutRandevuAl.Parameters.AddWithValue("@p3", txtBransid.Text);
                komutRandevuAl.ExecuteNonQuery();
                bag.baglanti().Close();
                MessageBox.Show("Randevu Başarıyla Alındı ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
    }
}
