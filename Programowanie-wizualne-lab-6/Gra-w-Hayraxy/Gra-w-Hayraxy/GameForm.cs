using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Gra_w_Hayraxy
{
    public partial class GameForm : Form
    {
        private Button[,] cells;
        private List<Point> activeAnimals = new List<Point>();
        private Random rnd = new Random();

        private int boardCols;
        private int boardRows;
        private int totalHyrax;
        private int totalRacoon;
        private int totalCroc;

        private DateTime gameStartTime;
        private System.Timers.Timer gameTimer;
        private System.Timers.Timer spawnTimer;
        private int score = 0;
        private int caughtHyrax = 0;
        private bool gameRunning = false;

        private Image imgHyrax;
        private Image imgRacoon;
        private Image imgCroc;

        public GameForm(int cols, int rows, int hyrax, int racoon, int croc)
        {
            boardCols = cols;
            boardRows = rows;
            totalHyrax = hyrax;
            totalRacoon = racoon;
            totalCroc = croc;

            InitializeComponent();

            LoadImages();

            gameTimer = new System.Timers.Timer(100);
            gameTimer.Elapsed += GameTimer_Elapsed;

            spawnTimer = new System.Timers.Timer(3000);
            spawnTimer.Elapsed += SpawnTimer_Elapsed;

            BuildGameGrid();
            StartGame();
        }

        private void LoadImages()
        {
            imgHyrax  = LoadImageFile("Hyraxa.jpg");
            imgRacoon = LoadImageFile("Szop.jpg");
            imgCroc   = LoadImageFile("krokodyl.jpg");
        }

        private Image LoadImageFile(string fileName)
        {

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            if (File.Exists(path))
            {
                byte[] bytes = File.ReadAllBytes(path);
                return Image.FromStream(new MemoryStream(bytes));
            }
            return null;
        }

        private Image GetAnimalImage(string animal)
        {
            Image img = animal switch
            {
                "hyrax"  => imgHyrax,
                "racoon" => imgRacoon,
                "croc"   => imgCroc,
                _        => null
            };

            if (img != null)
                return img;

            Bitmap bmp = new Bitmap(64, 64);
            using (var g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Transparent);
                if (animal == "hyrax")       g.FillEllipse(Brushes.Green, 4, 4, 56, 56);
                else if (animal == "racoon") g.FillEllipse(Brushes.Gray,  4, 4, 56, 56);
                else if (animal == "croc")   g.FillEllipse(Brushes.Red,   4, 4, 56, 56);
            }
            return bmp;
        }

        private void BuildGameGrid()
        {
            gameGrid.ColumnStyles.Clear();
            gameGrid.RowStyles.Clear();
            gameGrid.Controls.Clear();
            gameGrid.ColumnCount = boardCols;
            gameGrid.RowCount = boardRows;

            for (int c = 0; c < boardCols; c++)
                gameGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / boardCols));
            for (int r = 0; r < boardRows; r++)
                gameGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / boardRows));

            cells = new Button[boardCols, boardRows];
            for (int r = 0; r < boardRows; r++)
            {
                for (int c = 0; c < boardCols; c++)
                {
                    var btn = new Button { Dock = DockStyle.Fill, Margin = new Padding(5), BackColor = Color.White };
                    btn.BackgroundImageLayout = ImageLayout.Zoom;
                    btn.Tag = null;
                    btn.Click += Cell_Click;
                    gameGrid.Controls.Add(btn, c, r);
                    cells[c, r] = btn;
                }
            }
        }

        private void StartGame()
        {
            if (gameRunning) return;

            gameRunning = true;
            score = 0;
            caughtHyrax = 0;
            gameStartTime = DateTime.Now;
            ClearGame();

            gameTimer.Start();
            spawnTimer.Start();
        }

        private void ClearGame()
        {
            if (cells == null) return;
            foreach (var btn in cells)
            {
                btn.Tag = null;
                btn.BackgroundImage = null;
            }
            activeAnimals.Clear();
        }

        private void GameTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Invoke(() =>
            {
                var elapsed = DateTime.Now - gameStartTime;
                lblTimer.Text = $"{elapsed.TotalSeconds:F1} s";
            });
        }

        private void SpawnTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (!gameRunning || cells == null) return;

            Invoke(() =>
            {
                foreach (var p in activeAnimals)
                {
                    cells[p.X, p.Y].Tag = null;
                    cells[p.X, p.Y].BackgroundImage = null;
                }
                activeAnimals.Clear();

                var pool = new List<string>();
                int hyraxLeft = totalHyrax - caughtHyrax;
                for (int i = 0; i < hyraxLeft; i++) pool.Add("hyrax");
                for (int i = 0; i < totalRacoon; i++) pool.Add("racoon");
                for (int i = 0; i < totalCroc; i++) pool.Add("croc");

                if (pool.Count == 0) return;

                int spawnCount = rnd.Next(1, Math.Min(3, boardCols * boardRows) + 1);
                var indices = Enumerable.Range(0, boardCols * boardRows).OrderBy(x => rnd.Next()).Take(spawnCount).ToArray();

                foreach (var idx in indices)
                {
                    int x = idx % boardCols;
                    int y = idx / boardCols;
                    string animal = pool[rnd.Next(pool.Count)];
                    cells[x, y].Tag = animal;
                    cells[x, y].BackgroundImage = GetAnimalImage(animal);
                    activeAnimals.Add(new Point(x, y));
                }

                var clearTimer = new System.Threading.Timer(_ =>
                {
                    Invoke(() =>
                    {
                        foreach (var p in activeAnimals)
                        {
                            cells[p.X, p.Y].Tag = null;
                            cells[p.X, p.Y].BackgroundImage = null;
                        }
                        activeAnimals.Clear();
                    });
                }, null, 900, System.Threading.Timeout.Infinite);
            });
        }

        private void Cell_Click(object sender, EventArgs e)
        {
            if (!gameRunning) return;

            var btn = (Button)sender;
            var tag = btn.Tag as string;
            if (tag == null) return;

            if (tag == "hyrax")
            {
                score += 1;
                caughtHyrax += 1;
                btn.Tag = null;
                btn.BackgroundImage = null;

                if (caughtHyrax >= totalHyrax)
                {
                    EndGame(true);
                }
            }
            else if (tag == "racoon")
            {
                score -= 1;
            }
            else if (tag == "croc")
            {
                EndGame(false);
            }
        }

        private void EndGame(bool success)
        {
            gameRunning = false;
            gameTimer.Stop();
            spawnTimer.Stop();

            var elapsed = DateTime.Now - gameStartTime;
            string msg = success
                ? $"Sukces! Zlapalez wszystkie Hyraxy w czasie {elapsed.TotalSeconds:F1}s.\nWynik: {score}"
                : $"Porazka! Zostales zjedzony przez krokodyla.";

            MessageBox.Show(msg, "Koniec Gry", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            gameRunning = false;
            gameTimer?.Stop();
            spawnTimer?.Stop();
            base.OnFormClosing(e);
        }

        private void gameGrid_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
