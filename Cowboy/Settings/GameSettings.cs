namespace Cowboy.Settings
{
    public class GameSettings
    {
        public PlayerSetting[] PlayerSettings { get; set; }
        public InputSetting[] inputSettings { get; set; }
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
            PlayerSettings = playerSettings;
            WindowSize = windowSize;
            BulletCollision = bulletCollision;

        }
        public GameSettings(PlayerSetting[] playerSettings, bool bulletCollision)
        {
            PlayerSettings = playerSettings;
            BulletCollision = bulletCollision;
        }

        public GameSettings()
        { 
            
        }

        /// <returns>alap beállításokat</returns>
        public GameSettings SetDefaultSettings()
        {
            BulletCollision = false;
            WindowSize = new Size(600, 600);
            PlayerSettings = new PlayerSetting[2];
            PlayerSettings[0] = new PlayerSetting().SetDefaultValues();
            PlayerSettings[1] = new PlayerSetting().SetDefaultValues();
            return this;
        }
    }
}
