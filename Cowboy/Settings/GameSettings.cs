namespace Cowboy.Settings
{
    public class GameSettings
    {
        public PlayerSetting[] PlayerSetting { get; set; }
        public Size WindowSize { get; set; }
        public bool BulletCollision { get; set; }

        /// <summary>
        ///  Tárolja a játékra vonatkozó beállításokat
        /// </summary>
        /// <param name="playerSettings">(2) játékos beállításai</param>
        /// <param name="windowSize">Ablak mérete</param>
        /// <param name="bulletCollision">Van-e ütközés a töltények között</param>

        public GameSettings(PlayerSetting[] playerSettings, Size windowSize, bool bulletCollision)
        {
            PlayerSetting = playerSettings;
            WindowSize = windowSize;
            BulletCollision = bulletCollision;

        }
        public GameSettings(PlayerSetting[] playerSettings, bool bulletCollision)
        {
            PlayerSetting = playerSettings;
            BulletCollision = bulletCollision;
        }

        public GameSettings()
        { 
            
        }

        /// <returns>alap beállításokat ad vissza</returns>
        public GameSettings SetDefaultSettings()
        {
            BulletCollision = false;
            WindowSize = new Size(600, 600);
            PlayerSetting = new PlayerSetting[2];
            PlayerSetting[0] = new PlayerSetting().SetDefaultValues();
            PlayerSetting[1] = new PlayerSetting().SetDefaultValues();
            return this;
        }
    }
}
