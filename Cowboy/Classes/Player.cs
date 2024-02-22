using Cowboy.Interfaces;
using Cowboy.Settings;

namespace Cowboy.Classes
{
    public class Player : GameComponent, IUpdate, IHitable
    {
        public ProgressBar Hpbar { get; set; }
        public Weapon weapon { get; set; }

        private Point WeaponOffSet;

        //move
        /// <summary>
        /// MOVES the player UP in every UPDATE
        /// </summary>
        public bool MoveUp = false;
        /// <summary>
        /// MOVES the player DOWN in every UPDATE
        /// </summary>
        public bool MoveDown = false;
        private int MoveLength { get; set; }

        //hp
        private int MaxHP { get; set; }
        public int HP { get; set; }

        /// <summary>
        /// tud fel/le mozogni, lőni, őt írányitja a felhasználó input-okkal, kezeli a hpbar-ját, a fegyvert
        /// </summary>
        /// <param name="playerSetting">ebből épül fel, innen szedi össze a tulajdonságait</param>
        public Player(int playerID, PictureBox _pictureBox, PlayerSetting playerSetting) : base(playerID, _pictureBox)
        {
            MoveLength = playerSetting.PlayerSpeed;
            MaxHP = playerSetting.PlayerHP;
            HP = MaxHP;

            Hpbar = Create.progressBar("Player1HpBar", new Size(50, 10), new Point(0, 0), MaxHP);
            Hpbar.Value = HP;

            weapon = new Weapon(this, playerSetting.ReloadSpeed*100, playerSetting.BulletSpeed, playerSetting.BulletDamage);
        }

        public void Update()
        {
            Move();
            MoveHpBar();
        }

        private void Move()
        {
            if (MoveUp)
                pictureBox.Top -= MoveLength;
            if (MoveDown)
                pictureBox.Top += MoveLength;
        }

        private void MoveHpBar()
        {
            Point newPos = new Point(pictureBox.Location.X, pictureBox.Location.Y - 30);
            Hpbar.Location = newPos;
        }

        public void SetWeaponOffSet(Point point)
        {
            WeaponOffSet = point;
        }

        public Point GetWeaponOffSetPoint()
        {
            return new Point(pictureBox.Location.X + WeaponOffSet.X, pictureBox.Location.Y + WeaponOffSet.Y);
        }

        public void Hit(GameComponent Sender)
        {
            if (Sender.PlayerID != PlayerID)
            {
                if (Sender is Bullet)
                {
                    HP -= ((Bullet)Sender).Damage;
                    if (HP < 0)
                    {
                        return;
                    }    
                    Hpbar.Value = HP;
                }
            }
        }
    }
}