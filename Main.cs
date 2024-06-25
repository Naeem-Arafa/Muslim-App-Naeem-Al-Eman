using NaeemAlEman2.Screens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static NaeemAlEman2.Screens.ListenQuranScreen;
using static NaeemAlEman2.Screens.AdhkarScreen;
using static NaeemAlEman2.Screens.QuranScreen;
using NaeemAlEman2.Extensions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Reflection;
using System.Globalization;
using Newtonsoft.Json;
using System.Net.Http;

namespace NaeemAlEman2
{
    public partial class Main : Form
    {
        List<Reciter> _reciters;
        List<Zekr> _Azkar;
        List<QuranVerse> _QuranSurah;
        string _ZekrNotify;

        public Main()
        {
            InitializeComponent();
            CreateButtonsToLQScreen();
            CreateButtonsToAZScreen();
            CreateButtonsToQRScreen();
        }


        /* METHODS FOR MAIN PANEL */


        // Bring the specified panel to the front
        private void BringToFront(Panel panel)
        {
            panel.BringToFront();
        }

        // Event handler for clicking the application button
        private void btnApp_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                Panel panelToBringToFront = btn.Tag as Panel;
                if (panelToBringToFront != null)
                {
                    BringToFront(panelToBringToFront);
                }
                else
                {
                    MessageBox.Show("Panel is not assigned to the button's Tag property.");
                }
            }
            else
            {
                MessageBox.Show("Sender is not a Button.");
            }
        }


        /* METHODS FOR QURAN PANEL */


        // fetches Quran Surah data asynchronously from the specified API URL
        public async Task SomeMethodAsyncToQRScreen()
        {
            QuranScreen quranScreen = new QuranScreen();
            string apiUrl = "https://raw.githubusercontent.com/rn0x/Quran-Json/main/Quran.json";
            _QuranSurah = await quranScreen.GetAzkarAsync(apiUrl);
        }

        // creates buttons dynamically for the Quran screen
        private async void CreateButtonsToQRScreen()
        {
            // Wait until the Quran Surah data is fetched
            await SomeMethodAsyncToQRScreen();

            // Button dimensions
            int buttonWidth = 230;
            int buttonHeight = 120;
            int margin = 50; // Margin between buttons
            int xPos = 80; // Initial x position
            int yPos = 80; // Initial y position

            // Ensure Quran Surah list is not empty
            if (_QuranSurah != null && _QuranSurah.Count > 0)
            {
                int i = 0;
                foreach (var reciter in _QuranSurah)
                {
                    RoundButton button = new RoundButton();
                    button.Text = reciter.name; // Set button text
                    button.Width = buttonWidth; // Set button width
                    button.Height = buttonHeight; // Set button height
                    button.Location = new Point(xPos, yPos); // Set button location
                    button.Click += Button_ClickToQRScreen; // Assign click event handler
                    button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
                    button.FlatAppearance.BorderSize = 0;
                    button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SeaGreen;
                    button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    button.Font = new System.Drawing.Font("Microsoft YaHei", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    button.ForeColor = System.Drawing.Color.White;
                    button.UseVisualStyleBackColor = false;
                    button.Cursor = System.Windows.Forms.Cursors.Hand;
                    button.BorderRadius = 15;
                    button.TabIndex = i;
                    button.Tag = reciter.id;
                    button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

                    Label reciterLabel = new Label
                    {
                        Text = "سورة",
                        ForeColor = Color.Gray,
                        BackColor = Color.Transparent,
                        Font = new Font("Arial", 14, FontStyle.Regular),
                        AutoSize = true,
                        Location = new Point(90, 10)
                    };

                    Label reciterInfoLabel = new Label
                    {
                        Text = reciter.array.Count.ToString() + " عدد الآيات",
                        ForeColor = Color.Gray,
                        BackColor = Color.Transparent,
                        Font = new Font("Arial", 11, FontStyle.Regular),
                        AutoSize = true,
                        Location = new Point(10, 90)
                    };
                    button.Controls.Add(reciterInfoLabel);
                    button.Controls.Add(reciterLabel);

                    // Add button to the panel
                    pnlQuran.Controls.Add(button);

                    // Update button position for next button
                    xPos += buttonWidth + margin;

                    // Move to next row after every third button
                    if ((i + 1) % 3 == 0)
                    {
                        xPos = 80; // Reset x position
                        yPos += buttonHeight + 40;  // Update y position
                    }
                    i++;
                }
            }
            else
            {
                MessageBox.Show("No reciters found.");
            }
        }

        // Event handler for Quran Surah button click
        private void Button_ClickToQRScreen(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Form frmQuran = new QuranScreen(Convert.ToByte(btn.Tag));
            frmQuran.ShowDialog();
        }


        /* METHODS FOR LISTEN QURAN PANEL */


        // fetches reciters data asynchronously from the specified API URL
        public async Task SomeMethodAsyncToLQScreen()
        {
            ListenQuranScreen listenQuranScreen = new ListenQuranScreen();
            string apiUrl = "https://www.mp3quran.net/api/_arabic.json";
            _reciters = await listenQuranScreen.GetRecitersAsync(apiUrl);
        }

        // creates buttons dynamically for the Listen Quran screen
        private async void CreateButtonsToLQScreen()
        {
            // Wait until the reciters data is fetched
            await SomeMethodAsyncToLQScreen();

            // Button dimensions
            int buttonWidth = 230;
            int buttonHeight = 120;
            int margin = 50; // Margin between buttons
            int xPos = 80; // Initial x position
            int yPos = 80; // Initial y position

            // Ensure reciters list is not empty
            if (_reciters != null && _reciters.Count > 0)
            {
                int i = 0;
                foreach (var reciter in _reciters)
                {
                    RoundButton button = new RoundButton();
                    button.Text = reciter.Name; // Set button text
                    button.Width = buttonWidth; // Set button width
                    button.Height = buttonHeight; // Set button height
                    button.Location = new Point(xPos, yPos); // Set button location
                    button.Click += Button_ClickToLQScreen; // Assign click event handler
                    button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
                    button.FlatAppearance.BorderSize = 0;
                    button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SeaGreen;
                    button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    button.Font = new System.Drawing.Font("Microsoft YaHei", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    button.ForeColor = System.Drawing.Color.White;
                    button.UseVisualStyleBackColor = false;
                    button.Cursor = System.Windows.Forms.Cursors.Hand;
                    button.BorderRadius = 15;
                    button.TabIndex = i;
                    button.Tag = reciter.Id;
                    button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

                    // Add labels to the button
                    Label reciterLabel = new Label
                    {
                        Text = "القارئ",
                        ForeColor = Color.Gray,
                        BackColor = Color.Transparent,
                        Font = new Font("Arial", 12, FontStyle.Regular),
                        AutoSize = true,
                        Location = new Point(90, 10)
                    };

                    Label reciterInfoLabel = new Label
                    {
                        Text = reciter.Rewaya,
                        ForeColor = Color.Gray,
                        BackColor = Color.Transparent,
                        Font = new Font("Arial", 11, FontStyle.Regular),
                        AutoSize = true,
                        Location = new Point(10, 90)
                    };
                    button.Controls.Add(reciterInfoLabel);
                    button.Controls.Add(reciterLabel);

                    // Add button to the panel
                    pnlListen.Controls.Add(button);

                    // Update button position for next button
                    xPos += buttonWidth + margin;

                    // Move to next row after every third button
                    if ((i + 1) % 3 == 0)
                    {
                        xPos = 80; // Reset x position
                        yPos += buttonHeight + 40; // Update y position
                    }
                    i++;
                }
            }
            else
            {
                MessageBox.Show("No reciters found.");
            }
        }

        // Event handler for Listen Quran button click and send the selected reciter id
        private void Button_ClickToLQScreen(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Form frmListen = new ListenQuranScreen(Convert.ToInt16(btn.Tag));
            frmListen.ShowDialog();
        }


        /* METHODS FOR AZKAR HESN-ELMOSLIM PANEL */


        // fetches Azkar data asynchronously from the specified API URL
        public async Task SomeMethodAsyncToAZScreen()
        {
            AdhkarScreen adhkarScreen = new AdhkarScreen();
            string apiUrl = "https://raw.githubusercontent.com/rn0x/Adhkar-json/main/adhkar.json";
            _Azkar = await adhkarScreen.GetAzkarAsync(apiUrl);
        }

        // creates buttons dynamically for the Azkar screen
        private async void CreateButtonsToAZScreen()
        {
            // Wait until the Azkar data is fetched
            await SomeMethodAsyncToAZScreen();

            // Button dimensions
            int buttonWidth = 400;
            int buttonHeight = 80;
            int margin = 30; // Margin between buttons
            int xPos = 70; // Initial x position
            int yPos = 200; // Initial y position

            // Ensure Azkar list is not empty
            if (_Azkar != null && _Azkar.Count > 0)
            {
                int i = 0;
                foreach (var Zekr in _Azkar)
                {
                    RoundButton button = new RoundButton();
                    button.Text = Zekr.category; // Set button text
                    button.Width = buttonWidth; // Set button text
                    button.Height = buttonHeight; // Set button height
                    button.Location = new Point(xPos, yPos); // Set button height
                    button.Click += Button_ClickToAZScreen; // Assign click event handler
                    button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
                    button.FlatAppearance.BorderSize = 0;
                    button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SeaGreen;
                    button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    button.Font = new System.Drawing.Font("Microsoft YaHei", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    button.ForeColor = System.Drawing.Color.White;
                    button.UseVisualStyleBackColor = false;
                    button.Cursor = System.Windows.Forms.Cursors.Hand;
                    button.BorderRadius = 15;
                    button.TabIndex = i;
                    button.Tag = Zekr.id;
                    button.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                    // Add button to the panel
                    pnlMuslimTower.Controls.Add(button);

                    // Update button position for next button
                    xPos += buttonWidth + margin;

                    // Update button position for next button
                    if ((i + 1) % 2 == 0)
                    {
                        xPos = 70; // Reset x position
                        yPos += buttonHeight + 30; // Update y position
                    }
                    i++;
                }
            }
            else
            {
                MessageBox.Show("No reciters found.");
            }
        }

        // Event handler for Azkar button click
        private void Button_ClickToAZScreen(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Form frmAzkar = new AdhkarScreen(Convert.ToByte(btn.Tag));
            frmAzkar.ShowDialog();
        }


        /* METHODS FOR AZKAR QUICK-ZEKR PANEL */


        // Event handler for the shuffle button click
        private async void btnShuffle_Click(object sender, EventArgs e)
        {
            await SomeMethodAsyncToAZScreen();

            if (_Azkar != null && _Azkar.Count > 0)
            {
                Random random = new Random();
                int randomIndex = random.Next(_Azkar.Count);
                var RandomZekr = _Azkar.ElementAt(randomIndex);
                if (RandomZekr.array != null && RandomZekr.array.Count > 0)
                {
                    // Select a random item from RandomZekr.array
                    int randomItemIndex = random.Next(RandomZekr.array.Count);
                    var randomZekrItem = RandomZekr.array[randomItemIndex];

                    // Assign the random text to lblShuffleRemember
                    lblShuffleRemember.Text = randomZekrItem.text;
                }
                else
                {
                    lblShuffleRemember.Text = "No content available in this Zekr.";
                }
            }
        }

        // This event handler is triggered whenever the size of the lblShuffleRemember label changes.
        private void lblShuffleRemember_SizeChanged(object sender, EventArgs e)
        {
            // Update the location of groupBox for copy & Shuffle buttons to be below lblShuffleRemember with a customizable offset (10 in this case).
            groupBox1.Location = new Point(30, lblShuffleRemember.Bottom + 10);
            groupBox1.PerformLayout();
        }

        // Event handler for the copy button click
        private void btnCopy_Click(object sender, EventArgs e)
        {
            // Assuming ZekrInfoLabel is a class-level variable
            Button btnCopy = sender as Button;
            if (btnCopy != null)
            {
                Clipboard.SetText(lblShuffleRemember.Text);
                MessageBox.Show("Text copied to clipboard!");
            }
        }


        /* METHODS FOR PRAISE PANEL */


        // Event handler for the random Zekr radio button checked change
        private void rbRandomZekr_CheckedChanged(object sender, EventArgs e)
        {
            
            gbSpecificZekr.Enabled = rbSpecificZikr.Checked;
            rbSpecificZekr1.Checked = rbSpecificZikr.Checked;// to make الله أكبر as default
        }

        // Method to reset the screen
        private void ResetScreen()
        {
            rbRandomZekr.Checked = true;
        }

        // Method to select a random Zekr for notification
        private void SelectRandomZekrNotify()
        {
            var controls = gbSpecificZekr.Controls;
            Random random = new Random();
            int index = random.Next(4);
            var rbSelect = controls[index];
            SelectSpecificZekrNotify(rbSelect, EventArgs.Empty);          
        }

        // Method to select a specific Zekr for notification
        private void SelectSpecificZekrNotify(object sender, EventArgs e)
        {
            System.Windows.Forms.RadioButton rbSelect = sender as System.Windows.Forms.RadioButton;
            _ZekrNotify = rbSelect.Text;
        }

        // Method to determine the text for the notification balloon
        private string BalloonText()
        {
            if (rbRandomZekr.Checked)
            {
                SelectRandomZekrNotify();
                return _ZekrNotify;
            }
            else
                return _ZekrNotify;
        }

        // Method to show the notification balloon
        private void ShowBallon()
        {
            notifyIcon1.Icon = SystemIcons.Application;
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.BalloonTipTitle = "Azkar Notification.";
            notifyIcon1.BalloonTipText = BalloonText();
            notifyIcon1.ShowBalloonTip(1000);
        }

        // Event handler for the start Zekr button click
        private void btnStartZekr_Click(object sender, EventArgs e)
        {
            if(linkLblSpecificTime.Tag.ToString() == "1")
            {
                // Calculate the time until the specific time
                TimeSpan timeUntilSpecificTime = new TimeSpan(dtpSpecificTimeZekr.Value.Hour, 
                    dtpSpecificTimeZekr.Value.Minute, dtpSpecificTimeZekr.Value.Second) - DateTime.Now.TimeOfDay;
                timerZekr.Interval = (int)timeUntilSpecificTime.TotalMilliseconds;
                timerZekr.Start();
            }

            else
            { 
                ShowBallon();
                timerZekr.Interval = (int)numericZekr.Value * 1000; // 30 seconds
                timerZekr.Start();
            }
        }

        // Event handler for the timer tick
        private void Timer_Tick(object sender, EventArgs e)
        {
            ShowBallon();
        }

        // Event handler for the stop Zekr button click
        private void btnStopZekr_Click(object sender, EventArgs e)
        {
            timerZekr.Stop(); // Stop the timer to halt balloon notifications
        }

        // Event handler for the specific time link label click
        private void linkLblSpecificTime_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (linkLblSpecificTime.Tag.ToString() == "0")
            {
                dtpSpecificTimeZekr.Visible = true;
                linkLblSpecificTime.Tag = 1;
            }
            else
            {
                dtpSpecificTimeZekr.Visible = false;
                linkLblSpecificTime.Tag = 0;
            }
        }

        private int _RosaryCounter = 0;
        // Increment the counter and update the label text when the button is clicked
        private void btnElectRosary_Click(object sender, EventArgs e)
        {
            _RosaryCounter++;
            lblNumElectRosary.Text = _RosaryCounter.ToString();
        }

        // Reset the counter and label text to zero when the button is clicked
        private void btnMakeCntRosary0_Click(object sender, EventArgs e)
        {
            _RosaryCounter = 0;
            lblNumElectRosary.Text = "0";
        }


        /* METHODS FOR PRAYER PANEL */


        // Reset the prayer times panel asynchronously
        private async void ResetPnlPrayer()
        {
            await GetPrayerTimesAsync();
        }

        // Initialize the timer and attach the event handler
        private Timer timer;
        private void InitializeTimer()
        {
            // Initialize the timer
            timer = new Timer();
            timer.Interval = 1000; // Set the timer interval to 1 second (1000 milliseconds)
            timer.Tick += timerTime_Tick; // Attach the event handler
            timer.Start(); // Start the timer
        }

        // Event handler for the timer tick event
        private void timerTime_Tick(object sender, EventArgs e)
        {
            // Update Gregorian date label
            lblGregorianDate.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");

            // Create a new instance of the UmAlQuraCalendar
            UmAlQuraCalendar hijriCalendar = new UmAlQuraCalendar();

            // Get the current date in the Hijri calendar
            DateTime hijriDate = DateTime.Now;
            int hijriYear = hijriCalendar.GetYear(hijriDate);
            int hijriMonth = hijriCalendar.GetMonth(hijriDate);
            int hijriDay = hijriCalendar.GetDayOfMonth(hijriDate);

            // Display the Hijri date label
            lblHegiraDate.Text = $"{hijriYear}-{hijriMonth:D2}-{hijriDay:D2}";

            // Update time labels
            lblHours.Text = DateTime.Now.ToString("HH:mm");
            lblSeconds.Text = DateTime.Now.ToString(":ss tt");

            // Update day label
            lblDay.Text = DateTime.Now.ToString("dddd", new CultureInfo("ar-SA"));

            // Reset prayer buttons background and get the next prayer time
            ResetbtnsPrayersBackGround();
            GetTheNextPrayer();
        }

        // Reset the background color of prayer buttons
        private void ResetbtnsPrayersBackGround()
        {
            btnFajr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            btnDhuhr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            btnAsr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            btnMaghrib.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            btnIsha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));

            lblFajrPrayer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            lblAduherPrayer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            lblAsrPrayer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            lblMaghrebPrayer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            lblEshaaPrayer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
        }

        // Update the selected country label
        private void cmbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblCountry.Text = cmbCountry.SelectedItem.ToString();
        }

        // Variables to hold prayer times
        DateTime _fajrTime;
        DateTime _dhuhrTime;
        DateTime _asrTime;
        DateTime _maghribTime;
        DateTime _ishaTime;
        string _nextPrayerName = "Fajr"; // Default to Fajr

        // Fetch prayer times asynchronously from API
        public async Task GetPrayerTimesAsync()
        {
            HttpClient httpClient = new HttpClient();
            string endpoint = "https://api.aladhan.com/v1/timingsByCity";
            string parameters = "?city=Damietta&country=Egypt&method=8";
            string url = endpoint + parameters;

            HttpResponseMessage responseMessage = await httpClient.GetAsync(url);
            string response = await responseMessage.Content.ReadAsStringAsync();
            dynamic resultObject = JsonConvert.DeserializeObject(response);

            // Extract prayer times from the response
            _fajrTime = resultObject.data.timings.Fajr;
            _dhuhrTime = resultObject.data.timings.Dhuhr;
            _asrTime = resultObject.data.timings.Asr;
            _maghribTime = resultObject.data.timings.Maghrib;
            _ishaTime = resultObject.data.timings.Isha;

            // Update the UI with prayer times
            lblFajrPrayer.Text = _fajrTime.ToString(@"hh\:mm tt");
            lblAduherPrayer.Text = _dhuhrTime.ToString(@"hh\:mm tt");
            lblAsrPrayer.Text = _asrTime.ToString(@"hh\:mm tt");
            lblMaghrebPrayer.Text = _maghribTime.ToString(@"hh\:mm tt");
            lblEshaaPrayer.Text = _ishaTime.ToString(@"hh\:mm tt");
        }

        // Determine the next prayer and update UI accordingly
        private void GetTheNextPrayer()
        {
            DateTime currentTime = DateTime.Now;
            DateTime nextPrayerTime = _fajrTime; // Start with Fajr time as default

            // Determine the next prayer based on current time
            if (currentTime < _fajrTime)
            {
                _nextPrayerName = "fajr";
                btnFajr.BackColor = System.Drawing.Color.SeaGreen;
                lblFajrPrayer.BackColor = System.Drawing.Color.SeaGreen;
            }
            else if (currentTime < _dhuhrTime)
            {
                nextPrayerTime = _dhuhrTime;
                _nextPrayerName = "Dhuhr";
                btnDhuhr.BackColor = System.Drawing.Color.SeaGreen;
                lblAduherPrayer.BackColor = System.Drawing.Color.SeaGreen;

            }
            else if (currentTime < _asrTime)
            {
                nextPrayerTime = _asrTime;
                _nextPrayerName = "Asr";
                btnAsr.BackColor = System.Drawing.Color.SeaGreen;
                lblAsrPrayer.BackColor = System.Drawing.Color.SeaGreen;
            }
            else if (currentTime < _maghribTime)
            {
                nextPrayerTime = _maghribTime;
                _nextPrayerName = "Maghrib";
                btnMaghrib.BackColor = System.Drawing.Color.SeaGreen;
                lblMaghrebPrayer.BackColor = System.Drawing.Color.SeaGreen;
            }
            else if (currentTime < _ishaTime)
            {
                nextPrayerTime = _ishaTime;
                _nextPrayerName = "Isha";
                btnIsha.BackColor = System.Drawing.Color.SeaGreen;
                lblEshaaPrayer.BackColor = System.Drawing.Color.SeaGreen;
            }
            else
            {
                // Current time is after Isha, so next prayer is Fajr of the next day
                nextPrayerTime = _fajrTime.AddDays(1); // Add one day to Fajr time
                _nextPrayerName = "Fajr";
                btnFajr.BackColor = System.Drawing.Color.SeaGreen;
                lblFajrPrayer.BackColor = System.Drawing.Color.SeaGreen;
            }

            // Calculate the time to the next prayer
            TimeSpan timeToNextPrayer = nextPrayerTime - currentTime;

            // Update UI with next prayer and time to it
            lblNextPrayer.Text = _nextPrayerName;
            btnTimeToNextPrayer.Text = timeToNextPrayer.ToString(@"hh\:mm\:ss");

        }

        /* METHODS FOR INFO PANEL */

        // Event handler for the application information button click
        private void btnAppInfo_Click(object sender, EventArgs e)
        {
            pnlOwner.Visible = false;
            pnlAppInfo.Visible = true;
        }

        // Event handler for the owner information button click
        private void btnOwner_Click(object sender, EventArgs e)
        {
            pnlOwner.Visible = true;
            pnlAppInfo.Visible = false;
        }

        // Load event handler for the main form
        private void Main_Load(object sender, EventArgs e)
        {
            pnlMain.BringToFront();
            InitializeTimer();
            ResetScreen();
            ResetPnlPrayer();

        }

        // Open links in default browser when corresponding picture boxes are clicked
        private void pbOwnerTelegram_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://t.me/Vector_9x");
        }
        
        private void pbOwnerGitHub_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Naeem-Arafa");
        }

        private void pbOwnerGmail_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:naeemarafa56@gmail.com");
        }

        private void pbMyAppRepo_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Naeem-Arafa/Muslim-App-Naeem-Al-Eman");
        }

        private void pbAltaqwaApp_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://altaqwaa.org/");
        }
    }
}
