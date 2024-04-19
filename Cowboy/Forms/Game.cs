using Cowboy.Classes;
using Cowboy.Interfaces;
using Cowboy.Settings;
using Cowboy.Utilities;

namespace Cowboy
{
    public partial class Game : Form
    {
        private MainMenu mainMenu { get; set; }
        private GameSettings gameSettings { get; set; }

        /// <summary>
        /// Index 0: player;<br/>
        /// Index 1: bullet;<br/>
        /// Index 2: explosion;
        /// </summary>
        private List<List<GameComponent>> GameComponents = new List<List<GameComponent>>();

        private int GC_count = 0;
        private bool IsPaused = false;
        private float GameTime = 0;

        private bool LockInputs = false;

        /// <summary>
        /// Átveszi a Beállításokat, ha null akkor egy alapot generál/használ
        /// </summary>
        /// <param name="gameSettings">beállítások</param>
        public Game(GameSettings gameSettings)
        {
            InitializeComponent();

            this.gameSettings = gameSettings;

            if (gameSettings == null)
            {
                MessageBox.Show("Vészhelyzet, a játék beállítások nélkül lett elindítva\n" +
                    "(futni fog de egy előre beállított default settings-el)!", "Veszély");

                this.gameSettings = new GameSettings().SetDefaultSettings();
            }
        }

        /// <summary>
        /// beállítja a form-ot
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            // "Render mod" \\
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            // resize off
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // remove buttons
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.ShowIcon = false;

            this.Text = "Game";
        }

        public void SetMainMenu(MainMenu mainMenu)
        {
            this.mainMenu = mainMenu;
        }

        /// <summary>
        /// A konstruktorban átvett beállítások alapján elvégzi a szükséges beállítások / felépíti az alap komponenseket
        /// </summary>
        public void Setup()
        {
            GameComponents.Clear();
            GameTime = 0;
            Player player1;
            Player player2;

            if (gameSettings.WindowSize.Width < 10 && gameSettings.WindowSize.Height < 10)
            {
                this.WindowState = FormWindowState.Maximized;
                this.FormBorderStyle = FormBorderStyle.None;
            }
            else
                this.Size = gameSettings.WindowSize;

            // Player 1
            Player temp_player1 = new Player(1, gameSettings.PlayerSettings[0].PlayerName,
                Create.pictureBox("PB_player1", new Size(60, 60), new Point(0, 0),
                Properties.Resources.player),
                gameSettings.PlayerSettings[0]);

            // Player 2
            Player temp_player2 = new Player(2, gameSettings.PlayerSettings[1].PlayerName,
                Create.pictureBox("PB_player2", new Size(60, 60), new Point(0, 0),
                Properties.Resources.player),
                gameSettings.PlayerSettings[1]);

            // elhelyezés
            temp_player1.pictureBox.Location = GetPlayerStartPos(temp_player1, "left");
            temp_player2.pictureBox.Location = GetPlayerStartPos(temp_player2, "rigth");

            // átalakítás bot-nak ha kell \\
            // player1
            if (gameSettings.PlayerSettings[0].Bot)
                player1 = new Bot(temp_player1, temp_player2, this);
            else
                player1 = temp_player1;

            // player2
            if (gameSettings.PlayerSettings[1].Bot)
                player2 = new Bot(temp_player2, temp_player1, this);
            else
                player2 = temp_player2;

            // Bullet haladás irány korrekció
            player2.weapon.BulletSpeed *= -1;

            List<GameComponent> Players = new List<GameComponent>
            {
                player1,
                player2
            };

            // GameComponents List feltöltése (tárolja az összes GameComponent-et) \\
            // index 0: Players 
            GameComponents.Add(Players);
            // index 1: Bullets
            GameComponents.Add(new List<GameComponent>());
            // index 2: Explosions
            GameComponents.Add(new List<GameComponent>());

            MainGameTimer.Enabled = true;
            StopWatch.Enabled = true;
        }

        /// <summary>
        /// becsukja az ablakot és vissza rak a főmenübe
        /// </summary>
        private void Back()
        {
            if (mainMenu != null)
            {
                mainMenu.Show();
                StopWatch.Stop();
                MainGameTimer.Stop();
                this.Close();
            }
        }

