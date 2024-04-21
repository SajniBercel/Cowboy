using Cowboy.Interfaces;

namespace Cowboy.Classes
{
    public class Bullet : GameComponent, IUpdatable
    {
        private int Speed { get; set; }
        public int Damage { get; set; }

        /// <summary>
        /// Létrehoz egy töltényt, magában müködik nem kell kívülről mozgatni
        /// </summary>
        /// <param name="speed">"Update"-enként hány pontal kerüljön előrébb</param>
        /// <param name="damage">sebzése a játékosba</param>
        public Bullet(int playerid, PictureBox pictureBox, int speed, int damage) : base(playerid, pictureBox)
        {
            this.pictureBox = pictureBox;
            Speed = speed;
            Damage = damage;
            pictureBox.BringToFront();

        }

        /// <summary>
        /// A mozgatást végzi
        /// </summary>
        public void Update()
        {
            pictureBox.Left += Speed;
        }

        /// <summary>
        /// a törlésnél lesz szerepe
        /// </summary>
        /// <param name="width"></param>
        /// <returns>bool, a képernyőn van-e</returns>
        public bool IsInScreen(int width)
        {
            if (pictureBox.Left < -pictureBox.Size.Width || pictureBox.Left > width)
                return false;
            return true;
        }
    }
}
