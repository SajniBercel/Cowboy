namespace Cowboy.Settings
{
    public class InputSetting
    {
        public Keys UpKey { get; set; }
        public Keys DownKey { get; set; }
        public Keys ShootKey { get; set; }
        public InputSetting()
        { 
        
        }

        public InputSetting(Keys up, Keys down, Keys shoot)
        {
            UpKey = up;
            DownKey = down;
            ShootKey = shoot;
        }
    }
}
