namespace Cowboy.Settings
{ 
    public class PlayerSetting
    {
        public string PlayerName { get; set; }
        public int PlayerSpeed { get; set; }
        public int PlayerHP { get; set; }
        public int BulletSpeed { get; set; }
        public int BulletDamage { get; set; }
        public int ReloadSpeed { get; set; }
        public bool Bot { get; set; }

        /// <summary>
        /// Tárolja a játékos beállításait
        /// </summary>
        /// <param name="playerName"></param>
        /// <param name="playerSpeed"></param>
        /// <param name="playerHP"></param>
        /// <param name="bulletSpeed"></param>
        /// <param name="bulletDamage"></param>
        /// <param name="reloadSpeed"></param>
        /// <param name="bot"></param>
        public PlayerSetting(string playerName ,int playerSpeed, int playerHP, int bulletSpeed, int bulletDamage, int reloadSpeed, bool bot)
        {
            PlayerName = playerName;
            PlayerSpeed = playerSpeed;
            PlayerHP = playerHP;
            BulletSpeed = bulletSpeed;
            BulletDamage = bulletDamage;
            ReloadSpeed = reloadSpeed;
            Bot = bot;
        }

        public PlayerSetting(PlayerSetting playerS)
        {
            PlayerName = playerS.PlayerName;
            PlayerSpeed = playerS.PlayerSpeed;
            PlayerHP = playerS.PlayerHP;
            BulletSpeed = playerS.BulletSpeed;
            BulletDamage = playerS.BulletDamage;
            ReloadSpeed = playerS.ReloadSpeed;
            Bot = playerS.Bot;
        }

        public PlayerSetting()
        { 
            
        }

        /// <returns>PlayerSetting, alap beállítások</returns>
        public PlayerSetting SetDefaultValues()
        {
            PlayerName = "Player";
            PlayerSpeed = 5;
            PlayerHP = 5;
            BulletSpeed = 5;
            BulletDamage = 1;
            ReloadSpeed = 5;
            Bot = false;

            return this;
        }

        public PlayerSetting SetPlayerName(string name)
        {
            PlayerName = name;
            return this;
        }

        public string FileFormat()
        {
            return $"{PlayerName};{PlayerSpeed};{PlayerHP};{BulletSpeed};{BulletDamage};{ReloadSpeed};{Bot}";
        }
    }
}