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
    public partial class FrmDuyurular : Form
    {
        public FrmDuyurular()
        {
            InitializeComponent();
        }


         sqlbaglantisi bag = new sqlbaglantisi();

        private void FrmDuyurular_Load(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter("Select Duyuru from Tbl_Duyurular", bag.baglanti());
            ad.Fill(dt);
            dataGridView1.DataSource = dt;

        }
    }
}
