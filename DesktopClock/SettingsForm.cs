namespace DesktopClock
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class SettingsForm : Form
    {
        private ClockForm mainClock;

        public SettingsForm(ClockForm clockForm)
        {
            InitializeComponent();

            if (clockForm == null)
            {
                MessageBox.Show("Error: ClockForm reference is null.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close(); // Prevent opening without a valid reference
                return;
            }

            this.mainClock = clockForm; // Assign reference
            LoadThemes(); // Now safe to load themes

            // Set currently selected theme
            themeSelector.SelectedItem = mainClock.selectedTheme;
        }

        private void BgColorButton_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    mainClock.BackColor = colorDialog.Color;
                }
            }
        }

        private void ClockColorButton_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    mainClock.SetClockColor(colorDialog.Color);
                }
            }
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ThemeSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (themeSelector.SelectedItem != null)
            {
                string theme = themeSelector.SelectedItem.ToString();
                mainClock.ApplyTheme(theme);
            }
        }

        private void CreateTheme_Click(object sender, EventArgs e)
        {
            string themeName = themeNameTextBox.Text.Trim();

            if (string.IsNullOrEmpty(themeName))
            {
                MessageBox.Show("Please enter a theme name.");
                return;
            }

            // Prevent duplicate theme names
            if (mainClock.customThemes.Any(t => t.Name == themeName))
            {
                MessageBox.Show("A theme with this name already exists.");
                return;
            }

            // Get user-selected colors
            Color bgColor = mainClock.BackColor;
            Color textColor = ClockForm.globalColor;

            // Create new theme and add to list
            Theme newTheme = new Theme(themeName, bgColor, textColor);
            mainClock.customThemes.Add(newTheme);

            // Save changes
            mainClock.SaveSettings();

            // Reload themes to reflect the new addition
            LoadThemes();

            // Select the new theme automatically
            themeSelector.SelectedItem = themeName;
        }


        private void LoadThemes()
        {
            themeSelector.Items.Clear(); // Prevent duplicate entries

            // Add default themes only once
            themeSelector.Items.AddRange(new object[] { "Default", "Dark Mode", "Light Mode", "Blue Theme" });

            // Add custom themes saved in ClockForm
            foreach (var theme in mainClock.customThemes)
            {
                themeSelector.Items.Add(theme.Name);
            }

            // Set currently selected theme
            themeSelector.SelectedItem = mainClock.selectedTheme;
        }

        private void EditTheme_Click(object sender, EventArgs e)
        {
            if (themeSelector.SelectedItem == null)
            {
                MessageBox.Show("Please select a theme to edit.");
                return;
            }

            string selectedThemeName = themeSelector.SelectedItem.ToString();

            // Find the theme in the list
            Theme selectedTheme = mainClock.customThemes.FirstOrDefault(t => t.Name == selectedThemeName);

            if (selectedTheme == null)
            {
                MessageBox.Show("Cannot edit built-in themes.");
                return;
            }

            // Let the user pick new colors
            using (ColorDialog bgColorDialog = new ColorDialog())
            using (ColorDialog textColorDialog = new ColorDialog())
            {
                if (bgColorDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedTheme.BackgroundColor = bgColorDialog.Color;
                }

                if (textColorDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedTheme.TextColor = textColorDialog.Color;
                }
            }

            // Apply changes and save settings
            mainClock.ApplyTheme(selectedThemeName);
            mainClock.SaveSettings();
        }


        private void DeleteTheme_Click(object sender, EventArgs e)
        {
            if (themeSelector.SelectedItem == null)
            {
                MessageBox.Show("Please select a theme to delete.");
                return;
            }

            string selectedThemeName = themeSelector.SelectedItem.ToString();

            // Prevent deletion of built-in themes
            if (selectedThemeName == "Default" || selectedThemeName == "Dark Mode" ||
                selectedThemeName == "Light Mode" || selectedThemeName == "Blue Theme")
            {
                MessageBox.Show("Cannot delete built-in themes.");
                return;
            }

            // Confirm deletion
            DialogResult confirm = MessageBox.Show($"Are you sure you want to delete the theme '{selectedThemeName}'?",
                                                   "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.No) return;

            // Remove theme from list
            Theme themeToRemove = mainClock.customThemes.FirstOrDefault(t => t.Name == selectedThemeName);
            if (themeToRemove != null)
            {
                mainClock.customThemes.Remove(themeToRemove);
            }

            // Save updated themes
            mainClock.SaveSettings();

            // Reload themes in the dropdown
            LoadThemes();

            // Reset selection
            themeSelector.SelectedItem = "Default";
        }


    }

}
