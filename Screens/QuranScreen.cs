using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace NaeemAlEman2.Screens
{
    public partial class QuranScreen : Form
    {
        List<QuranVerse> verses;
        private Byte _SurahNum;

        // Default constructor
        public QuranScreen() { }

        // Constructor with Surah Number parameter
        public QuranScreen(Byte SurahNum)
        {
            InitializeComponent();
            _SurahNum = SurahNum;
        }

        // Class to represent a Quran verse
        public class QuranVerse
        {
            public int id { get; set; }
            public string type { get; set; }
            public string name { get; set; }
            public string ar { get; set; }
            public List<ZekrItem> array { get; set; }
        }

        // Class to represent a Zekr item
        public class ZekrItem
        {
            public int id { get; set; }
        }

        // Method to fetch Azkar from API
        public async Task<List<QuranVerse>> GetAzkarAsync(string apiUrl)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();

                        if (!string.IsNullOrEmpty(jsonResponse))
                        {
                            verses = JsonConvert.DeserializeObject<List<QuranVerse>>(jsonResponse);
                        }
                        else
                        {
                            MessageBox.Show("Received empty response from server.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Failed to retrieve data. Status code: " + response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while retrieving data: " + ex.Message);
            }
            return verses;
        }

        // Method to fill Surah content in the UI
        private void FillSurahContent()
        {
            if (verses == null || verses.Count == 0)
            {
                MessageBox.Show("No data available. Please load the data first.");
                return;
            }
            QuranVerse verse = verses[_SurahNum - 1];
            btnSurahName.Text = "سورة " + verse.name;
            lblSurahType.Text = verse.type;
            lblSurah.Text = verse.ar;
        }

        // Event handler for form load
        private async void QuranScreen_Load(object sender, EventArgs e)
        {
            // Display a loading indicator or waiting message
            lblSurah.Text = "جاري تحميل البيانات...";

            // Fetch data asynchronously
            await GetAzkarAsync("https://raw.githubusercontent.com/rn0x/Quran-Json/main/Quran.json");
            
            // Updated UI after loading data
            FillSurahContent();
        }
    }
}

