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
    public partial class FrmDoktorDetay : Form
    {
        public FrmDoktorDetay()
        {
            InitializeComponent();
        }
        public string doktorTc;

        sqlbaglantisi bag = new sqlbaglantisi();
        private void FrmDoktorDetay_Load(object sender, EventArgs e)
        {
            lblTC.Text = doktorTc;

            //datagrid Randevuları Aktarıyoruz

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Randevular", bag.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            //Doktor Ad soyad bilgisi

            SqlCommand cmd = new SqlCommand("Select DoktorAd,DoktorSoyad from Tbl_Doktorlar where DoktorTC=@p1", bag.baglanti());
            cmd.Parameters.AddWithValue("@p1", lblTC.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lblAdSoyad.Text = dr[0] + " " + dr[1];
            }
            bag.baglanti().Close();

            //Doktora ait Randevuları datagrid'e Aktarma 

            DataTable dt2 = new DataTable();
            SqlDataAdapter ad2 = new SqlDataAdapter("Select * from Tbl_Randevular where RandevuDoktor ='" + lblAdSoyad.Text + "'", bag.baglanti());
            ad2.Fill(dt2);
            dataGridView1.DataSource = dt2;




        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            FrmDoktorBilgiDuzenle frmDBD = new FrmDoktorBilgiDuzenle();
            frmDBD.TCnumara = doktorTc;
            frmDBD.Show();

        }

        private void btnDuyurular_Click(object sender, EventArgs e)
        {
            FrmDuyurular frmDuyurular = new FrmDuyurular();
            frmDuyurular.Show();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            rchSikayet.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();

        }
    }
}