        /// <summary>
        /// a szíve a játék folyásának, ez adja meg az idő múlását (10ms)
        /// </summary>
        private void MainGame_Update(object sender, EventArgs e)
        {
            // --- PLAYER --- \\
            for (int i = 0; i < GameComponents[0].Count; i++)
            {
                if (GameComponents[0][i].pictureBox.Location.Y < 0)
                    ((Player)GameComponents[0][i]).MoveUp = false;

                if (GameComponents[0][i].pictureBox.Location.Y + 100 > this.Height)
                    ((Player)GameComponents[0][i]).MoveDown = false; ;
            }

            // --- MAIN UPDATE --- \\
            for (int i = 0; i < GameComponents.Count; i++)
            {
                for (int j = 0; j < GameComponents[i].Count; j++)
                {
                    if (GameComponents[i][j] is IUpdatable)
                    {
                        ((IUpdatable)GameComponents[i][j]).Update();
                    }
                }
            }

            // --- BULLET --- \\
            for (int i = 0; i < GameComponents[1].Count; i++)
            {
                Bullet bullet = ((Bullet)GameComponents[1][i]);

                // Destruct
                if (!bullet.IsInTheSreen(Width))
                {
                    ((Bullet)GameComponents[1][i]).pictureBox.Dispose();
                    GameComponents[1].RemoveAt(i);
                    GC_count++;
                }

                // Player hit
                for (int j = 0; j < GameComponents[0].Count; j++)
                {
                    if (GameComponents[0][j].pictureBox.Bounds.IntersectsWith(bullet.pictureBox.Bounds) &&
                        bullet.PlayerID != GameComponents[0][j].PlayerID)
                    {
                        ((Player)GameComponents[0][j]).Hit(bullet);

                        GameComponents[1][i].pictureBox.Dispose();
                        GameComponents[1].RemoveAt(i);
                        GC_count++;

                        WinCheck();
                    }
                }

                // Collision
                if (gameSettings.BulletCollision)
                {
                    for (int j = 0; j < GameComponents[1].Count; j++)
                    {
                        GameComponent tempBullet = GameComponents[1][j];
                        if (bullet.pictureBox.Bounds.IntersectsWith(tempBullet.pictureBox.Bounds) &&
                            bullet.PlayerID != tempBullet.PlayerID)
                        {
                            Explosion explo = new Explosion(-1,
                                Create.pictureBox("explo", new Size(40, 40), new Point(0, 0), Properties.Resources.explo),
                                bullet, tempBullet, 10);

                            GameComponents[2].Add(explo);
                            Controls.Add(explo.pictureBox);

                            bullet.pictureBox.Dispose();
                            tempBullet.pictureBox.Dispose();

                            GameComponents[1].Remove(bullet);
                            GameComponents[1].Remove(tempBullet);

                            GC_count++;
                        }
                    }
                }
            }

            // --- EXPLOSION --- \\
            for (int i = 0; i < GameComponents[2].Count; i++)
            {
                Explosion explo = (Explosion)GameComponents[2][i];
                if (explo.UpdatesLeft == 0)
                {
                    explo.pictureBox.Dispose();
                    GameComponents[2].RemoveAt(i);
                    GC_count++;
                }
            }

            // memoria használat csökkentés
            if (GC_count > 10)
            {
                GC.Collect();
                GC_count = 0;
            }
        }

        /// <summary>
        /// Valós időben szedi be az Input-okat a user-től (Down)
        /// </summary>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // back to main menu
            if (e.KeyCode == Keys.Escape)
            {
                Back();
            }
            if (e.KeyCode == Keys.Space)
            {
                Pause();
            }

