
namespace PansiyonKayitUygulamasi
{
    partial class FrmAnaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnYeniMusteri = new System.Windows.Forms.Button();
            this.btnOdalar = new System.Windows.Forms.Button();
            this.btnMusteriler = new System.Windows.Forms.Button();
            this.btnHakkimizda = new System.Windows.Forms.Button();
            this.btnCikis = new System.Windows.Forms.Button();
            this.btnMusteriCikis = new System.Windows.Forms.Button();
            this.lblTarih = new System.Windows.Forms.Label();
            this.lblSaat = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnAdminGiris = new System.Windows.Forms.Button();
            this.btnCikisYapmisMusteriler = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnYeniMusteri
            // 
            this.btnYeniMusteri.BackColor = System.Drawing.Color.Yellow;
            this.btnYeniMusteri.Location = new System.Drawing.Point(248, 120);
            this.btnYeniMusteri.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnYeniMusteri.Name = "btnYeniMusteri";
            this.btnYeniMusteri.Size = new System.Drawing.Size(144, 89);
            this.btnYeniMusteri.TabIndex = 1;
            this.btnYeniMusteri.Text = "Yeni Müşteri";
            this.btnYeniMusteri.UseVisualStyleBackColor = false;
            this.btnYeniMusteri.Click += new System.EventHandler(this.btnYeniMusteri_Click);
            // 
            // btnOdalar
            // 
            this.btnOdalar.BackColor = System.Drawing.Color.SlateBlue;
            this.btnOdalar.Location = new System.Drawing.Point(450, 120);
            this.btnOdalar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOdalar.Name = "btnOdalar";
            this.btnOdalar.Size = new System.Drawing.Size(144, 89);
            this.btnOdalar.TabIndex = 2;
            this.btnOdalar.Text = "Odalar";
            this.btnOdalar.UseVisualStyleBackColor = false;
            this.btnOdalar.Click += new System.EventHandler(this.btnOdalar_Click);
            // 
            // btnMusteriler
            // 
            this.btnMusteriler.BackColor = System.Drawing.Color.Orange;
            this.btnMusteriler.Location = new System.Drawing.Point(61, 251);
            this.btnMusteriler.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMusteriler.Name = "btnMusteriler";
            this.btnMusteriler.Size = new System.Drawing.Size(144, 89);
            this.btnMusteriler.TabIndex = 3;
            this.btnMusteriler.Text = "Müşteriler";
            this.btnMusteriler.UseVisualStyleBackColor = false;
            this.btnMusteriler.Click += new System.EventHandler(this.btnMusteriler_Click);
            // 
            // btnHakkimizda
            // 
            this.btnHakkimizda.BackColor = System.Drawing.Color.SlateGray;
            this.btnHakkimizda.Location = new System.Drawing.Point(450, 251);
            this.btnHakkimizda.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnHakkimizda.Name = "btnHakkimizda";
            this.btnHakkimizda.Size = new System.Drawing.Size(144, 89);
            this.btnHakkimizda.TabIndex = 8;
            this.btnHakkimizda.Text = "Hakkımızda";
            this.btnHakkimizda.UseVisualStyleBackColor = false;
            this.btnHakkimizda.Click += new System.EventHandler(this.btnHakkimizda_Click);
            // 
            // btnCikis
            // 
            this.btnCikis.BackColor = System.Drawing.Color.DarkTurquoise;
            this.btnCikis.Location = new System.Drawing.Point(635, 251);
            this.btnCikis.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(144, 89);
            this.btnCikis.TabIndex = 9;
            this.btnCikis.Text = "Çıkış";
            this.btnCikis.UseVisualStyleBackColor = false;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // btnMusteriCikis
            // 
            this.btnMusteriCikis.BackColor = System.Drawing.Color.OrangeRed;
            this.btnMusteriCikis.Location = new System.Drawing.Point(635, 120);
            this.btnMusteriCikis.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMusteriCikis.Name = "btnMusteriCikis";
            this.btnMusteriCikis.Size = new System.Drawing.Size(144, 89);
            this.btnMusteriCikis.TabIndex = 10;
            this.btnMusteriCikis.Text = "Müşteri Çıkış";
            this.btnMusteriCikis.UseVisualStyleBackColor = false;
            this.btnMusteriCikis.Click += new System.EventHandler(this.btnMusteriCikis_Click);
            // 
            // lblTarih
            // 
            this.lblTarih.AutoSize = true;
            this.lblTarih.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTarih.Location = new System.Drawing.Point(133, 33);
            this.lblTarih.Name = "lblTarih";
            this.lblTarih.Size = new System.Drawing.Size(74, 29);
            this.lblTarih.TabIndex = 11;
            this.lblTarih.Text = "Tarih";
            // 
            // lblSaat
            // 
            this.lblSaat.AutoSize = true;
            this.lblSaat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSaat.Location = new System.Drawing.Point(518, 33);
            this.lblSaat.Name = "lblSaat";
            this.lblSaat.Size = new System.Drawing.Size(65, 29);
            this.lblSaat.TabIndex = 12;
            this.lblSaat.Text = "Saat";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnAdminGiris
            // 
            this.btnAdminGiris.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAdminGiris.Location = new System.Drawing.Point(52, 120);
            this.btnAdminGiris.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdminGiris.Name = "btnAdminGiris";
            this.btnAdminGiris.Size = new System.Drawing.Size(144, 89);
            this.btnAdminGiris.TabIndex = 0;
            this.btnAdminGiris.Text = "Admin Giriş";
            this.btnAdminGiris.UseVisualStyleBackColor = false;
            this.btnAdminGiris.Click += new System.EventHandler(this.btnAdminGiris_Click);
            // 
            // btnCikisYapmisMusteriler
            // 
            this.btnCikisYapmisMusteriler.BackColor = System.Drawing.Color.LawnGreen;
            this.btnCikisYapmisMusteriler.Location = new System.Drawing.Point(248, 251);
            this.btnCikisYapmisMusteriler.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCikisYapmisMusteriler.Name = "btnCikisYapmisMusteriler";
            this.btnCikisYapmisMusteriler.Size = new System.Drawing.Size(144, 89);
            this.btnCikisYapmisMusteriler.TabIndex = 13;
            this.btnCikisYapmisMusteriler.Text = "Çıkış Yapmış Müşteriler";
            this.btnCikisYapmisMusteriler.UseVisualStyleBackColor = false;
            this.btnCikisYapmisMusteriler.Click += new System.EventHandler(this.btnCikisYapmisMusteriler_Click);
            // 
            // FrmAnaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(792, 356);
            this.Controls.Add(this.btnCikisYapmisMusteriler);
            this.Controls.Add(this.lblSaat);
            this.Controls.Add(this.lblTarih);
            this.Controls.Add(this.btnMusteriCikis);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.btnHakkimizda);
            this.Controls.Add(this.btnMusteriler);
            this.Controls.Add(this.btnOdalar);
            this.Controls.Add(this.btnYeniMusteri);
            this.Controls.Add(this.btnAdminGiris);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAnaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ana Sayfa";
            this.Load += new System.EventHandler(this.FrmAnaForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnYeniMusteri;
        private System.Windows.Forms.Button btnOdalar;
        private System.Windows.Forms.Button btnMusteriler;
        private System.Windows.Forms.Button btnHakkimizda;
        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.Button btnMusteriCikis;
        private System.Windows.Forms.Label lblTarih;
        private System.Windows.Forms.Label lblSaat;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnAdminGiris;
        private System.Windows.Forms.Button btnCikisYapmisMusteriler;
    }
}