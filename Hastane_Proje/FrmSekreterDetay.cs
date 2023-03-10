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
    public partial class FrmSekreterDetay : Form
    {
        public FrmSekreterDetay()
        {
            InitializeComponent();
        }

        public string SekreterTc;

        sqlbaglantisi bag = new sqlbaglantisi();
        private void FrmSekreterDetay_Load(object sender, EventArgs e)
        {
            lblTc.Text= SekreterTc;

            //Ad Soyad Yazdırma
            SqlCommand komut = new SqlCommand("Select SekreterAdSoyad from Tbl_Sekreter where SekreterTC=@p1", bag.baglanti());
            komut.Parameters.AddWithValue("@p1",lblTc.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblAdSoyad.Text = dr[0].ToString();
            }
            bag.baglanti().Close();

            //Branşları Datagirde aktarma

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Brans ",bag.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            //Doktorları Datagirde Aktarma

            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select * From Tbl_Doktorlar",bag.baglanti());
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;

            //Braşları Comboboxa aktarma

            SqlCommand komutBrans = new SqlCommand("Select * from Tbl_Brans", bag.baglanti());
            SqlDataReader  drBrans= komutBrans.ExecuteReader();
            while (drBrans.Read())
            {
                cmbBrans.Items.Add(drBrans[1].ToString());
            }

            

        }

        private void btnRandevuOlustur_Click(object sender, EventArgs e)
        {
            //Randevu Oluşturma

            SqlCommand komutKaydet = new SqlCommand("insert into Tbl_Randevular (RandevuTarih,RandevuSaat,RandevuBrans,RandevuDoktor) values (@r1,@r2,@r3,@r4)", bag.baglanti());
            komutKaydet.Parameters.AddWithValue("@r1",mskTarih.Text);
            komutKaydet.Parameters.AddWithValue("@r2",mskSaat.Text);
            komutKaydet.Parameters.AddWithValue("@r3",cmbBrans.Text);
            komutKaydet.Parameters.AddWithValue("@r4",cmbDoktor.Text);
            komutKaydet.ExecuteNonQuery();
            bag.baglanti().Close();
            MessageBox.Show("Randevu Başarıyla Oluşturuldu ","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void cmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Branşlara Göre Doktorları Comboboxa Aktarma

            cmbDoktor.Items.Clear();

            SqlCommand komutDoktor = new SqlCommand("Select DoktorAd,DoktorSoyad From Tbl_Doktorlar where DoktorBrans=@p1", bag.baglanti());
            komutDoktor.Parameters.AddWithValue("@p1",cmbBrans.Text);
            SqlDataReader drDoktor= komutDoktor.ExecuteReader();
            while (drDoktor.Read())
            {
                cmbDoktor.Items.Add(drDoktor[0]+ " " + drDoktor[1]);
            }
            bag.baglanti().Close();
        }

        private void btnDuyuruolustur_Click(object sender, EventArgs e)
        {
            //Duyuruları Ekleme

            SqlCommand komutDuyuru = new SqlCommand("insert into Tbl_Duyurular (Duyuru) values (@d1)",bag.baglanti());
            komutDuyuru.Parameters.AddWithValue("@d1",rchDuyuru.Text);
            komutDuyuru.ExecuteNonQuery();
            bag.baglanti().Close();
            MessageBox.Show("Duyuru Oluşturuldu","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        
        }

        private void btnDoktorPanel_Click(object sender, EventArgs e)
        {
            FrmDoktorPaneli fdp = new FrmDoktorPaneli();
            fdp.Show();
        }

        private void btnBransPanel_Click(object sender, EventArgs e)
        {
            FrmBrans fbp = new FrmBrans();
            fbp.Show();
        }

        private void btnListe_Click(object sender, EventArgs e)
        {
            FrmRandevuListesi frdl = new FrmRandevuListesi();
            frdl.Show();
        }

        private void btnDuyurular_Click(object sender, EventArgs e)
        {
            FrmDuyurular frmDuyurular = new FrmDuyurular();
            frmDuyurular.Show();
        }
    }
}