            if (!LockInputs)
            {
                // left Player (player 1) input (down) management
                if (e.KeyCode == gameSettings.InputSettings[0].UpKey)
                    ((Player)GameComponents[0][0]).MoveUp = true;
                else if (e.KeyCode == gameSettings.InputSettings[0].DownKey)
                    ((Player)GameComponents[0][0]).MoveDown = true;
                //shoot
                if (e.KeyCode == gameSettings.InputSettings[0].ShootKey)
                {
                    Shoot((Player)GameComponents[0][0]);
                }

                // right Player (player 2) input (down) management
                if (e.KeyCode == gameSettings.InputSettings[1].UpKey)
                    ((Player)GameComponents[0][1]).MoveUp = true;
                else if (e.KeyCode == gameSettings.InputSettings[1].DownKey)
                    ((Player)GameComponents[0][1]).MoveDown = true;
                //shoot
                if (e.KeyCode == gameSettings.InputSettings[1].ShootKey)
                {
                    Shoot((Player)GameComponents[0][1]);
                }
            }
        }

        internal void Shoot(Player player)
        {
            Bullet? bullet = player.weapon.Shoot();
            if (bullet != null)
            {
                if (player.weapon.BulletSpeed < 0)
                    bullet.pictureBox.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                GameComponents[1].Add(bullet);
            }
        }

        /// <summary>
        /// Valós időben szedi be az "Input"-okat a user-től (Up)
        /// </summary>
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            // left player (player 1) input (up) management
            if (e.KeyCode == gameSettings.InputSettings[0].UpKey)
                ((Player)GameComponents[0][0]).MoveUp = false;
            else if (e.KeyCode == gameSettings.InputSettings[0].DownKey)
                ((Player)GameComponents[0][0]).MoveDown = false;

            // rigth player (player 2) input (up) management
            if (e.KeyCode == gameSettings.InputSettings[1].UpKey)
                ((Player)GameComponents[0][1]).MoveUp = false;
            else if (e.KeyCode == gameSettings.InputSettings[1].DownKey)
                ((Player)GameComponents[0][1]).MoveDown = false;
        }

        private Point GetPlayerStartPos(Player player, string side)
        {
            if (side.ToLower() == "left")
            {
                player.SetWeaponOffSet(new Point(
                    player.pictureBox.Width,
                    (player.pictureBox.Location.Y/2+player.pictureBox.Height / 2)
                    ));

                return new Point(51, Height / 2 - player.pictureBox.Height / 2);
            }
            else if (side.ToLower() == "rigth")
            {
                player.SetWeaponOffSet(new Point(
                    -player.pictureBox.Width+30,
                    (player.pictureBox.Location.Y + player.pictureBox.Height / 2)
                    ));

                player.pictureBox.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);

                return new Point(Width - player.pictureBox.Width - 51, Height / 2 - player.pictureBox.Height / 2);
            }
            return new Point(0, 0);
        }

        private void Pause()
        {
            if (IsPaused)
            {
                MainGameTimer.Start();
                this.Text = "Játék";
                IsPaused = false;
                LockInputs = false;
            }
            else
            {
                MainGameTimer.Stop();
                this.Text = "Megállítva";
                IsPaused = true;
                LockInputs = true;
            }
        }

        private void WinCheck()
        {
            if (GameComponents.Count > 0 && GameComponents[0].Count > 0)
            {
                for (int i = 0; i < GameComponents[0].Count; i++)
                {
                    if (((Player)GameComponents[0][i]).HP <= 0)
                    {
                        MainGameTimer.Enabled = false;
                        StopWatch.Enabled = false;
                        string winnerName = "";

                        if (i == 0)
                        {
                            winnerName = gameSettings.PlayerSettings[1].PlayerName;
                            DbManager.Instance.Save(gameSettings.PlayerSettings[1].PlayerName, gameSettings.PlayerSettings[0].PlayerName, MathF.Round(GameTime, 2));
                        }
                        else
                        {
                            winnerName = gameSettings.PlayerSettings[0].PlayerName;
                            DbManager.Instance.Save(gameSettings.PlayerSettings[0].PlayerName, gameSettings.PlayerSettings[1].PlayerName, MathF.Round(GameTime, 2));
                        }
                        Reset(winnerName);
                    }
                }
            }
        }

        private void Reset(string winnerName)
        {
            // töröl minden komponenst
            for (int i = 0; i < GameComponents.Count; i++)
            {
                for (int j = 0; j < GameComponents[i].Count; j++)
                {
                    GameComponents[i][j].pictureBox.Dispose();
                }
            }

            for (int i = 0; i < GameComponents.Count; i++)
            {
                for (int j = 0; j < GameComponents[i].Count; j++)
                {
                    if (GameComponents[i][j] is Player)
                    {
                        Player player = GameComponents[i][j] as Player;
                        player.Hpbar.Dispose();
                        player.Name.Dispose();
                        player.pictureBox.Dispose();
                    }
                    else
                    {
                        GameComponents[i][j].pictureBox.Dispose();
                    }
                }
                GameComponents[i].Clear();
            }

            DialogResult dialogResult = MessageBox.Show($"{winnerName}, Nyert. Újra akarja kezdeni a játékot?", "Játék Vége", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Setup();
            }
            else if (dialogResult == DialogResult.No)
            {
                Back();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainMenu.Show();
            this.Hide();
            MainGameTimer.Stop();
            StopWatch.Stop();
        }

        private void StopWatch_tick(object sender, EventArgs e)
        {
            if (!IsPaused)
                GameTime += 0.1f;
        }
    }
}