using Cowboy.Classes;
using Cowboy.Interfaces;
using Cowboy.Settings;

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
        internal List<List<GameComponent>> GameComponents = new List<List<GameComponent>>();

        private int GC_count = 0;
        private bool IsPaused = false;

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
                MessageBox.Show("!Vészhelyzet, a játék beállítások nélkül lett meghívva " +
                    "(futni fog de egy előre beállított default settings-el)!");

                this.gameSettings = new GameSettings().SetDefaultSettings();
            }
        }

        /// <summary>
        /// beállítja a form-ot
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        private Player player1;
        private Player player2;

        /// <summary>
        /// A konstruktorban átvett beállítások alapján elvégzi a szükséges beállítások / felépíti az alap komponenseket
        /// </summary>
        public void Setup()
        {
            //window size
            if (gameSettings.WindowSize.Width < 10 && gameSettings.WindowSize.Height < 10)
            {
                this.WindowState = FormWindowState.Maximized;
                
            }
            else
                this.Size = gameSettings.WindowSize;


            // Create Player 1
            Player temp_player1 = new Player(1,
                Create.pictureBox("PB_player1", new Size(60, 60), new Point(0, 0),
                Properties.Resources.PlayerBeta),
                gameSettings.PlayerSettings[0]);


            // Create Player 2 \\
            Player  temp_player2 = new Player(2,
                Create.pictureBox("PB_player2", new Size(60, 60), new Point(0, 0),
                Properties.Resources.PlayerBeta),
                gameSettings.PlayerSettings[1]);




            // place to the correct pos \\
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


            // Create the GameComponents List that holds all of the game objects \\
            List<GameComponent> Players = new List<GameComponent>
            {
                player1,
                player2
            };


            // index 0: Players 
            GameComponents.Add(Players);
            // index 1: Bullets
            GameComponents.Add(new List<GameComponent>());
            // index 2: Explosions
            GameComponents.Add(new List<GameComponent>());

            MainGameTimer.Enabled = true;
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
                    ((Player)GameComponents[0][i]).MoveDown = false;;
            }

            // --- MAIN UPDATE --- \\
            for (int i = 0; i < GameComponents.Count; i++)
            {
                for (int j = 0; j < GameComponents[i].Count; j++)
                {
                    if (GameComponents[i][j] is IUpdate)
                    {
                        ((IUpdate)GameComponents[i][j]).Update();
                        if (GameComponents[i][j] is Bot)
                        {
                            //MessageBox.Show("bot");
                        }
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

                //bullet hit TODO (az a terv hogy osztály lesz csak létrehozva és akkor nem lesz minden update-nél comp)
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

                            GameComponents[2].Add((GameComponent)explo);
                            Controls.Add(explo.pictureBox);

                            bullet.pictureBox.Dispose();
                            tempBullet.pictureBox.Dispose();

                            GameComponents[1].Remove(bullet);
                            GameComponents[1].Remove(tempBullet);

                            //GC.Collect(); // valamit ezzel kezdeni kell
                            //TODO osztály dolog megint mint feljebb
                            GC_count++;
                        }
                    }
                }
            }

            // --- EXPLOSION --- \\
            for (int i = 0; i < GameComponents[2].Count; i++)
            {
                Explosion explo = (Explosion)GameComponents[2][i];
                if(explo.UpdatesLeft == 0)
                {
                    explo.pictureBox.Dispose();
                    GameComponents[2].RemoveAt(i);
                    GC_count++;
                }
            }

            if (GC_count > 15)
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
                mainMenu.Show();
                this.Hide();
                MainGameTimer.Stop();
            }
            if (e.KeyCode == Keys.Space)
            {
                if (IsPaused)
                {
                    MainGameTimer.Start();
                    this.Text = "Game";
                    IsPaused = false;
                }
                else
                {
                    MainGameTimer.Stop();
                    this.Text = "Paused";
                    IsPaused = true;
                }
            }

            // left Player (player 1) input (down) management
            if (e.KeyCode == Keys.W)
                ((Player)GameComponents[0][0]).MoveUp = true;
            else if (e.KeyCode == Keys.S)
                ((Player)GameComponents[0][0]).MoveDown = true;
            //shoot
            else if (e.KeyCode == Keys.D)
            {
                Shoot((Player)GameComponents[0][0]);
            }

            // right Player (player 2) input (down) management
            if (e.KeyCode == Keys.Up)
                ((Player)GameComponents[0][1]).MoveUp = true;
            else if (e.KeyCode == Keys.Down)
                ((Player)GameComponents[0][1]).MoveDown = true;
            //shoot
            else if (e.KeyCode == Keys.Left)
            {
                Shoot((Player)GameComponents[0][1]);
            }
        }

        internal void Shoot(Player player)
        {
            Bullet? bullet = player.weapon.Shoot();
            if (bullet != null)
            {
                if(player.weapon.BulletSpeed<0)
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
            if (e.KeyCode == Keys.W)
                player1.MoveUp = false;
            else if (e.KeyCode == Keys.S)
                player1.MoveDown = false;

            // rigth player (player 1) input (up) management
            if (e.KeyCode == Keys.Up)
                player2.MoveUp = false;
            else if (e.KeyCode == Keys.Down)
                player2.MoveDown = false;
        }

        private Point GetPlayerStartPos(Player player, string side)
        {
            // todo, nem jó ez így
            if (side.ToLower() == "left")
            {
                player.SetWeaponOffSet(new Point(40, 5));
                return new Point(80 - player.pictureBox.Width, Height / 2 - player.pictureBox.Height / 2);
            }
            else if (side.ToLower() == "rigth")
            {
                player.SetWeaponOffSet(new Point(-40, 5));
                player.pictureBox.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                return new Point(Width - 50 - player.pictureBox.Width / 2, Height / 2 - player.pictureBox.Height / 2);
            }
            return new Point(0, 0);
        }

        private void WinCheck()
        {
            for (int i = 0; i < GameComponents[0].Count; i++)
            {
                if (((Player)GameComponents[0][i]).HP <= 0)
                {
                    MainGameTimer.Enabled = false;

                    if (i == 0)
                    {
                        MessageBox.Show("Jobb oldali játékos nyert");
                        // todo
                    }
                    else
                    {
                        MessageBox.Show("Bal oldali játékos nyert");
                        // todo
                    }
                    Reset();
                    Setup();

                    // TODO database !!!!!!!!!!

                }
            }
        }

        private void Reset()
        {
            // Removes every gamecomponent \\
            for (int i = 0; i < GameComponents.Count; i++)
            {
                for (int j = 0; j < GameComponents[i].Count; j++)
                {
                    GameComponents[i][j].pictureBox.Dispose();
                }
            }

            for (int i = 0; i < GameComponents[0].Count; i++)
            {
                Player player = (Player)GameComponents[0][i];
                player.Hpbar.Dispose();
            }

            GameComponents.Clear();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            GameComponents.Clear();
            mainMenu.Show();
        }
    }
}