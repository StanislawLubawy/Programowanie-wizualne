namespace Gra_w_Hayraxy
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            leftPanel = new Panel();
            btnExit = new Button();
            btnSettings = new Button();
            btnStart = new Button();
            titleLabel = new Label();
            leftPanel.SuspendLayout();
            SuspendLayout();
            // 
            // leftPanel
            // 
            leftPanel.BackColor = Color.LightGray;
            leftPanel.Controls.Add(btnExit);
            leftPanel.Controls.Add(btnSettings);
            leftPanel.Controls.Add(btnStart);
            leftPanel.Controls.Add(titleLabel);
            leftPanel.Dock = DockStyle.Left;
            leftPanel.Location = new Point(0, 0);
            leftPanel.Margin = new Padding(4, 5, 4, 5);
            leftPanel.Name = "leftPanel";
            leftPanel.Size = new Size(200, 523);
            leftPanel.TabIndex = 0;
            leftPanel.Paint += leftPanel_Paint;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(13, 338);
            btnExit.Margin = new Padding(4, 5, 4, 5);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(160, 62);
            btnExit.TabIndex = 3;
            btnExit.Text = "KONIEC";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += BtnExit_Click;
            // 
            // btnSettings
            // 
            btnSettings.Location = new Point(13, 246);
            btnSettings.Margin = new Padding(4, 5, 4, 5);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(160, 62);
            btnSettings.TabIndex = 2;
            btnSettings.Text = "USTAWIENIA";
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += BtnSettings_Click;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(13, 154);
            btnStart.Margin = new Padding(4, 5, 4, 5);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(160, 62);
            btnStart.TabIndex = 1;
            btnStart.Text = "START";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += BtnStart_Click;
            // 
            // titleLabel
            // 
            titleLabel.Font = new Font("Arial", 12F, FontStyle.Bold);
            titleLabel.Location = new Point(13, 31);
            titleLabel.Margin = new Padding(4, 0, 4, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(160, 92);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "ZŁAP\nHYRAXY";
            titleLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(196, 523);
            Controls.Add(leftPanel);
            Margin = new Padding(4, 5, 4, 5);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ZŁAP HYRAXY";
            leftPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label titleLabel;
    }
}
