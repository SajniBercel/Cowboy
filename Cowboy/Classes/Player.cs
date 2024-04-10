using Cowboy.Interfaces;
using Cowboy.Settings;
using Cowboy.Utilities;

namespace Cowboy.Classes
{
    public class Player : GameComponent, IUpdate, IHitable
    {
        public Label Name { get; set; }
        public ProgressBar Hpbar { get; set; }
        public Weapon weapon { get; set; }
        public PlayerSetting PlayerSettings { get; }

        private Point WeaponOffSet;

        //move
        public bool MoveUp = false;
        public bool MoveDown = false;
        private int MoveLength { get; set; }

        //hp
        private int MaxHP { get; set; }
        public int HP { get; set; }

        /// <summary>
        /// tud fel/le mozogni, lőni, őt írányitja a felhasználó input-okkal, kezeli a hpbar-ját, a fegyvert
        /// </summary>
        /// <param name="playerSetting">ebből épül fel, innen szedi össze a tulajdonságait</param>
        public Player(int playerID, string name, PictureBox _pictureBox, PlayerSetting playerSetting) : base(playerID, _pictureBox)
        {
            MoveLength = playerSetting.PlayerSpeed;
            MaxHP = playerSetting.PlayerHP;
            HP = MaxHP;

            Hpbar = Create.progressBar(name + "HpBar", new Size(50, 10), new Point(0, 0), MaxHP);
            Hpbar.Value = HP;
            Hpbar.SendToBack();

            Name = Create.label(name,name, new Point(0,0));
            Name.SendToBack();

            PlayerSettings = playerSetting;

            weapon = new Weapon(this);
        }

        public virtual void Update()
        {
            Move();
        }

        protected void Move()
        {
            if (MoveUp)
                pictureBox.Top -= MoveLength;
            if (MoveDown)
                pictureBox.Top += MoveLength;

            MoveHUD();
        }

        private void MoveHUD()
        {
            Point newPos = new Point(pictureBox.Location.X, pictureBox.Location.Y - 15);
            
            Hpbar.Location = newPos;
            newPos.Offset(0, -25);
            Name.Location = newPos;

            Name.BackColor = Color.Transparent;
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