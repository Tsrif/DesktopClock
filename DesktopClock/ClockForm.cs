namespace DesktopClock
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class ClockForm : Form
    {
        private bool isFullscreen = false;
        private int fontSize = 120;
        public static Color globalColor = Color.Purple;
        private string settingsFile = "settings.txt";
        public string selectedTheme = "Default";
        public List<Theme> customThemes = new List<Theme>();

        public ClockForm()
        {
            InitializeComponent(); // Ensure this is called first
            this.Size = new Size(1280, 720);
            LoadSettings(); // Load saved settings
            timer.Start();
            this.KeyPreview = true;
            this.KeyDown += ClockForm_KeyDown;
            CenterClock();
        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            timeLabel.Text = now.ToString("hh:mm");
            amPmLabel.Text = now.ToString("tt");
            secondsLabel.Text = now.ToString("ss");
            dateLabel.Text = now.ToString("dddd - MMMM d");

            CenterClock();
        }

        private void CenterClock()
        {
            int centerX = this.ClientSize.Width / 2;
            int centerY = this.ClientSize.Height / 2;

            // Update label positions dynamically
            timeLabel.Location = new Point(centerX - (timeLabel.Width / 2), centerY - (timeLabel.Height / 2));

            // Position AM/PM label properly relative to the time label
            amPmLabel.Location = new Point(timeLabel.Right + 10, timeLabel.Top + (timeLabel.Height / 4));

            // Position seconds label slightly lower than AM/PM, aligned to the right
            secondsLabel.Location = new Point(amPmLabel.Left, amPmLabel.Bottom + 5);

            // Center date label below the time
            dateLabel.Location = new Point(centerX - (dateLabel.Width / 2), timeLabel.Bottom + 20);
        }



        private void ClockForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F11)
            {
                ToggleFullscreen();
            }
        }

        private void ToggleFullscreen()
        {
            isFullscreen = !isFullscreen;

            if (isFullscreen)
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                this.Bounds = Screen.PrimaryScreen.Bounds;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Normal;
                this.Size = new Size(800, 400);
            }

            CenterClock();
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            SettingsForm settings = new SettingsForm(this);
            settings.ShowDialog();
        }

        public void SetClockColor(Color color)
        {
            timeLabel.ForeColor = color;
            amPmLabel.ForeColor = color;
            secondsLabel.ForeColor = color;
            dateLabel.ForeColor = color;
        }

        private void IncreaseFontSize_Click(object sender, EventArgs e)
        {
            AdjustFontSize(10);
        }

        private void DecreaseFontSize_Click(object sender, EventArgs e)
        {
            AdjustFontSize(-10);
        }

        private void AdjustFontSize(int change)
        {
            fontSize += change;
            if (fontSize < 50) fontSize = 50; // Prevent too small
            if (fontSize > this.ClientSize.Height / 2) fontSize = this.ClientSize.Height / 2; // Prevent overflow

            timeLabel.Font = new Font(timeLabel.Font.FontFamily, fontSize, FontStyle.Regular);
            amPmLabel.Font = new Font(amPmLabel.Font.FontFamily, fontSize / 3, FontStyle.Regular);
            secondsLabel.Font = new Font(secondsLabel.Font.FontFamily, fontSize / 3, FontStyle.Regular);
            dateLabel.Font = new Font(dateLabel.Font.FontFamily, fontSize / 3, FontStyle.Regular);

            CenterClock(); // Ensure elements are repositioned correctly
        }


        private void LoadSettings()
        {
            // Apply Default Theme First (Prevents Missing Theme Issue)
            ApplyTheme("Default");

            if (File.Exists(settingsFile))
            {
                string[] lines = File.ReadAllLines(settingsFile);

                // Load main settings
                string[] mainSettings = lines[0].Split(',');
                this.BackColor = Color.FromArgb(int.Parse(mainSettings[0]));
                ClockForm.globalColor = Color.FromArgb(int.Parse(mainSettings[1]));
                AdjustFontSize(int.Parse(mainSettings[2]) - fontSize);
                selectedTheme = mainSettings[3];

                // Apply the saved theme
                ApplyTheme(selectedTheme);
            }
            else
            {
                // If no settings file exists, save the default theme
                selectedTheme = "Default";
                SaveSettings();
            }

            CenterClock(); // Ensure elements are correctly placed
        }



        public void ApplyTheme(string theme)
        {
            selectedTheme = theme;

            // Check if it's a custom theme
            Theme customTheme = customThemes.FirstOrDefault(t => t.Name == theme);
            if (customTheme != null)
            {
                this.BackColor = customTheme.BackgroundColor;
                SetClockColor(customTheme.TextColor);
                SaveSettings(); // Ensure changes persist
                return;
            }

            // Apply predefined themes
            switch (theme)
            {
                case "Default":
                    this.BackColor = Color.Black;
                    SetClockColor(Color.Purple);
                    break;
                case "Dark Mode":
                    this.BackColor = Color.DarkGray;
                    SetClockColor(Color.White);
                    break;
                case "Light Mode":
                    this.BackColor = Color.White;
                    SetClockColor(Color.Black);
                    break;
                case "Blue Theme":
                    this.BackColor = Color.LightBlue;
                    SetClockColor(Color.Navy);
                    break;
            }

            SaveSettings(); // Save theme after applying it
        }


        public void SaveSettings()
        {
            List<string> lines = new List<string>
    {
        $"{this.BackColor.ToArgb()},{ClockForm.globalColor.ToArgb()},{fontSize},{selectedTheme}"
    };

            // Save only existing themes
            foreach (var theme in customThemes)
            {
                lines.Add($"{theme.Name},{theme.BackgroundColor.ToArgb()},{theme.TextColor.ToArgb()}");
            }

            File.WriteAllLines(settingsFile, lines);
        }




    }

}
