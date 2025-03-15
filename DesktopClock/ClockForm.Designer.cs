namespace DesktopClock
{
    partial class ClockForm
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

        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label amPmLabel;
        private System.Windows.Forms.Label secondsLabel;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button increaseFontButton;
        private System.Windows.Forms.Button decreaseFontButton;

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            timeLabel = new Label();
            amPmLabel = new Label();
            secondsLabel = new Label();
            dateLabel = new Label();
            settingsButton = new Button();
            timer = new System.Windows.Forms.Timer(components);
            increaseFontButton = new Button();
            decreaseFontButton = new Button();
            SuspendLayout();
            // 
            // timeLabel
            // 
            timeLabel.AutoSize = true;
            timeLabel.Font = new Font("Arial", 120F);
            timeLabel.ForeColor = Color.Black;
            timeLabel.Location = new Point(50, 117);
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new Size(475, 178);
            timeLabel.TabIndex = 0;
            timeLabel.Text = "12:00";
            // 
            // amPmLabel
            // 
            amPmLabel.AutoSize = true;
            amPmLabel.Font = new Font("Arial", 40F);
            amPmLabel.ForeColor = Color.Black;
            amPmLabel.Location = new Point(516, 140);
            amPmLabel.Name = "amPmLabel";
            amPmLabel.Size = new Size(108, 61);
            amPmLabel.TabIndex = 1;
            amPmLabel.Text = "AM";
            // 
            // secondsLabel
            // 
            secondsLabel.AutoSize = true;
            secondsLabel.Font = new Font("Arial", 50F);
            secondsLabel.ForeColor = Color.Black;
            secondsLabel.Location = new Point(516, 201);
            secondsLabel.Name = "secondsLabel";
            secondsLabel.Size = new Size(106, 75);
            secondsLabel.TabIndex = 2;
            secondsLabel.Text = "00";
            // 
            // dateLabel
            // 
            dateLabel.AutoSize = true;
            dateLabel.Font = new Font("Arial", 40F);
            dateLabel.ForeColor = Color.Black;
            dateLabel.Location = new Point(83, 295);
            dateLabel.Name = "dateLabel";
            dateLabel.Size = new Size(501, 61);
            dateLabel.TabIndex = 3;
            dateLabel.Text = "Monday - January 1";
            // 
            // settingsButton
            // 
            settingsButton.BackColor = Color.Gray;
            settingsButton.Font = new Font("Arial", 12F, FontStyle.Bold);
            settingsButton.ForeColor = Color.White;
            settingsButton.Location = new Point(10, 10);
            settingsButton.Name = "settingsButton";
            settingsButton.Size = new Size(100, 30);
            settingsButton.TabIndex = 4;
            settingsButton.Text = "⚙ Settings";
            settingsButton.UseVisualStyleBackColor = false;
            settingsButton.Click += SettingsButton_Click;
            // 
            // timer
            // 
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            // 
            // increaseFontButton
            // 
            increaseFontButton.BackColor = Color.Gray;
            increaseFontButton.Font = new Font("Arial", 20F, FontStyle.Bold);
            increaseFontButton.ForeColor = Color.White;
            increaseFontButton.Location = new Point(10, 50);
            increaseFontButton.Name = "increaseFontButton";
            increaseFontButton.Size = new Size(50, 50);
            increaseFontButton.TabIndex = 5;
            increaseFontButton.Text = "+";
            increaseFontButton.UseVisualStyleBackColor = false;
            increaseFontButton.Click += IncreaseFontSize_Click;
            // 
            // decreaseFontButton
            // 
            decreaseFontButton.BackColor = Color.Gray;
            decreaseFontButton.Font = new Font("Arial", 20F, FontStyle.Bold);
            decreaseFontButton.ForeColor = Color.White;
            decreaseFontButton.Location = new Point(70, 50);
            decreaseFontButton.Name = "decreaseFontButton";
            decreaseFontButton.Size = new Size(50, 50);
            decreaseFontButton.TabIndex = 6;
            decreaseFontButton.Text = "-";
            decreaseFontButton.UseVisualStyleBackColor = false;
            decreaseFontButton.Click += DecreaseFontSize_Click;
            // 
            // ClockForm
            // 
            ClientSize = new Size(647, 443);
            Controls.Add(timeLabel);
            Controls.Add(amPmLabel);
            Controls.Add(secondsLabel);
            Controls.Add(dateLabel);
            Controls.Add(settingsButton);
            Controls.Add(increaseFontButton);
            Controls.Add(decreaseFontButton);
            Name = "ClockForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}