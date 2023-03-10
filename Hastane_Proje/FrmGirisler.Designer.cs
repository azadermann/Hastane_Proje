namespace Hastane_Proje
{
    partial class FrmGirisler
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGirisler));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDoktorGiris = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSekreterGiris = new System.Windows.Forms.Button();
            this.btnHastaGiris = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(74, 169);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "HASTA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(257, 168);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "DOKTOR";
            // 
            // btnDoktorGiris
            // 
            this.btnDoktorGiris.BackgroundImage = global::Hastane_Proje.Properties.Resources.doctor;
            this.btnDoktorGiris.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDoktorGiris.Location = new System.Drawing.Point(251, 73);
            this.btnDoktorGiris.Margin = new System.Windows.Forms.Padding(2);
            this.btnDoktorGiris.Name = "btnDoktorGiris";
            this.btnDoktorGiris.Size = new System.Drawing.Size(98, 76);
            this.btnDoktorGiris.TabIndex = 2;
            this.btnDoktorGiris.UseVisualStyleBackColor = true;
            this.btnDoktorGiris.Click += new System.EventHandler(this.btnDoktorGiris_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(432, 168);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "SEKRETER";
            // 
            // btnSekreterGiris
            // 
            this.btnSekreterGiris.BackgroundImage = global::Hastane_Proje.Properties.Resources.skr_removebg_preview;
            this.btnSekreterGiris.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSekreterGiris.Location = new System.Drawing.Point(434, 73);
            this.btnSekreterGiris.Margin = new System.Windows.Forms.Padding(2);
            this.btnSekreterGiris.Name = "btnSekreterGiris";
            this.btnSekreterGiris.Size = new System.Drawing.Size(98, 76);
            this.btnSekreterGiris.TabIndex = 4;
            this.btnSekreterGiris.UseVisualStyleBackColor = true;
            this.btnSekreterGiris.Click += new System.EventHandler(this.btnSekreterGiris_Click);
            // 
            // btnHastaGiris
            // 
            this.btnHastaGiris.BackgroundImage = global::Hastane_Proje.Properties.Resources.hastalar;
            this.btnHastaGiris.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHastaGiris.Location = new System.Drawing.Point(62, 73);
            this.btnHastaGiris.Margin = new System.Windows.Forms.Padding(2);
            this.btnHastaGiris.Name = "btnHastaGiris";
            this.btnHastaGiris.Size = new System.Drawing.Size(98, 76);
            this.btnHastaGiris.TabIndex = 0;
            this.btnHastaGiris.UseVisualStyleBackColor = true;
            this.btnHastaGiris.Click += new System.EventHandler(this.btnHastaGiris_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(113, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(389, 28);
            this.label4.TabIndex = 6;
            this.label4.Text = "Æ Özel Hastanesi Giriş Paneli";
            // 
            // FrmGirisler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(182)))), ((int)(((byte)(202)))));
            this.BackgroundImage = global::Hastane_Proje.Properties.Resources.output_onlinepngtools;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(586, 262);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSekreterGiris);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDoktorGiris);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnHastaGiris);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "FrmGirisler";
            this.Text = "Æ Giriş Sistemi";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHastaGiris;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDoktorGiris;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSekreterGiris;
        private System.Windows.Forms.Label label4;
    }
}

