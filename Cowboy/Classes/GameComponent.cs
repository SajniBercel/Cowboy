using System.Windows.Forms;

namespace Cowboy
{
    public class GameComponent
    {
        public int PlayerID { get; set; }
        public PictureBox pictureBox { get; set; }
        public GameComponent(int playerID, PictureBox pictureBox)
        {
            PlayerID = playerID;
            this.pictureBox = pictureBox;
        }
    }
}
