using Cowboy.Settings;

namespace Cowboy.Classes
{
    public class Bot : Player
    {
        private Player Target { get; set; }
        private Game GameForm { get; set; }

        private int RandomMoveIteration = 0;

        /// <summary>
        /// A Player-ből örököl kell neki egy plalyer aki alapján felépíti magát,
        /// egy ellenfél akire tud támadni,
        /// a game form a lövés létrehozásához
        /// </summary>
        /// <param name="player">Őt Írányítja</param>
        /// <param name="target">őt Támadja</param>
        /// <param name="gameFrom">Aktuális Game Form (lövéshez)</param>
        public Bot(Player player, Player target, Game gameFrom) : base(player.PlayerID, player.Name.Text,player.pictureBox, player.PlayerSettings)
        {
            Target = target;
            GameForm = gameFrom;

            player.Hpbar.Dispose();
            player.Name.Dispose();
        }

        /// <summary>
        /// eredeti Player Update-et használja, 
        /// ahelyett hogy külső input alapján cselekedne ő "gondolja végig" hogy mit csináljon
        /// </summary>
        public override void Update()
        {
            Think();
            base.Update();
        }

        /// <summary>
        /// Bot-nak az "agya" itt dől el hogy mit csináljon
        /// </summary>
        public void Think()
        {

            if (Target.pictureBox.Location.Y + Target.pictureBox.Height < this.pictureBox.Location.Y)
                Up();
            else if (Target.pictureBox.Location.Y - Target.pictureBox.Height > this.pictureBox.Location.Y)
                Down();

            else if (Target.pictureBox.Location.Y - Target.pictureBox.Height/2 < this.pictureBox.Location.Y && Target.pictureBox.Location.Y + Target.pictureBox.Height/2 > this.pictureBox.Location.Y)
            {
                GameForm.Shoot(this);
                Random rnd = new Random();
                bool randomBool = rnd.Next(2)==1;
                RandomMoveIteration++;
                if (RandomMoveIteration == 50)
                {
                    if (randomBool)
                    {
                        Up();
                    }
                    else
                    {
                        Down();
                    }
                    RandomMoveIteration = 0;
                }
            }
        }

        private void Up()
        {
            MoveUp = true;
            MoveDown = false;
        }

        private void Down() 
        {
            MoveUp = false;
            MoveDown = true;
        }
    }
}
