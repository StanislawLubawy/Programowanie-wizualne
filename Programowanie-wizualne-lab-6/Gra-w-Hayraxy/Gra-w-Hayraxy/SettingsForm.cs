using System;
using System.Windows.Forms;

namespace Gra_w_Hayraxy
{
    public class SettingsForm : Form
    {
        public int BoardCols { get; private set; }
        public int BoardRows { get; private set; }
        public int TotalHyrax { get; private set; }
        public int TotalRacoon { get; private set; }
        public int TotalCroc { get; private set; }

        private NumericUpDown nudCols;
        private NumericUpDown nudRows;
        private NumericUpDown nudHyrax;
        private NumericUpDown nudRacoon;
        private NumericUpDown nudCroc;

        public SettingsForm(int cols, int rows, int hyrax, int racoon, int croc)
        {
            BoardCols = cols;
            BoardRows = rows;
            TotalHyrax = hyrax;
            TotalRacoon = racoon;
            TotalCroc = croc;

            Text = "Ustawienia";
            Width = 400;
            Height = 300;
            StartPosition = FormStartPosition.CenterParent;

            var lblCols = new Label { Text = "Kolumny:", Left = 10, Top = 20, Width = 150 };
            nudCols = new NumericUpDown { Left = 200, Top = 20, Width = 100, Minimum = 3, Maximum = 10, Value = cols };

            var lblRows = new Label { Text = "Wiersze:", Left = 10, Top = 60, Width = 150 };
            nudRows = new NumericUpDown { Left = 200, Top = 60, Width = 100, Minimum = 3, Maximum = 10, Value = rows };

            var lblHyrax = new Label { Text = "Liczba Hyrax:", Left = 10, Top = 100, Width = 150 };
            nudHyrax = new NumericUpDown { Left = 200, Top = 100, Width = 100, Minimum = 1, Maximum = 6, Value = hyrax };

            var lblRacoon = new Label { Text = "Liczba Szopów:", Left = 10, Top = 140, Width = 150 };
            nudRacoon = new NumericUpDown { Left = 200, Top = 140, Width = 100, Minimum = 2, Maximum = 8, Value = racoon };

            var lblCroc = new Label { Text = "Liczba Krokodyli:", Left = 10, Top = 180, Width = 150 };
            nudCroc = new NumericUpDown { Left = 200, Top = 180, Width = 100, Minimum = 0, Maximum = 1, Value = croc };

            var btnOK = new Button { Text = "OK", Left = 100, Top = 230, Width = 80, DialogResult = DialogResult.OK };
            var btnCancel = new Button { Text = "Anuluj", Left = 200, Top = 230, Width = 80, DialogResult = DialogResult.Cancel };

            Controls.AddRange(new Control[] { lblCols, nudCols, lblRows, nudRows, lblHyrax, nudHyrax, lblRacoon, nudRacoon, lblCroc, nudCroc, btnOK, btnCancel });

            AcceptButton = btnOK;
            CancelButton = btnCancel;
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
            if (DialogResult == DialogResult.OK)
            {
                BoardCols = (int)nudCols.Value;
                BoardRows = (int)nudRows.Value;
                TotalHyrax = (int)nudHyrax.Value;
                TotalRacoon = (int)nudRacoon.Value;
                TotalCroc = (int)nudCroc.Value;
            }
        }
    }
}
