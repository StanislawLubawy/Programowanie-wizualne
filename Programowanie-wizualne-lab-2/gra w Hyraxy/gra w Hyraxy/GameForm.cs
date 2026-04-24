using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace gra_w_Hyraxy
{
    public class GameForm : Form
    {
        private readonly int rows;
        private readonly int cols;
        private readonly int totalHyrax;
        private readonly int totalRaccoon;
        private readonly int totalCroc;
        private readonly int timeSeconds;

        private TableLayoutPanel grid;
        private System.Windows.Forms.Timer mainTimer;
        private System.Windows.Forms.Timer hideTimer;
        private Random rnd = new Random();
        private Dictionary<Button, Animal?> cellState = new Dictionary<Button, Animal?>();
        private int caughtHyrax = 0;
        private int score = 0;
        private int secondsLeft;

        enum Animal { None, Hyrax, Raccoon, Croc }

        public GameForm(int rows, int cols, int hyrax, int raccoon, int croc, int seconds)
        {
            this.rows = rows;
            this.cols = cols;
            this.totalHyrax = hyrax;
            this.totalRaccoon = raccoon;
            this.totalCroc = croc;
            this.timeSeconds = seconds;
            this.secondsLeft = seconds;

            InitializeComponents();
            StartGame();
        }

        private void InitializeComponents()
        {
            Text = "Gra - Złap Hyraxy";
            Width = Math.Min(100 + cols * 80, 1200);
            Height = Math.Min(120 + rows * 80, 900);

            grid = new TableLayoutPanel { RowCount = rows, ColumnCount = cols, Dock = DockStyle.Fill };
            for (int r = 0; r < rows; r++) grid.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / rows));
            for (int c = 0; c < cols; c++) grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / cols));

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    var btn = new Button { Dock = DockStyle.Fill, Margin = new Padding(2) };
                    btn.BackColor = Color.LightGray;
                    btn.Click += Cell_Click;
                    grid.Controls.Add(btn, c, r);
                    cellState[btn] = Animal.None;
                }
            }

            var pnl = new Panel { Dock = DockStyle.Top, Height = 40 };
            var lblScore = new Label { Text = $"Wynik: {score}", Left = 10, Top = 10, AutoSize = true };
            var lblTime = new Label { Text = $"Czas: {secondsLeft}", Left = 120, Top = 10, AutoSize = true };

            pnl.Controls.Add(lblScore);
            pnl.Controls.Add(lblTime);

            Controls.Add(grid);
            Controls.Add(pnl);

            mainTimer = new System.Windows.Forms.Timer { Interval = 3000 };
            mainTimer.Tick += (s, e) => SpawnAnimals(lblScore);

            hideTimer = new System.Windows.Forms.Timer { Interval = 900 };
            hideTimer.Tick += (s, e) => HideAnimals();

            var countdown = new System.Windows.Forms.Timer { Interval = 1000 };
            countdown.Tick += (s, e) => { secondsLeft--; lblTime.Text = $"Czas: {secondsLeft}"; if (secondsLeft <= 0) EndGame(false); };
            countdown.Start();
        }

        private void StartGame()
        {
            mainTimer.Start();
        }

        private void SpawnAnimals(Label lblScore)
        {
            // clear previous
            HideAnimals();

            var buttons = cellState.Keys.ToList();
            int places = Math.Min(buttons.Count, totalHyrax + totalRaccoon + totalCroc);
            var chosen = buttons.OrderBy(x => rnd.Next()).Take(places).ToList();

            // place animals according to requested counts but randomized
            var list = new List<Animal>();
            list.AddRange(Enumerable.Repeat(Animal.Hyrax, totalHyrax));
            list.AddRange(Enumerable.Repeat(Animal.Raccoon, totalRaccoon));
            list.AddRange(Enumerable.Repeat(Animal.Croc, totalCroc));

            // if more places than animals, fill rest with None
            while (list.Count < places) list.Add(Animal.None);

            list = list.OrderBy(x => rnd.Next()).ToList();

            for (int i = 0; i < chosen.Count; i++)
            {
                var btn = chosen[i];
                var animal = list[i];
                cellState[btn] = animal;
                SetButtonImage(btn, animal);
            }

            hideTimer.Start();
        }

        private void HideAnimals()
        {
            foreach (var kv in cellState.Keys.ToList())
            {
                cellState[kv] = Animal.None;
                kv.Text = "";
                kv.BackColor = Color.LightGray;
                kv.Image = null;
            }
            hideTimer.Stop();
        }

        private void SetButtonImage(Button btn, Animal animal)
        {
            btn.Text = animal == Animal.Hyrax ? "H" : animal == Animal.Raccoon ? "S" : animal == Animal.Croc ? "K" : "";
            btn.BackColor = animal == Animal.Hyrax ? Color.LightGreen : animal == Animal.Raccoon ? Color.LightSalmon : animal == Animal.Croc ? Color.Red : Color.LightGray;
        }

        private void Cell_Click(object? sender, EventArgs e)
        {
            if (sender is not Button btn) return;
            var animal = cellState[btn];
            if (animal == Animal.None) return;

            if (animal == Animal.Hyrax)
            {
                score++; caughtHyrax++;
            }
            else if (animal == Animal.Raccoon)
            {
                score--;
            }
            else if (animal == Animal.Croc)
            {
                EndGame(false, "Zostałeś zjedzony przez krokodyla!");
                return;
            }

            cellState[btn] = Animal.None;
            btn.Text = "";
            btn.Image = null;
            btn.BackColor = Color.LightGray;

            if (caughtHyrax >= totalHyrax)
            {
                EndGame(true);
            }
        }

        private void InitializeComponent()
        {

        }

        private void EndGame(bool success, string? message = null)
        {
            mainTimer.Stop();
            hideTimer.Stop();

            string msg = message ?? (success ? "Gratulacje! Złapałeś wszystkie Hyraxy." : "Koniec gry.");
            MessageBox.Show(msg + $" Wynik: {score}", success ? "Sukces" : "Koniec gry", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
    }
}
