using Cowboy.Interfaces;
using System.Windows.Forms;

namespace Cowboy.Classes
{
    public class Bullet : GameComponent, IUpdate
    {
        private int Speed { get; set; }
        public int Damage { get; set; }
        public Bullet(int playerid, PictureBox pictureBox, int speed, int damage) : base(playerid, pictureBox)
        {
            this.pictureBox = pictureBox;
            Speed = speed;
            Damage = damage;
            pictureBox.BringToFront();

        }

        public void Update()
        {
            pictureBox.Left += Speed;
        }
        public bool IsInTheSreen(int width)
        {
            if (pictureBox.Left < -pictureBox.Size.Width || pictureBox.Left > width)
                return false;
            return true;
        }
    }
}
