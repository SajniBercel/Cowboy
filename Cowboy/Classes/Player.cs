using Cowboy.Interfaces;

namespace Cowboy.Classes
{
    public class Player : GameComponent, IUpdate, IHitable
    {
        public ProgressBar Hpbar { get; set; }
        public Weapon weapon { get; set; }

        private Point WeaponOffSet;

        //move
        public bool MoveUp = false;
        public bool MoveDown = false;
        private int MoveLength { get; set; }

        //hp
        private int MaxHP { get; set; }
        public int HP { get; set; }

        /*
        public Player(int playerID, PictureBox _pictureBox, int moveLength, int hp) : base(playerID, _pictureBox)
        {
            MoveLength = moveLength;
            MaxHP = hp;
            HP = hp;


            Hpbar = Create.progressBar("Player1HpBar", new Size(50, 10), new Point(0, 0), MaxHP);
            Hpbar.Value = HP;
        }
        */

        public Player(int playerID, PictureBox _pictureBox ,PlayerSetting playerSetting) : base(playerID, _pictureBox)
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

        public void Move()
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

        public void SetWeapon(Weapon weapon)
        {
            this.weapon = weapon;
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