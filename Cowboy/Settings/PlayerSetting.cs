namespace Cowboy
{ 
    public class PlayerSetting
    {
        public string PlayerName { get; set; }
        public int PlayerSpeed { get; set; }
        public int PlayerHP { get; set; }
        public int BulletSpeed { get; set; }
        public int BulletDamage { get; set; }
        public int ReloadSpeed { get; set; }

        public PlayerSetting(string playerName ,int playerSpeed, int playerHP, int bulletSpeed, int bulletDamage, int reloadSpeed)
        {
            PlayerName = playerName;
            PlayerSpeed = playerSpeed;
            PlayerHP = playerHP;
            BulletSpeed = bulletSpeed;
            BulletDamage = bulletDamage;
            ReloadSpeed = reloadSpeed;
        }
        public PlayerSetting(PlayerSetting playerS)
        {
            PlayerName = playerS.PlayerName;
            PlayerSpeed = playerS.PlayerSpeed;
            PlayerHP = playerS.PlayerHP;
            BulletSpeed = playerS.BulletSpeed;
            BulletDamage = playerS.BulletDamage;
            ReloadSpeed = playerS.ReloadSpeed;
        }

        public PlayerSetting()
        { 
            
        }

        // itt ebben help
        public PlayerSetting SetDefaultValues()
        {
            PlayerName = "Player";
            PlayerSpeed = 5;
            PlayerHP = 5;
            BulletSpeed = 5;
            BulletDamage = 1;
            ReloadSpeed = 5;

            return this;
        }
        public PlayerSetting SetPlayerName(string name)
        {
            PlayerName = name;
            return this;
        }
    }
}
