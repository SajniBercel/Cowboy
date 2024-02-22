using Cowboy.Interfaces;
using Timer = System.Windows.Forms.Timer;

namespace Cowboy.Classes
{
    public class Explosion : GameComponent, IUpdate
    {
        public int UpdatesLeft { get; set; }

        public Explosion(int playerID, PictureBox pictureBox, GameComponent bulletA , GameComponent bulletB ,int updatesBerforeDestory) : base(playerID, pictureBox)
        {
            UpdatesLeft = updatesBerforeDestory;

            this.pictureBox.Location = GetPicBoxPos(bulletA,bulletB);
        }

        public void Update()
        {
            if (UpdatesLeft > 0)
            {
                UpdatesLeft--;
            }
        }

        private Point GetPicBoxPos(GameComponent BulletA, GameComponent BulletB)
        {
            int x1 = BulletA.pictureBox.Location.X;
            int y1 = BulletA.pictureBox.Location.Y + BulletA.pictureBox.Height / 2;

            int x2 = BulletB.pictureBox.Location.X;
            int y2 = BulletB.pictureBox.Location.Y + BulletB.pictureBox.Height / 2; ;

            int x = (x1 + x2) / 2;
            int y = (y1 + y2) / 2;

            x += this.pictureBox.Width / 2;
            y -= this.pictureBox.Height / 2;

            return new Point(x,y);
        }
    }
}
