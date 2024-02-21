﻿using Cowboy.Classes;
using Cowboy.Interfaces;
using Cowboy.Settings;

namespace Cowboy
{
    public partial class Form1 : Form
    {
        private MainMenu mainMenu { get; set; }
        private GameSettings gameSettings { get; set; }

        private List<List<GameComponent>> GameComponents = new List<List<GameComponent>>();

        public Form1(GameSettings gameSettings)
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
            player1 = new Player(1,
                Create.pictureBox("PB_player1", new Size(60, 60), new Point(0, 0),
                Properties.Resources.PlayerBeta),
                gameSettings.PlayerSetting[0]);


            // Create Player 2 \\
            player2 = new Player(2,
                Create.pictureBox("PB_player2", new Size(60, 60), new Point(0, 0),
                Properties.Resources.PlayerBeta),
                gameSettings.PlayerSetting[1]);
            player2.weapon.BulletSpeed *= -1;

            // place to the correct pos \\
            player1.pictureBox.Location = GetPlayerStartPos(player1, "left");
            player2.pictureBox.Location = GetPlayerStartPos(player2, "rigth");


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

            MainGameTimer.Enabled = true;
        }

        private void MainGame_Update(object sender, EventArgs e)
        {
            // PLAYER MOVEMENT "border" \\
            for (int i = 0; i < GameComponents[0].Count; i++)
            {
                if (GameComponents[0][i].pictureBox.Location.Y < 0)
                    ((Player)GameComponents[0][i]).MoveUp = false;

                if (GameComponents[0][i].pictureBox.Location.Y + GameComponents[0][i].pictureBox.Size.Height > this.Height)
                    ((Player)GameComponents[0][i]).MoveDown = false;

                ((IUpdate)GameComponents[0][i]).Update();
            }

            // MOVEMENT UPDATE \\
            for (int i = 1; i < GameComponents.Count; i++)
            {
                for (int j = 0; j < GameComponents[i].Count; j++)
                {
                    if (GameComponents[i][j] is IUpdate)
                        (GameComponents[i][j] as IUpdate).Update();
                }
            }

            // BULLET EVENTS \\
            for (int i = 0; i < GameComponents[1].Count; i++)
            {
                Bullet bullet = ((Bullet)GameComponents[1][i]);

                //distruct
                if (!bullet.IsInTheSreen(Width))
                {
                    Controls.Remove(((Bullet)GameComponents[1][i]).pictureBox);
                    GameComponents[1].RemoveAt(i);
                }

                //player hit
                for (int j = 0; j < GameComponents[0].Count; j++)
                {
                    if (GameComponents[0][j].pictureBox.Bounds.IntersectsWith(bullet.pictureBox.Bounds) &&
                        bullet.PlayerID != GameComponents[0][j].PlayerID)
                    {
                        ((Player)GameComponents[0][j]).Hit(bullet);

                        Controls.Remove(GameComponents[1][i].pictureBox);
                        GameComponents[1].RemoveAt(i);

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
                            Controls.Remove(bullet.pictureBox);
                            Controls.Remove(tempBullet.pictureBox);

                            GameComponents[1].Remove(bullet);
                            GameComponents[1].Remove(tempBullet);
                        }
                    }
                }

                //TODO osztály dolog megint mint feljebb

            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // back to main menu \\
            if (e.KeyCode == Keys.Escape)
            {
                mainMenu.Show();
                this.Hide();
                MainGameTimer.Stop();
            }

            // left Player (player 1) input (down) management \\
            if (e.KeyCode == Keys.W)
                player1.MoveUp = true;
            else if (e.KeyCode == Keys.S)
                player1.MoveDown = true;
            //shoot
            else if (e.KeyCode == Keys.D)
            {
                Bullet bullet = player1.weapon.Shoot();
                if (bullet != null)
                    GameComponents[1].Add(bullet);
            }

            // right Player (player 2) input (down) management \\
            if (e.KeyCode == Keys.Up)
                player2.MoveUp = true;
            else if (e.KeyCode == Keys.Down)
                player2.MoveDown = true;
            //shoot
            else if (e.KeyCode == Keys.Left)
            {
                Bullet bullet = player2.weapon.Shoot();
                if (bullet != null)
                {
                    bullet.pictureBox.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    GameComponents[1].Add(bullet);
                }
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            // left player (player 1) input (up) management \\
            if (e.KeyCode == Keys.W)
                player1.MoveUp = false;
            else if (e.KeyCode == Keys.S)
                player1.MoveDown = false;

            // rigth player (player 1) input (up) management \\
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
                    }
                    else
                    {
                        MessageBox.Show("Bal oldali játékos nyert");
                    }
                    Reset();
                    Setup();

                    // TODO database !!!!!!!!!!

                }
            }
        }
        private void Reset()
        {
            // Removes every gamecomponents \\
            for (int i = 0; i < GameComponents.Count; i++)
            {
                for (int j = 0; j < GameComponents[i].Count; j++)
                {
                    Controls.Remove(GameComponents[i][j].pictureBox);
                }
            }

            for (int i = 0; i < GameComponents[0].Count; i++)
            {
                Player player = (Player)GameComponents[0][i];
                Controls.Remove(player.Hpbar);
            }

            GameComponents.Clear();
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainMenu.Show();
        }
    }
}