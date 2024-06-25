namespace NaeemAlEman2.Screens
{
    partial class ListenQuranScreen
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
            this.cmbSurah = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSurah = new System.Windows.Forms.TrackBar();
            this.timerPlayback = new System.Windows.Forms.Timer(this.components);
            this.roundPanel1 = new NaeemAlEman2.Extensions.RoundPanel();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lblSurahTime = new System.Windows.Forms.Label();
            this.btnPlay = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tbSurah)).BeginInit();
            this.roundPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbSurah
            // 
            this.cmbSurah.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSurah.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSurah.FormattingEnabled = true;
            this.cmbSurah.Items.AddRange(new object[] {
            "1- الفاتحة",
            "2- البقرة\t",
            "3- آل عمران",
            "4- النساء\t",
            "5- المائدة\t",
            "6- الأنعام",
            "7- الأعراف\t",
            "8- الأنفال\t",
            "9- التوبة",
            "10- يونس\t",
            "11- هود\t",
            "12- يوسف",
            "13- الرعد\t",
            "14- إبراهيم\t",
            "15- الحجر",
            "16- النحل\t",
            "17- الإسراء\t",
            "18- الكهف",
            "19- مريم\t",
            "20- طه\t",
            "21- الأنبياء",
            "22- الحج\t",
            "23- المؤمنون\t",
            "24- النور",
            "25- الفرقان\t",
            "26- الشعراء\t",
            "27- النمل",
            "28- القصص\t",
            "29- العنكبوت\t",
            "30- الروم",
            "31- لقمان\t",
            "32- السجدة\t",
            "33- الأحزاب",
            "34- سبأ\t",
            "35- فاطر\t",
            "36- يس",
            "37- الصافات\t",
            "38- ص\t",
            "39- الزمر",
            "40- غافر\t",
            "41- فصلت\t",
            "42- الشورى",
            "43- الزخرف\t",
            "44- الدخان\t",
            "45- الجاثية",
            "46- الأحقاف\t",
            "47- محمد\t",
            "48- الفتح",
            "49- الحجرات\t",
            "50- ق\t",
            "51- الذاريات",
            "52- الطور\t",
            "53- النجم\t",
            "54- القمر",
            "55- الرحمن\t",
            "56- الواقعة\t",
            "57- الحديد",
            "58- المجادلة\t",
            "59- الحشر\t",
            "60- الممتحنة",
            "61- الصف\t",
            "62- الجمعة\t",
            "63- المنافقون",
            "64- التغابن\t",
            "65- الطلاق\t",
            "66- التحريم",
            "67- الملك\t",
            "68- القلم\t",
            "69- الحاقة",
            "70- المعارج\t",
            "71- نوح\t",
            "72- الجن",
            "73- المزمل\t",
            "74- المدثر\t",
            "75- القيامة",
            "76- الإنسان\t",
            "77- المرسلات\t",
            "78- النبأ",
            "79- النازعات\t",
            "80- عبس\t",
            "81- التكوير",
            "82- الإنفطار\t",
            "83- المطففين\t",
            "84- الانشقاق",
            "85- البروج\t",
            "86- الطارق\t",
            "87- الأعلى",
            "88- الغاشية\t",
            "89- الفجر\t",
            "90- البلد",
            "91- الشمس\t",
            "92- الليل\t",
            "93- الضحى",
            "94- الشرح\t",
            "95- التين\t",
            "96- العلق",
            "97- القدر\t",
            "98- البينة\t",
            "99- الزلزلة",
            "100- العاديات\t",
            "101- القارعة\t",
            "102- التكاثر",
            "103- العصر\t",
            "104- الهمزة\t",
            "105- الفيل",
            "106- قريش\t",
            "107- الماعون\t",
            "108- الكوثر",
            "109- الكافرون\t",
            "110- النصر\t",
            "111- المسد",
            "112- الإخلاص\t",
            "113- الفلق\t",
            "114- الناس"});
            this.cmbSurah.Location = new System.Drawing.Point(176, 85);
            this.cmbSurah.Name = "cmbSurah";
            this.cmbSurah.Size = new System.Drawing.Size(304, 33);
            this.cmbSurah.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(519, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = ":      اختر السورة";
            // 
            // tbSurah
            // 
            this.tbSurah.AutoSize = false;
            this.tbSurah.BackColor = System.Drawing.Color.White;
            this.tbSurah.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbSurah.LargeChange = 10;
            this.tbSurah.Location = new System.Drawing.Point(565, 108);
            this.tbSurah.Maximum = 100;
            this.tbSurah.Name = "tbSurah";
            this.tbSurah.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbSurah.Size = new System.Drawing.Size(27, 150);
            this.tbSurah.SmallChange = 10;
            this.tbSurah.TabIndex = 6;
            this.tbSurah.Value = 50;
            this.tbSurah.Visible = false;
            this.tbSurah.Scroll += new System.EventHandler(this.tbSurah_Scroll);
            // 
            // timerPlayback
            // 
            this.timerPlayback.Interval = 10;
            this.timerPlayback.Tick += new System.EventHandler(this.TimerPlayback_Tick);
            // 
            // roundPanel1
            // 
            this.roundPanel1.BackColor = System.Drawing.Color.White;
            this.roundPanel1.BackgroundColor = System.Drawing.Color.White;
            this.roundPanel1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.roundPanel1.BorderRadius = 30;
            this.roundPanel1.BorderSize = 0;
            this.roundPanel1.Controls.Add(this.trackBar1);
            this.roundPanel1.Controls.Add(this.button3);
            this.roundPanel1.Controls.Add(this.button2);
            this.roundPanel1.Controls.Add(this.lblSurahTime);
            this.roundPanel1.Controls.Add(this.btnPlay);
            this.roundPanel1.ForeColor = System.Drawing.Color.White;
            this.roundPanel1.Location = new System.Drawing.Point(121, 250);
            this.roundPanel1.Name = "roundPanel1";
            this.roundPanel1.Size = new System.Drawing.Size(552, 64);
            this.roundPanel1.TabIndex = 2;
            this.roundPanel1.TextColor = System.Drawing.Color.White;
            // 
            // trackBar1
            // 
            this.trackBar1.AutoSize = false;
            this.trackBar1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.trackBar1.LargeChange = 1;
            this.trackBar1.Location = new System.Drawing.Point(181, 22);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(200, 25);
            this.trackBar1.TabIndex = 5;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBarPosition_Scroll);
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::NaeemAlEman2.Properties.Resources.options;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(493, 18);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(30, 30);
            this.button3.TabIndex = 4;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::NaeemAlEman2.Properties.Resources.volume_black;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(441, 18);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(30, 30);
            this.button2.TabIndex = 3;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.MouseEnter += new System.EventHandler(this.button2_MouseEnter);
            this.button2.MouseLeave += new System.EventHandler(this.button2_MouseLeave);
            // 
            // lblSurahTime
            // 
            this.lblSurahTime.AutoSize = true;
            this.lblSurahTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSurahTime.ForeColor = System.Drawing.Color.Gray;
            this.lblSurahTime.Location = new System.Drawing.Point(93, 22);
            this.lblSurahTime.Name = "lblSurahTime";
            this.lblSurahTime.Size = new System.Drawing.Size(56, 25);
            this.lblSurahTime.TabIndex = 1;
            this.lblSurahTime.Text = "0:00 ";
            // 
            // btnPlay
            // 
            this.btnPlay.BackgroundImage = global::NaeemAlEman2.Properties.Resources.play_buttton;
            this.btnPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPlay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlay.FlatAppearance.BorderSize = 0;
            this.btnPlay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnPlay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlay.Location = new System.Drawing.Point(34, 18);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(30, 30);
            this.btnPlay.TabIndex = 0;
            this.btnPlay.Tag = "0";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // ListenQuranScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tbSurah);
            this.Controls.Add(this.roundPanel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbSurah);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ListenQuranScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listen Quran";
            this.Load += new System.EventHandler(this.ListenQuranScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbSurah)).EndInit();
            this.roundPanel1.ResumeLayout(false);
            this.roundPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbSurah;
        private System.Windows.Forms.Label label1;
        private Extensions.RoundPanel roundPanel1;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TrackBar tbSurah;
        private System.Windows.Forms.Label lblSurahTime;
        private System.Windows.Forms.Timer timerPlayback;
    }
}