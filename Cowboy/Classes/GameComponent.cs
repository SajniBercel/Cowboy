namespace Cowboy
{
    public class GameComponent
    {
        public int PlayerID { get; set; }
        public PictureBox pictureBox { get; set; }
        /// <summary>
        /// Minden játékelemnek ezn az ősösztálya, tartalmazza hogy egy komponens melyik "id"-jú player-hez tartozik,
        /// tartalmaz egy PictureBox-ot (minden komponensnek van valami féle megjelenése ez tartalmazza ezt)
        /// </summary>
        /// <param name="playerID">tartalmazza az id-t hogy kihez tartozik</param>
        /// <param name="pictureBox">tartalmazza a "kinézet"-ét a komponenseknek</param>
        public GameComponent(int playerID, PictureBox pictureBox)
        {
            PlayerID = playerID;
            this.pictureBox = pictureBox;
        }
    }
}
