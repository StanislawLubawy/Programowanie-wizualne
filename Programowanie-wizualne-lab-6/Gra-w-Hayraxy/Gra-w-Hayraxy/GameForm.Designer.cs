namespace Gra_w_Hayraxy
{
    partial class GameForm
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
            gameGrid = new TableLayoutPanel();
            lblTimer = new Label();
            SuspendLayout();
            // 
            // gameGrid
            // 
            gameGrid.ColumnCount = 3;
            gameGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            gameGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            gameGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.34F));
            gameGrid.Dock = DockStyle.Fill;
            gameGrid.Location = new Point(0, 0);
            gameGrid.Margin = new Padding(13, 15, 13, 15);
            gameGrid.Name = "gameGrid";
            gameGrid.RowCount = 3;
            gameGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            gameGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            gameGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 33.34F));
            gameGrid.Size = new Size(1067, 693);
            gameGrid.TabIndex = 0;
            gameGrid.Paint += gameGrid_Paint;
            // 
            // lblTimer
            // 
            lblTimer.BorderStyle = BorderStyle.FixedSingle;
            lblTimer.Dock = DockStyle.Bottom;
            lblTimer.Font = new Font("Arial", 16F, FontStyle.Bold);
            lblTimer.Location = new Point(0, 693);
            lblTimer.Margin = new Padding(4, 0, 4, 0);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(1067, 76);
            lblTimer.TabIndex = 1;
            lblTimer.Text = "0 s";
            lblTimer.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1067, 769);
            Controls.Add(gameGrid);
            Controls.Add(lblTimer);
            Margin = new Padding(4, 5, 4, 5);
            Name = "GameForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ZŁAP HYRAXY - Gra";
            ResumeLayout(false);
        }

        private System.Windows.Forms.TableLayoutPanel gameGrid;
        private System.Windows.Forms.Label lblTimer;
    }
}
