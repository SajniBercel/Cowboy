using Cowboy.Interfaces;

namespace Cowboy.Classes
{
    public class Explosion : GameComponent, IUpdate
    {
        public int UpdatesLeft { get; set; }

        /// <summary>
        /// Létrehoz egy robbanás effektet 2 "GameComponent" között
        /// </summary>
        /// <param name="updatesBerforeDestory">Hány "Update" kell mielőtt törölhető</param>
        public Explosion(int playerID, PictureBox pictureBox, GameComponent bulletA, GameComponent bulletB, int updatesBerforeDestory) : base(playerID, pictureBox)
        {
            UpdatesLeft = updatesBerforeDestory;

            this.pictureBox.Location = GetPicBoxPos(bulletA,bulletB);
        }

        /// <summary>
        /// intézi hogy csökkenjen a vissza lévő idő
        /// </summary>
        public void Update()
        {
            if (UpdatesLeft > 0)
            {
                UpdatesLeft--;
            }
        }

        /// <summary>
        /// Középre (a 2 komponens közé) helyezi az effektet
        /// </summary>
        /// <param name="BulletA">komponens 1</param>
        /// <param name="BulletB">komponens 2</param>
        /// <returns>Point, középpont</returns>
        private Point GetPicBoxPos(GameComponent BulletA, GameComponent BulletB)
        {
            int x1 = BulletA.pictureBox.Location.X;
            int y1 = BulletA.pictureBox.Location.Y + BulletA.pictureBox.Height / 2;

            int x2 = BulletB.pictureBox.Location.X;
            int y2 = BulletB.pictureBox.Location.Y + BulletB.pictureBox.Height / 2;

            int x = (x1 + x2) / 2;
            int y = (y1 + y2) / 2;

            y -= this.pictureBox.Height / 2;

            return new Point(x,y);
        }
    }
}
