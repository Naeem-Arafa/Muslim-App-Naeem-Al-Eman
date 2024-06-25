using NaeemAlEman2.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static NaeemAlEman2.Screens.ListenQuranScreen;

namespace NaeemAlEman2.Screens
{
    public partial class AdhkarScreen : Form
    {
        // Define properties to store Azkar and quick Azkar
        private List<Zekr> _Azkar;
        private Dictionary<string, List<Zekr>> _QuiqAzkar;
        private Byte _ZekrID;

        // Default constructor
        public AdhkarScreen() { }

        // Constructor with Zekr ID parameter
        public AdhkarScreen(Byte ZekrID)
        {
            _ZekrID = ZekrID;
            InitializeComponent();
        }

        // Class to represent a Zekr
        public class Zekr
        {
            public int id { get; set; }
            public string category { get; set; }
            public List<ZekrItem> array { get; set; }
            public string content { get; set; }
            public int count { get; set; }
        }

        // Class to represent a Zekr item
        public class ZekrItem
        {
            public string text { get; set; }
            public int count { get; set; }
        }

        // Method to fetch Azkar from API
        public async Task<List<Zekr>> GetAzkarAsync(string apiUrl)
        {
            List<Zekr> Azkar = new List<Zekr>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    // Deserialize the JSON response
                    Azkar = JsonConvert.DeserializeObject<List<Zekr>>(jsonResponse);
                }
                else
                {
                    MessageBox.Show("Failed to retrieve data. Status code: " + response.StatusCode);
                }
            }

            return Azkar;
        }

        // Method to fetch quick Azkar from API
        private async Task<Dictionary<string, List<Zekr>>> _GetQuiqAzkarAsync(string apiUrl)
        {
            Dictionary<string, List<Zekr>> adhkar = new Dictionary<string, List<Zekr>>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    // Deserialize the JSON response
                    adhkar = JsonConvert.DeserializeObject<Dictionary<string, List<Zekr>>>(jsonResponse);
                }
                else
                {
                    MessageBox.Show($"Failed to retrieve data. Status code: {response.StatusCode}");
                }
            }

            return adhkar;
        }

        // Method to create controls for displaying Azkar
        private void MakeControlsForAZScreen(ref int yPos, string Txt, int Cnt)
        {
            // Create and configure the round panel
            RoundPanel roundPanel = new RoundPanel();
            roundPanel.AutoSize = true;
            roundPanel.Location = new System.Drawing.Point(30, yPos);
            roundPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            roundPanel.ForeColor = System.Drawing.Color.White;
            roundPanel.BorderRadius = 15;
            roundPanel.TabIndex = 0;
            roundPanel.MinimumSize = new Size(700, 120); // example height

            // Create and configure the label for zekr content.
            Label ZekrInfoLabel = new Label();
            ZekrInfoLabel.AutoSize = true;
            ZekrInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ZekrInfoLabel.Location = new System.Drawing.Point(10, 10);
            ZekrInfoLabel.MaximumSize = new System.Drawing.Size(700, 0);
            ZekrInfoLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            ZekrInfoLabel.Text = Txt;

            // Add label to the round panel
            roundPanel.Controls.Add(ZekrInfoLabel);
            this.Controls.Add(roundPanel);
            roundPanel.PerformLayout();
            int panel2YPos = ZekrInfoLabel.Height + 20;

            // Create and configure the copy button
            Button btnCopy = new Button();
            btnCopy.BackgroundImage = global::NaeemAlEman2.Properties.Resources.copy;
            btnCopy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            btnCopy.Location = new System.Drawing.Point(170, 8);
            btnCopy.Size = new System.Drawing.Size(35, 35);
            btnCopy.UseVisualStyleBackColor = true;

            // Add the click event handler for btnCopy
            btnCopy.Click += (sender, e) =>
            {
                Clipboard.SetText(ZekrInfoLabel.Text);
                MessageBox.Show("Text copied to clipboard!");
            };

            // Create and configure the count button
            RoundButton btnCount = new RoundButton();
            btnCount.Location = new System.Drawing.Point(400, 8);
            btnCount.Text = "التكرار: " + Cnt;
            btnCount.BorderRadius = 15;
            btnCount.Size = new System.Drawing.Size(110, 35);
            btnCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnCount.ForeColor = System.Drawing.Color.Red;
            btnCount.Enabled = false;
            btnCount.UseVisualStyleBackColor = true;

            // Create and configure the second round panel for copy and count buttons
            RoundPanel roundPanel2 = new RoundPanel();
            roundPanel2.Location = new System.Drawing.Point(10, panel2YPos);
            roundPanel2.Size = new System.Drawing.Size(100, 91);
            roundPanel2.Width = 690;
            roundPanel2.Height = 50;
            roundPanel2.BackColor = Color.FromArgb(44, 47, 51);
            roundPanel2.BorderRadius = 15;

            // Add controls to the second round panel
            roundPanel.PerformLayout();
            roundPanel.Controls.Add(roundPanel2);
            roundPanel2.Controls.Add(btnCopy);
            roundPanel2.Controls.Add(btnCount);
            yPos += roundPanel.Height + 30;
            this.PerformLayout();
        }

        // Method to fill the selected Zekr
        private void FillSelectedZekr()
        {
            var selectedZekr = _Azkar.FirstOrDefault(r => r.id == _ZekrID);
            
            lblTitle.Text = selectedZekr.category;

            int yPos = 120;

            if (selectedZekr != null)
            {
                foreach (var item in selectedZekr.array)
                {
                    MakeControlsForAZScreen(ref yPos, item.text, item.count);
                }
            }
        }

        // Method to fill the quick Zekr
        private void FillQuiqZekr()
        {
            var selectedZekr = _QuiqAzkar.ElementAt(_ZekrID - 231);
            int yPos = 120;
            lblTitle.Text = selectedZekr.Key;
            foreach (var zekr in selectedZekr.Value)
            {
                MakeControlsForAZScreen(ref yPos, zekr.content, zekr.count);
            }
        }

        // Method to check if the Zekr is from Hesn El Muslim
        private bool IsHesnElMuslim()
        {
            return (_ZekrID < 230);
        }

        // Event handler for form load
        private async void AdhkarScreen_Load(object sender, EventArgs e)
        {
            lblTitle.Text = "جاري تحميل البيانات...";
            if (IsHesnElMuslim())
            {
                string apiUrl = "https://raw.githubusercontent.com/rn0x/Adhkar-json/main/adhkar.json";
                _Azkar = await GetAzkarAsync(apiUrl);
                FillSelectedZekr();
            }
            else
            {
                string apiUrl = "https://raw.githubusercontent.com/nawafalqari/ayah/main/src/data/adkar.json";
                _QuiqAzkar = await _GetQuiqAzkarAsync(apiUrl);
                FillQuiqZekr();
            }
            
        }

        
    }
}
