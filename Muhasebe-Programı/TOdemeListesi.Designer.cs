namespace Muhasebe_Programı
{
    partial class TOdemeListesi
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
            this.lblFirmaAdi = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblToplam = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.BtnOdeme = new System.Windows.Forms.Button();
            this.dtlist = new System.Windows.Forms.DataGridView();
            this.lblKalan = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtlist)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFirmaAdi
            // 
            this.lblFirmaAdi.AutoSize = true;
            this.lblFirmaAdi.Location = new System.Drawing.Point(170, 34);
            this.lblFirmaAdi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFirmaAdi.Name = "lblFirmaAdi";
            this.lblFirmaAdi.Size = new System.Drawing.Size(0, 16);
            this.lblFirmaAdi.TabIndex = 13;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(1106, 28);
            this.lblID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(0, 16);
            this.lblID.TabIndex = 12;
            // 
            // lblToplam
            // 
            this.lblToplam.AutoSize = true;
            this.lblToplam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblToplam.ForeColor = System.Drawing.Color.Maroon;
            this.lblToplam.Location = new System.Drawing.Point(610, 405);
            this.lblToplam.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblToplam.Name = "lblToplam";
            this.lblToplam.Size = new System.Drawing.Size(0, 20);
            this.lblToplam.TabIndex = 11;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(178, 17);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(505, 24);
            this.comboBox1.TabIndex = 10;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // BtnOdeme
            // 
            this.BtnOdeme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BtnOdeme.Location = new System.Drawing.Point(58, 405);
            this.BtnOdeme.Margin = new System.Windows.Forms.Padding(4);
            this.BtnOdeme.Name = "BtnOdeme";
            this.BtnOdeme.Size = new System.Drawing.Size(184, 48);
            this.BtnOdeme.TabIndex = 9;
            this.BtnOdeme.Text = "Ödeme Kaydet";
            this.BtnOdeme.UseVisualStyleBackColor = false;
            this.BtnOdeme.Click += new System.EventHandler(this.BtnOdeme_Click);
            // 
            // dtlist
            // 
            this.dtlist.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtlist.BackgroundColor = System.Drawing.Color.White;
            this.dtlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtlist.Location = new System.Drawing.Point(21, 58);
            this.dtlist.Margin = new System.Windows.Forms.Padding(4);
            this.dtlist.Name = "dtlist";
            this.dtlist.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtlist.Size = new System.Drawing.Size(848, 327);
            this.dtlist.TabIndex = 8;
            // 
            // lblKalan
            // 
            this.lblKalan.AutoSize = true;
            this.lblKalan.Location = new System.Drawing.Point(944, 406);
            this.lblKalan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblKalan.Name = "lblKalan";
            this.lblKalan.Size = new System.Drawing.Size(0, 16);
            this.lblKalan.TabIndex = 7;
            // 
            // TOdemeListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(881, 480);
            this.Controls.Add(this.lblFirmaAdi);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.lblToplam);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.BtnOdeme);
            this.Controls.Add(this.dtlist);
            this.Controls.Add(this.lblKalan);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TOdemeListesi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TOdemeListesi";
            this.Load += new System.EventHandler(this.TOdemeListesi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtlist)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblFirmaAdi;
        private System.Windows.Forms.Label lblID;
        public System.Windows.Forms.Label lblToplam;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button BtnOdeme;
        private System.Windows.Forms.DataGridView dtlist;
        public System.Windows.Forms.Label lblKalan;
    }
}