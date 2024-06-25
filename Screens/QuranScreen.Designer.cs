namespace NaeemAlEman2.Screens
{
    partial class QuranScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuranScreen));
            this.btnSurahName = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSurah = new System.Windows.Forms.Label();
            this.lblSurahType = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSurahName
            // 
            this.btnSurahName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.btnSurahName.Enabled = false;
            this.btnSurahName.FlatAppearance.BorderSize = 0;
            this.btnSurahName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSurahName.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSurahName.ForeColor = System.Drawing.Color.White;
            this.btnSurahName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSurahName.Location = new System.Drawing.Point(296, 29);
            this.btnSurahName.Name = "btnSurahName";
            this.btnSurahName.Size = new System.Drawing.Size(401, 87);
            this.btnSurahName.TabIndex = 0;
            this.btnSurahName.Text = "سورة الفاتحة";
            this.btnSurahName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSurahName.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(332, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(331, 51);
            this.label2.TabIndex = 2;
            this.label2.Text = "بسم الله الرحمن الرحيم";
            // 
            // lblSurah
            // 
            this.lblSurah.AutoSize = true;
            this.lblSurah.BackColor = System.Drawing.Color.Transparent;
            this.lblSurah.Font = new System.Drawing.Font("Microsoft Tai Le", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSurah.ForeColor = System.Drawing.Color.White;
            this.lblSurah.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSurah.Location = new System.Drawing.Point(19, 236);
            this.lblSurah.MaximumSize = new System.Drawing.Size(990, 0);
            this.lblSurah.Name = "lblSurah";
            this.lblSurah.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblSurah.Size = new System.Drawing.Size(901, 114);
            this.lblSurah.TabIndex = 3;
            this.lblSurah.Text = resources.GetString("lblSurah.Text");
            this.lblSurah.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSurahType
            // 
            this.lblSurahType.AutoSize = true;
            this.lblSurahType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.lblSurahType.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSurahType.ForeColor = System.Drawing.Color.Gray;
            this.lblSurahType.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSurahType.Location = new System.Drawing.Point(379, 63);
            this.lblSurahType.Name = "lblSurahType";
            this.lblSurahType.Size = new System.Drawing.Size(46, 29);
            this.lblSurahType.TabIndex = 1;
            this.lblSurahType.Text = "مكية";
            // 
            // QuranScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1032, 603);
            this.Controls.Add(this.lblSurah);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblSurahType);
            this.Controls.Add(this.btnSurahName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "QuranScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quran";
            this.Load += new System.EventHandler(this.QuranScreen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSurahName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSurah;
        private System.Windows.Forms.Label lblSurahType;
    }
}