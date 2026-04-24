using System;
using System.Drawing;
using System.Windows.Forms;

namespace gra_w_Hyraxy
{
    public class StartForm : Form
    {
        private NumericUpDown nudRows;
        private NumericUpDown nudCols;
        private NumericUpDown nudHyrax;
        private NumericUpDown nudRaccoon;
        private NumericUpDown nudCroc;
        private NumericUpDown nudTimeSec;
        private Button btnStart;
        private Button btnExit;

        public StartForm()
        {
            Text = "Złap Hyraxy - Start";
            Width = 400;
            Height = 350;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;

            var lblRows = new Label { Text = "Wiersze (3-10)", Left = 20, Top = 20, Width = 140 };
            nudRows = new NumericUpDown { Left = 180, Top = 20, Minimum = 3, Maximum = 10, Value = 3 };

            var lblCols = new Label { Text = "Kolumny (3-10)", Left = 20, Top = 60, Width = 140 };
            nudCols = new NumericUpDown { Left = 180, Top = 60, Minimum = 3, Maximum = 10, Value = 3 };

            var lblHyrax = new Label { Text = "Liczba Hyrax (1-6)", Left = 20, Top = 100, Width = 140 };
            nudHyrax = new NumericUpDown { Left = 180, Top = 100, Minimum = 1, Maximum = 6, Value = 1 };

            var lblRaccoon = new Label { Text = "Liczba Szopów (2-8)", Left = 20, Top = 140, Width = 140 };
            nudRaccoon = new NumericUpDown { Left = 180, Top = 140, Minimum = 2, Maximum = 8, Value = 2 };

            var lblCroc = new Label { Text = "Liczba Krokodyli (0-1)", Left = 20, Top = 180, Width = 140 };
            nudCroc = new NumericUpDown { Left = 180, Top = 180, Minimum = 0, Maximum = 1, Value = 0 };

            var lblTime = new Label { Text = "Czas gry (sekundy)", Left = 20, Top = 220, Width = 140 };
            nudTimeSec = new NumericUpDown { Left = 180, Top = 220, Minimum = 10, Maximum = 600, Value = 60 };

            btnStart = new Button { Text = "Start", Left = 60, Top = 260, Width = 100 };
            btnExit = new Button { Text = "Zakończ", Left = 200, Top = 260, Width = 100 };

            btnStart.Click += BtnStart_Click;
            btnExit.Click += (s, e) => Application.Exit();

            Controls.AddRange(new Control[] { lblRows, nudRows, lblCols, nudCols, lblHyrax, nudHyrax, lblRaccoon, nudRaccoon, lblCroc, nudCroc, lblTime, nudTimeSec, btnStart, btnExit });
        }

        private void BtnStart_Click(object? sender, EventArgs e)
        {
            int rows = (int)nudRows.Value;
            int cols = (int)nudCols.Value;
            int hyrax = (int)nudHyrax.Value;
            int raccoon = (int)nudRaccoon.Value;
            int croc = (int)nudCroc.Value;
            int seconds = (int)nudTimeSec.Value;

            var game = new GameForm(rows, cols, hyrax, raccoon, croc, seconds);
            game.ShowDialog(this);
        }
    }
}
