namespace DesktopClock
{
    partial class SettingsForm
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

        private System.Windows.Forms.Button bgColorButton;
        private System.Windows.Forms.Button clockColorButton;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.ComboBox themeSelector;
        private System.Windows.Forms.TextBox themeNameTextBox;
        private System.Windows.Forms.Button createThemeButton;
        private System.Windows.Forms.Button editThemeButton;
        private System.Windows.Forms.Button deleteThemeButton;

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            bgColorButton = new Button();
            clockColorButton = new Button();
            applyButton = new Button();
            themeSelector = new ComboBox();
            themeNameTextBox = new TextBox();
            createThemeButton = new Button();
            label1 = new Label();
            this.editThemeButton = new System.Windows.Forms.Button();
            this.deleteThemeButton = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // bgColorButton
            // 
            bgColorButton.Location = new Point(30, 30);
            bgColorButton.Name = "bgColorButton";
            bgColorButton.Size = new Size(144, 23);
            bgColorButton.TabIndex = 0;
            bgColorButton.Text = "Background Color";
            bgColorButton.Click += BgColorButton_Click;
            // 
            // clockColorButton
            // 
            clockColorButton.Location = new Point(30, 70);
            clockColorButton.Name = "clockColorButton";
            clockColorButton.Size = new Size(144, 23);
            clockColorButton.TabIndex = 1;
            clockColorButton.Text = "Clock Color";
            clockColorButton.Click += ClockColorButton_Click;
            // 
            // applyButton
            // 
            applyButton.Location = new Point(63, 109);
            applyButton.Name = "applyButton";
            applyButton.Size = new Size(75, 23);
            applyButton.TabIndex = 2;
            applyButton.Text = "Apply";
            applyButton.Click += ApplyButton_Click;
            // 
            // themeSelector
            // 
            themeSelector.DropDownStyle = ComboBoxStyle.DropDownList;
            themeSelector.Items.AddRange(new object[] { "Default", "Dark Mode", "Light Mode", "Blue Theme", "Custom" });
            themeSelector.Location = new Point(130, 200);
            themeSelector.Name = "themeSelector";
            themeSelector.Size = new Size(121, 23);
            themeSelector.TabIndex = 3;
            themeSelector.SelectedIndexChanged += ThemeSelector_SelectedIndexChanged;
            // 
            // themeNameTextBox
            // 
            themeNameTextBox.Location = new Point(130, 230);
            themeNameTextBox.Name = "themeNameTextBox";
            themeNameTextBox.PlaceholderText = "Enter theme name";
            themeNameTextBox.Size = new Size(150, 23);
            themeNameTextBox.TabIndex = 4;
            // 
            // createThemeButton
            // 
            createThemeButton.Location = new Point(130, 260);
            createThemeButton.Name = "createThemeButton";
            createThemeButton.Size = new Size(75, 23);
            createThemeButton.TabIndex = 5;
            createThemeButton.Text = "Create Theme";
            createThemeButton.Click += CreateTheme_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(131, 171);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 6;
            label1.Text = "Theme";


            // Edit Theme Button
            this.editThemeButton.Text = "Edit Theme";
            this.editThemeButton.Location = new System.Drawing.Point(130, 290);
            this.editThemeButton.Width = 150;
            this.editThemeButton.Click += new System.EventHandler(this.EditTheme_Click);

            // Delete Theme Button
            this.deleteThemeButton.Text = "Delete Theme";
            this.deleteThemeButton.Location = new System.Drawing.Point(130, 320);
            this.deleteThemeButton.Width = 150;
            this.deleteThemeButton.Click += new System.EventHandler(this.DeleteTheme_Click);


            // 
            // SettingsForm
            // 
            ClientSize = new Size(348, 358);
            Controls.Add(label1);
            Controls.Add(bgColorButton);
            Controls.Add(clockColorButton);
            Controls.Add(applyButton);
            Controls.Add(themeSelector);
            Controls.Add(themeNameTextBox);
            Controls.Add(createThemeButton);
            this.Controls.Add(this.editThemeButton);
            this.Controls.Add(this.deleteThemeButton);
            Name = "SettingsForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
    }
}