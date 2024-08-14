using Cowboy.Interfaces;
using Cowboy.Settings;
using Cowboy.Utilities;

namespace Cowboy.Classes
{
    public class Player : GameComponent, IUpdatable, IHitable
    {
        public Label Name { get; set; }
        public ProgressBar Hpbar { get; set; }
        public Weapon Pistol { get; set; }
        public PlayerSetting PlayerSettings { get; }

        private Point WeaponOffSet { get; set; }

        //move
        public bool MoveUp = false;
        public bool MoveDown = false;
        private int MoveLength { get; set; }

        //hp
        private int MaxHp { get; set; }
        public int CurrentHp { get; set; }

        /// <summary>
        /// Tud fel/le mozogni, lőni, őt írányitja a felhasználó input-okkal, kezeli a hpbar-ját, a fegyvert
        /// </summary>
        /// <param name="playerSetting">ebből épül fel, innen szedi össze a tulajdonságait</param>
        public Player(int playerID, string name, PictureBox _pictureBox, PlayerSetting playerSetting) : base(playerID, _pictureBox)
        {
            MoveLength = playerSetting.PlayerSpeed;
            MaxHp = playerSetting.PlayerHP;
            CurrentHp = MaxHp;

            Hpbar = Create.progressBar(name + "HpBar", new Size(50, 10), new Point(0, 0), MaxHp);
            Hpbar.Value = CurrentHp;
            Hpbar.SendToBack();

            Name = Create.label(name,name, new Point(0,0));
            Name.SendToBack();

            PlayerSettings = playerSetting;

            Pistol = new Weapon(this);
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
                    CurrentHp -= ((Bullet)Sender).Damage;
                    if (CurrentHp < 0)
                    {
                        return;
                    }
                    Hpbar.Value = CurrentHp;
                }
            }
        }
        public void Dispose()
        { 
            Hpbar.Dispose();
            Name.Dispose();
            this.pictureBox.Dispose();
        }
    }
}