using System;
using System.Windows.Forms;

namespace Gra_w_Hayraxy
{
    public partial class MainForm : Form
    {
        private int boardCols = 3;
        private int boardRows = 3;
        private int totalHyrax = 1;
        private int totalRacoon = 2;
        private int totalCroc = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            var gameForm = new GameForm(boardCols, boardRows, totalHyrax, totalRacoon, totalCroc);
            gameForm.ShowDialog(this);
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            var settingsForm = new SettingsForm(boardCols, boardRows, totalHyrax, totalRacoon, totalCroc);
            if (settingsForm.ShowDialog(this) == DialogResult.OK)
            {
                boardCols = settingsForm.BoardCols;
                boardRows = settingsForm.BoardRows;
                totalHyrax = settingsForm.TotalHyrax;
                totalRacoon = settingsForm.TotalRacoon;
                totalCroc = settingsForm.TotalCroc;
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void leftPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

