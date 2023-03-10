using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hastane_Proje
{
    public partial class FrmGirisler : Form
    {
        public FrmGirisler()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnHastaGiris_Click(object sender, EventArgs e)
        {
            FrmHastaGiris frhasta = new FrmHastaGiris();
            frhasta.Show();
            this.Hide();

        }

        private void btnDoktorGiris_Click(object sender, EventArgs e)
        {
            FrmDoktorGiris frmDoktor = new FrmDoktorGiris();
            frmDoktor.Show();
            this.Hide();

        }

        private void btnSekreterGiris_Click(object sender, EventArgs e)
        {
            FrmsekreterGiris frmSekreter = new FrmsekreterGiris();
            frmSekreter.Show();
            this.Hide();
        }
    }
}
