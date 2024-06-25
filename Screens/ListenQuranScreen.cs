using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using NAudio.Wave;
using System.Drawing.Printing;
using NaeemAlEman2.Properties;
using static NaeemAlEman2.Screens.ListenQuranScreen;


namespace NaeemAlEman2.Screens
{
    public partial class ListenQuranScreen : Form
    {
        private List<Reciter> reciters;
        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;
        private short _ReciterID;

        // Default constructor
        public ListenQuranScreen() { }

        // Constructor with Reciter ID parameter
        public ListenQuranScreen(short ReciterID)
        {
            _ReciterID = ReciterID;
            InitializeComponent();
            this.FormClosing += ListenQuranScreen_FormClosing;
        }

        // Class to represent a Reciter
        public class Reciter
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Server { get; set; }
            public string Rewaya { get; set; }
            public string Count { get; set; }
            public string Letter { get; set; }
            public string Suras { get; set; }
        }

        // Class to represent the API response
        public class RecitersApiResponse
        {
            public List<Reciter> Reciters { get; set; }
        }

        // Method to fetch Reciters from API
        public async Task<List<Reciter>> GetRecitersAsync(string apiUrl)
        {
            List<Reciter> reciters = new List<Reciter>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    RecitersApiResponse apiResponse = JsonConvert.DeserializeObject<RecitersApiResponse>(jsonResponse);

                    reciters = apiResponse.Reciters;
                }
                else
                {
                    MessageBox.Show("Failed to retrieve data. Status code: " + response.StatusCode);
                }
            }

            return reciters;
        }

        // Method to play the selected Surah
        private void PlaySelectedSurah()
        {
            string SurahNumber = ((byte)cmbSurah.SelectedIndex + 1).ToString("000");
            var selectedReciter = reciters.FirstOrDefault(r => Convert.ToInt16(r.Id) == _ReciterID);

            if (selectedReciter != null)
            {
                // Build audio URL using the Reciter's server and Surah number
                string audioUrl = $"{selectedReciter.Server}/{SurahNumber}.mp3";
                // Play the audio file
                PlayAudio(audioUrl);
            }
        }

        // Method to play the audio from a given URL
        private void PlayAudio(string audioUrl)
        {
            if (outputDevice != null)
            {
                outputDevice.Stop(); // Stop any previous playback
                outputDevice.Dispose();
            }
            if (audioFile != null)
                audioFile.Dispose();

            audioFile = new AudioFileReader(audioUrl);
            outputDevice = new WaveOutEvent();
            outputDevice.Init(audioFile);
            outputDevice.Play();

            timerPlayback.Start();
            trackBar1.Maximum = (int)audioFile.TotalTime.TotalSeconds;
        }

        // Event handler for form closing
        private void ListenQuranScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (outputDevice != null)
            {
                outputDevice.Stop();
                outputDevice.Dispose();
            }

            if (audioFile != null)
            {
                audioFile.Dispose();
            }
            timerPlayback.Stop();
        }

        // Event handler for mouse entering the sound button area
        private void button2_MouseEnter(object sender, EventArgs e)
        {
            tbSurah.Visible = true;
        }

        // Event handler for mouse leaving the sound button area
        private void button2_MouseLeave(object sender, EventArgs e)
        {
            // Start the project if the mouse is off the button and track bar
            Timer timer = new Timer
            {
                Interval = 100
            };
            timer.Tick += (s, args) =>
            {
                Point mousePosition = this.PointToClient(MousePosition);
                if (!tbSurah.ClientRectangle.Contains(tbSurah.PointToClient(MousePosition)) &&
                    !button2.ClientRectangle.Contains(button2.PointToClient(MousePosition)))
                {
                    tbSurah.Visible = false;
                    timer.Stop();
                }
            };
            timer.Start();
        }

        // Event handler for play button click
        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt16(btnPlay.Tag) == 0)
            {
                if (cmbSurah.SelectedItem != null)
                {
                    btnPlay.BackgroundImage = Resources.pause;
                    PlaySelectedSurah();
                    btnPlay.Tag = 1;
                }               
            }
            
            else if (Convert.ToInt16(btnPlay.Tag) == 1)
            {
                
                if (outputDevice != null && outputDevice.PlaybackState == PlaybackState.Playing)
                {
                    btnPlay.Tag = 2;
                    btnPlay.BackgroundImage = Resources.play_buttton;
                    outputDevice.Pause();
                }
            }
            else
            {
                btnPlay.Tag = 1;
                btnPlay.BackgroundImage = Resources.pause;
                outputDevice.Play();
            }

        }

        // Event handler for form load
        private async void ListenQuranScreen_Load(object sender, EventArgs e)
        {
            string apiUrl = "https://www.mp3quran.net/api/_arabic.json";
            // Initialize the data here
            reciters = await GetRecitersAsync(apiUrl);
        }

        // Event handler for trackbar scroll
        private void tbSurah_Scroll(object sender, EventArgs e)
        {
            if (outputDevice != null)
            {
                outputDevice.Volume = tbSurah.Value / 100f;
            }
        }

        // Event handler for playback timer tick
        private void TimerPlayback_Tick(object sender, EventArgs e)
        {
            if (audioFile != null)
            {
                TimeSpan currentTime = audioFile.CurrentTime;
                lblSurahTime.Text = currentTime.ToString(@"mm\:ss"); // Format the time as mm:ss

                // Update the track bar position without triggering the Scroll event
                if (trackBar1.Value != (int)currentTime.TotalSeconds)
                {
                    trackBar1.Value = (int)currentTime.TotalSeconds;
                }
            }
        }

        // Event handler for trackbar position scroll
        private void trackBarPosition_Scroll(object sender, EventArgs e)
        {
            if (audioFile != null)
            {
                audioFile.CurrentTime = TimeSpan.FromSeconds(trackBar1.Value);
            }
        }

    }
}
